using entrega_cupones.Clases;
using entrega_cupones.Modelos;
using Microsoft.VisualBasic.Devices;
using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;

namespace entrega_cupones.Metodos
{
  class mtdSocios
  {
    public static List<DDJJ> _ddjj = new List<DDJJ>();

    public static List<mdlSocio> _Socios = new List<mdlSocio>();

    public static List<Empresa> _Empresas = new List<Empresa>();

    public static mdlSocio soc = new mdlSocio();

    public static List<mdlAportes> _Aportes = new List<mdlAportes>();

    public static List<mdlSocio> GetSocios(int _FiltroDeSocio, int _BuscarPor, string _CodigoPostal, int _NroDeSocio, int _Jordada, int _CodigoCategoria, int _ActivoEnEmpresa, int _Jubilados, string DatoABuscar, string cuit, bool Carencia)
    {

      using (var context = new lts_sindicatoDataContext())
      {
        Func_Utiles fnc = new Func_Utiles();
        //var ddjj_ = from a in context.ddjj select new { a.periodo, a.cuil, a.jorp };

        DateTime _FechaDeBaja = Convert.ToDateTime("01-01-1000");

        _Socios.Clear();
        _Socios = (from a in context.maesoc
                   join b in context.soccen on a.MAESOC_CUIL equals b.SOCCEN_CUIL
                   into g
                   from essocio in g.DefaultIfEmpty()
                   join sc in context.socemp on a.MAESOC_CUIL equals sc.SOCEMP_CUIL
                   join empr in context.maeemp on sc.SOCEMP_CUITE equals empr.MAEEMP_CUIT
                   where (sc.SOCEMP_ULT_EMPRESA == 'S') &&
                   (_FiltroDeSocio == 0 ? essocio.SOCCEN_ESTADO >= 0 : _FiltroDeSocio == 1 ? essocio.SOCCEN_ESTADO == 1 : essocio.SOCCEN_ESTADO == 0) &&
                   (_BuscarPor == 0 ? a.MAESOC_NRODOC == DatoABuscar.Trim() : _BuscarPor == 1 ? a.APENOM.Contains(DatoABuscar) : _BuscarPor == 2 ? empr.MEEMP_CUIT_STR == cuit : a.MAESOC_CUIL_STR != "0") &&
                   //(_CodigoPostal == "0" ? a.MAESOC_CODPOS != _CodigoPostal : a.MAESOC_CODPOS == _CodigoPostal) &&
                   (_NroDeSocio == 0 ? a.MAESOC_NROAFIL != "0" : _NroDeSocio == 1 ? a.MAESOC_NROAFIL != "" : a.MAESOC_NROAFIL == "") &&
                   //(_CodigoCategoria == 0 ? a.MAESOC_CODCAT != _CodigoCategoria : a.MAESOC_CODCAT == _CodigoCategoria)  
                   (_Jubilados == 0 ? a.MAESOC_JUBIL != 4 : _Jubilados == 1 ? a.MAESOC_JUBIL == 1 : a.MAESOC_JUBIL == 0)
                   select new mdlSocio
                   {
                     NroDeSocio = a.MAESOC_NROAFIL,
                     NroDNI = a.MAESOC_NRODOC.Trim(),
                     ApeNom = a.MAESOC_APELLIDO.Trim() + " " + a.MAESOC_NOMBRE.Trim(),
                     Sexo = a.MAESOC_SEXO.ToString(),
                     CUIT = empr.MEEMP_CUIT_STR,
                     RazonSocial = empr.MAEEMP_RAZSOC.Trim(),
                     EsSocio = essocio.SOCCEN_ESTADO == 1 ? true : false,
                     CUIL = a.MAESOC_CUIL_STR,
                     CodigoPostal = a.MAESOC_CODPOS,
                     //JornadaParcial = false,//(from c in _ddjj where c.cuil.Contains(a.MAESOC_CUIL_STR) select new { c.periodo, jorp = Convert.ToBoolean(c.jorp) } ).OrderByDescending(x=>x.periodo).FirstOrDefault().jorp , //_ddjj.Where(x => x.cuil == a.MAESOC_CUIL_STR).OrderByDescending(x => x.periodo).FirstOrDefault().jorp,
                     Categoria = a.MAESOC_CODCAT,
                     //FechaBaja = sc.SOCEMP_FECHABAJA == _FechaDeBaja ? "" : sc.SOCEMP_FECHABAJA.ToString(),
                     Jubilado = a.MAESOC_JUBIL,
                     EstadoCivil = a.MAESOC_ESTCIV.ToString(),
                     Edad = fnc.calcular_edad(a.MAESOC_FECHANAC).ToString(),
                     Calle = a.MAESOC_CALLE,
                     Barrio = a.MAESOC_BARRIO,
                     NroCalle = a.MAESOC_NROCALLE,
                     LocalidadString = mtdFuncUtiles.GetLocalidad(a.MAESOC_CODLOC), //fnc.GetLocalidad(a.MAESOC_CODLOC),
                     Telefono = a.MAESOC_TEL + " - " + a.MAESOC_TELCEL,
                     EmpresaNombre = empr.MAEEMP_NOMFAN,
                     EmpresaTelefono = empr.MAEEMP_TEL,
                     EmpresaDomicilio = empr.MAEEMP_CALLE + " Nº" + empr.MAEEMP_NRO,
                     EmpresaContador = empr.MAEEMP_ESTUDIO_CONTACTO,
                     EmpresaContadorTelefono = empr.MAEEMP_ESTUDIO_TEL,
                     EmpresaContadorEmail = empr.MAEEMP_ESTUDIO_EMAIL,
                     EmpresaEmail = empr.MAEEMP_EMAIL,
                     EmpresaCodigoPostal = empr.MAEEMP_CODPOS,
                     EmpresaLocalidad = mtdFuncUtiles.GetLocalidad(Convert.ToInt32(empr.MAEEMP_CODLOC)),
                     //Aportes = GetAportes(a.MAESOC_CUIL_STR)
                     Carencia = false
                   }).ToList();
        //_BuscarPor
        // 0 D.N.I.
        // 1 Apellido y Nombre
        // 2 Empresa
        // 3 Todas las Empresas

        if (_Socios.Count() > 0)
        {
          Getddjj(_BuscarPor, cuit);
        }

        var empresa = from a in context.maeemp
                      select new Empresa
                      {
                        MEEMP_CUIT_STR = a.MEEMP_CUIT_STR,
                        MAEEMP_RAZSOC = a.MAEEMP_RAZSOC,
                      };

        _Empresas.AddRange(empresa.ToList());

        _Socios.ForEach(x => x.JornadaParcial = GetJornada(_BuscarPor, x.CUIL));
        _Socios.ForEach(x => x.Aportes = GetAportes2(x.CUIL));
        _Socios.ForEach(x => x.Carencia = x.Aportes.Count() > 0 ? VerificarCarencia(x.Aportes.Max(y => y.Periodo)) : true);
        _Socios.ForEach(x => x.Carencia =  VerificarCarencia(x.Aportes.Max(y => y.Periodo)));

        if (Carencia)
        {
          return _Socios.Where(x => x.Carencia == false).OrderBy(x => x.ApeNom).ToList();
        }
        else
        {
          return _Socios.OrderBy(x => x.ApeNom).ToList();
        }
      }
    }

    public static bool GetJornada(int buscarpor, string CUIL)
    {
      //   var j = from a in _ddjj.OrderByDescending(x => x.cuil) where a.cuil == CUIL select a;
      var j = from a in _ddjj.OrderByDescending(x => x.cuil) where a.cuil == CUIL select a;

      if (j.Count() > 0)
      {
        return j.FirstOrDefault().jorp;
      }
      else
      {
        return false;
      }

    }


    public static void Getddjj(int buscarPor, string cuit)
    {
      using (var context = new lts_sindicatoDataContext())
      {
        switch (buscarPor)
        {
          case 0:

            List<DDJJ> dj0 = (from a in context.ddjj
                              where
                              a.CUIL_STR == _Socios.FirstOrDefault().CUIL
                              select new DDJJ
                              {
                                periodo = Convert.ToDateTime(a.periodo),
                                cuil = a.CUIL_STR,
                                jorp = a.jorp,
                                AporteLey = Convert.ToDecimal((a.impo + a.impoaux) * 0.02),
                                AporteSocio = Convert.ToDecimal((a.item2 == true) ? (a.impo + a.impoaux) * 0.02 : 0),
                                Sueldo = Convert.ToDecimal(a.impo + a.impoaux),
                                cuite = a.CUIT_STR
                              }).ToList();
            _ddjj.Clear();
            _ddjj.AddRange(dj0);
            break;

          case 1:

            _ddjj.Clear();
            foreach (var item in _Socios.ToList())
            {
              List<DDJJ> dj1 = (from a in context.ddjj
                                where
                                a.CUIL_STR == item.CUIL
                                select new DDJJ
                                {
                                  periodo = Convert.ToDateTime(a.periodo),
                                  cuil = a.CUIL_STR,
                                  jorp = a.jorp,
                                  AporteLey = Convert.ToDecimal((a.impo + a.impoaux) * 0.02),
                                  AporteSocio = Convert.ToDecimal((a.item2 == true) ? (a.impo + a.impoaux) * 0.02 : 0),
                                  Sueldo = Convert.ToDecimal(a.impo + a.impoaux),
                                  cuite = a.CUIT_STR
                                }).ToList();
              _ddjj.AddRange(dj1);
            }
            break;

          case 2:

            List<DDJJ> dj2 = (from a in context.ddjj
                              where
                              a.CUIT_STR == cuit
                              select new DDJJ
                              {
                                periodo = Convert.ToDateTime(a.periodo),
                                cuil = a.CUIL_STR,
                                jorp = a.jorp,
                                AporteLey = Convert.ToDecimal((a.impo + a.impoaux) * 0.02),
                                AporteSocio = Convert.ToDecimal((a.item2 == true) ? (a.impo + a.impoaux) * 0.02 : 0),
                                Sueldo = Convert.ToDecimal(a.impo + a.impoaux),
                                cuite = a.CUIT_STR
                              }).ToList();
            _ddjj.Clear();
            _ddjj.AddRange(dj2);
            break;

        }
      }
    }

    public static List<mdlAportes> GetAportes(string CUIL)
    {
      using (var context = new lts_sindicatoDataContext())
      {
        var Aportes = from a in context.ddjj
                      .Where(x => x.CUIL_STR == CUIL)
                      .OrderByDescending(x => x.periodo)
                      select new mdlAportes
                      {
                        Periodo = Convert.ToDateTime(a.periodo).Date,
                        AporteLey = Convert.ToDecimal((a.impo + a.impoaux) * 0.02),
                        AporteSocio = (decimal)(a.item2 ? ((a.impo + a.impoaux) * 0.02) : 0),
                        RazonSocial = getRazonSocial(a.CUIL_STR),//Convert.ToDecimal((a.item2 == true) ? (a.impo + a.impoaux) * 0.02 : 0),
                        Sueldo = (decimal)(a.impo + a.impoaux)
                      };
        _Aportes.AddRange(Aportes);
        return _Aportes;//.OrderByDescending(x => x.Periodo); //.ToList();
      }
    }

    public static List<mdlAportes> GetAportes2(string CUIL)
    {
      using (var context = new lts_sindicatoDataContext())
      {
        var Aportes = from a in context.ddjj.Where(x => x.CUIL_STR == CUIL)
              //.Where(x => x.cuil == CUIL)
              .OrderByDescending(x => x.periodo)
                      select new mdlAportes
                      {
                        Periodo = Convert.ToDateTime(a.periodo).Date,
                        AporteLey = Convert.ToDecimal((a.impo + a.impoaux) * 0.02),
                        AporteSocio = (decimal)(a.item2 ? ((a.impo + a.impoaux) * 0.02) : 0),
                        RazonSocial = (string)(from b in context.maeemp.Where(x => x.MEEMP_CUIT_STR == a.CUIT_STR) select b.MAEEMP_RAZSOC).SingleOrDefault(), // getRazonSocial2(a.CUIL_STR),
                        Jornada = a.jorp ? "PARCIAL" : "COMPLETA",
                        Sueldo = (decimal)(a.impo + a.impoaux)
                      };
        _Aportes.Clear();
        _Aportes.AddRange(Aportes);
        return _Aportes;//.OrderByDescending(x => x.Periodo); //.ToList();

      }
    }

    public static string getRazonSocial(string cuil)
    {
      // GetEmpresaActual(Convert.ToDouble( cuit))

      var RazSoc = _Empresas.Where(x => x.MEEMP_CUIT_STR == GetEmpresaActual(cuil));

      if (RazSoc.Count() == 0)
      {
        return "Sin Asignar";
      }
      else
      {
        return RazSoc.FirstOrDefault().MAEEMP_RAZSOC.Trim();
        //return _Empresas.Where(x => x.MEEMP_CUIT_STR == cuit).FirstOrDefault().MAEEMP_RAZSOC.Trim();

      }
    }

    private static bool VerificarCarencia(DateTime ultimaDDJJ)
    {
      DateTime UltimoPeriodoDeclarado = ultimaDDJJ;
      DateTime hoy = DateTime.Now;

      int meses = Convert.ToInt32((hoy - UltimoPeriodoDeclarado).TotalDays) / 30;

      if (meses > 3)
      {
        return true;
      }
      else
      {
        return false;
      }


    }

    public static List<MdlBenef> GetBeneficiarios(double cuil)
    {
      using (var context = new lts_sindicatoDataContext())
      {
        var Beneficiario = (from sf in context.socflia.Where(x => x.SOCFLIA_CUIL == cuil)
                            join mf in context.maeflia on sf.SOCFLIA_CODFLIAR equals mf.MAEFLIA_CODFLIAR
                            join cba_ in context.CuponBenefArticulos.Where(x => x.Cuil == Convert.ToString(cuil) && x.EventoId == 5)
                                     on Convert.ToInt32(sf.SOCFLIA_CODFLIAR) equals cba_.CodigoFliar
                                     into ccc
                            from cba in ccc.DefaultIfEmpty()
                            join art_ in context.articulos
                                     on cba.ArticuloId equals art_.ID
                                     into eee
                            from art in eee.DefaultIfEmpty()
                            join ec_ in context.eventos_cupones.Where(x => x.CuilStr == Convert.ToString(cuil) && x.eventcupon_evento_id == 5)
                                     on cba.NroCupon equals ec_.event_cupon_nro
                                     into fff
                            from ec in fff.DefaultIfEmpty()

                            select new MdlBenef
                            {
                              ApeNom = mf.MAEFLIA_APELLIDO.Trim() + " " + mf.MAEFLIA_NOMBRE.Trim(),
                              Parentesco = (sf.SOCFLIA_PARENT == 1) ? "CONYUGE" :
                                                    (sf.SOCFLIA_PARENT == 2) ? "HIJO MENOR DE 16" :
                                                    (sf.SOCFLIA_PARENT == 3) ? "HIJO MENOR DE 18" :
                                                    (sf.SOCFLIA_PARENT == 4) ? "HIJO MENOR DE 21" :
                                                    (sf.SOCFLIA_PARENT == 5) ? "HIJO MAYOR DE 21" : "",
                              CodigoFliar = Convert.ToInt32(mf.MAEFLIA_CODFLIAR),
                              DNI = mf.MAEFLIA_NRODOC.ToString(),
                              FechaNac = mf.MAEFLIA_FECNAC,
                              Edad = mtdFuncUtiles.calcular_edad(mf.MAEFLIA_FECNAC),
                              MochilaId = cba.ArticuloId,
                              Mochila = art.Descripcion,
                              FechaGeneracionDeCupon = ec.event_cupon_fecha,
                              NroCupon = ec.event_cupon_nro,
                              FechaDeEntrega = Convert.ToDateTime(ec.FechaDeEntregaArticulo),
                              // Reimpresion =(int) ec.Reimpresion

                            }).OrderByDescending(x => x.DNI);

        //.Where(x => x.Edad >= 3 && x.Edad <= 19);//

        return Beneficiario.ToList();

      }
    }

    public static mdlSocio GetDatosDelSocio(string cuil)
    {
      using (var context = new lts_sindicatoDataContext())
      {
        var socio = from a in context.maesoc
                    where a.MAESOC_CUIL_STR == cuil
                    select a;

        if (socio.Count() > 0)
        {
          soc.NroDeSocio = socio.FirstOrDefault().MAESOC_NROAFIL;
          soc.ApeNom = socio.FirstOrDefault().APENOM;
        }

        return soc;
      }
    }

    public static mdlSocio GetDatosDelSocioPorNroDeSocio(string NroSocio)
    {
      using (var context = new lts_sindicatoDataContext())
      {
        var socio = from a in context.maesoc
                    where a.MAESOC_NROAFIL == NroSocio
                    select a;
        if (socio.Count() > 0)
        {
          soc.NroDeSocio = socio.FirstOrDefault().MAESOC_NROAFIL;
          soc.NroDNI = socio.FirstOrDefault().MAESOC_NRODOC;
          soc.ApeNom = socio.FirstOrDefault().APENOM;
          soc.Telefono = socio.FirstOrDefault().MAESOC_TEL + socio.FirstOrDefault().MAESOC_TELCEL;
          soc.CUIL = socio.FirstOrDefault().MAESOC_CUIL_STR;
        }
        return soc;
      }
    }

    public static Binary get_foto_titular_binary(double cuil)
    {
      convertir_imagen cnv_img = new convertir_imagen();
      using (var context = new lts_sindicatoDataContext())
      {
        Binary foto;
        var foto_ = from a in context.fotos where a.FOTOS_CUIL == cuil && a.FOTOS_CODFLIAR == 0 select a;
        if (foto_.Count() > 0)
        {
          foto = foto_.FirstOrDefault().FOTOS_FOTO;
        }
        else
        {
          // cuando no hay foto trae la imagen del contorno del usuario.
          foto = cnv_img.ImageToByteArray(Properties.Resources.User_Contorno_);
        }
        return foto;
      }
    }

    public static Binary Get_Foto_Titular_BinaryString(string CUIL)
    {
      convertir_imagen cnv_img = new convertir_imagen();
      using (var context = new lts_sindicatoDataContext())
      {
        Binary foto;
        var foto_ = from a in context.fotos where a.CUIL_STR == CUIL && a.FOTOS_CODFLIAR == 0 select a;
        if (foto_.Count() > 0)
        {
          foto = foto_.FirstOrDefault().FOTOS_FOTO;
        }
        else
        {

          // cuando no hay foto trae la imagen del contorno del usuario.
          foto = mtdConvertirImagen.ImageToByteArray(Properties.Resources.User_Contorno_);
          //foto = cnv_img.ImageToByteArray(Properties.Resources.User_Contorno_);
        }
        return foto;
      }
    }

    public static List<mdlSocio> GetMaeSoc()
    {
      using (var context = new lts_sindicatoDataContext())
      {
        var socio = (from a in context.maesoc
                     select new mdlSocio
                     {
                       Concat = a.APENOM.Trim() + " " + a.MAESOC_NROAFIL + " " + a.MAESOC_NRODOC.Trim(),
                       ApeNom = a.APENOM.Trim(),
                       NroDeSocio = a.MAESOC_NROAFIL.Trim(),
                       NroDNI = a.MAESOC_NRODOC.Trim(),
                       EsSocioString = context.soccen.Where(x => x.SOCCEN_CUIL == a.MAESOC_CUIL).SingleOrDefault().SOCCEN_ESTADO == 1 ? "SI" : "NO",
                       EsSocio = context.soccen.Where(x => x.SOCCEN_CUIL == a.MAESOC_CUIL).SingleOrDefault().SOCCEN_ESTADO == 1 ? true : false,
                       CUIL = a.MAESOC_CUIL_STR.Trim(),
                       CUIT = (from e in context.socemp.Where(x => x.SOCEMP_CUIL == a.MAESOC_CUIL && x.SOCEMP_ULT_EMPRESA == 'S') select e).SingleOrDefault().SOCEMP_CUITE_STR,
                       Jubilado = a.MAESOC_JUBIL,
                       Sexo = a.MAESOC_SEXO.ToString(),
                       FechaNacimiento = a.MAESOC_FECHANAC,
                       FechaBaja = a.MAESOC_FECHADESEMPLEO,
                       Telefono = a.MAESOC_TEL.Trim() + " - " + a.MAESOC_TELCEL.Trim(),
                       Categoria = a.MAESOC_CODCAT,
                       CodigoPostal = a.MAESOC_CODPOS.Trim(),
                       Localidad = a.MAESOC_CODLOC,
                       LocalidadString = a.MAESOC_CODLOC == 0 ? "No Especicifica" : (from b in context.localidad.Where(x => x .MAELOC_CODLOC == a.MAESOC_CODLOC) select b).FirstOrDefault().MAELOC_NOMBRE.Trim(), //mtdFuncUtiles.GetLocalidad(a.MAESOC_CODLOC),
                       Calle = a.MAESOC_CALLE.Trim(),
                       Barrio = a.MAESOC_BARRIO.Trim(),
                       NroCalle = a.MAESOC_NROCALLE.Trim(),
                       EstadoCivil = a.MAESOC_ESTCIV.ToString(),
                       JornadaParcial = context.ddjj.Where(x => x.CUIL_STR == a.MAESOC_CUIL_STR).OrderByDescending(x => x.periodo).FirstOrDefault().jorp == null ?
                                        false : context.ddjj.Where(x => x.CUIL_STR == a.MAESOC_CUIL_STR).OrderByDescending(x => x.periodo).FirstOrDefault().jorp,
                     }).OrderBy(x => x.ApeNom).ToList();
        return socio;
      }
    }

    public static List<mdlSocio> GetSocioBuscado(List<mdlSocio> _SociosABuscar, string ABuscar, int EsSocio, string CUIT, int Jornada, int ConNroSocio, int Categoria, int LocalidadCode)
    {
      var Encontrados = (from a in _SociosABuscar.Where(x => x.Concat.Contains(ABuscar.ToUpper()))
               .Where(x => (EsSocio == 1 ? (x.EsSocioString == "SI") : EsSocio == 2 ? (x.EsSocioString == "NO") : (x.EsSocioString == "SI" || x.EsSocioString == "NO")))
               .Where(x => CUIT == "" ? x.CUIT != "" : x.CUIT == CUIT)
               .Where(x => Jornada == 1 ? (x.JornadaParcial == false) : Jornada == 2 ? (x.JornadaParcial == true) : (x.JornadaParcial == true || x.JornadaParcial == false))
               .Where(x => ConNroSocio == 1 ? (x.NroDeSocio != "") : ConNroSocio == 2 ? (x.NroDeSocio == "") : (x.NroDeSocio == "" || x.NroDeSocio != ""))
               .Where(x => Categoria == 0 ? (x.Categoria != 0) : (x.Categoria == Categoria))
               .Where(x=> LocalidadCode == 0 ? (x.Localidad != LocalidadCode) : (x.Localidad == LocalidadCode))
                         select a).ToList();
      return Encontrados;
    }

    public static string GetEmpresaActual(string Cuil)
    {
      using (var context = new lts_sindicatoDataContext())
      {
        //var EmpAct = (from c in context.socemp where c.SOCEMP_CUIL == Convert.ToDouble(Cuil) && c.SOCEMP_ULT_EMPRESA == 'S' select new { CUIT = c.SOCEMP_CUITE_STR });

        var EmpAct = (from c in context.socemp where c.SOCEMP_CUIL_STR == Cuil && c.SOCEMP_ULT_EMPRESA == 'S' select new { CUIT = c.SOCEMP_CUITE_STR });
        if (EmpAct.Count() > 0)
        {
          return EmpAct.SingleOrDefault().CUIT;
        }
        else
        {
          return "0";
        }
      }
    }

    public static string getRazonSocial2(string Cuil)
    {
      using (var context = new lts_sindicatoDataContext())
      {
        var RazSoc = from b in context.maeemp where b.MEEMP_CUIT_STR == GetEmpresaActual(Cuil) select new { RazSoc = b.MAEEMP_RAZSOC.Trim() };
        if (RazSoc.Count() > 0)
        {
          return RazSoc.FirstOrDefault().RazSoc;
        }
        else
        {
          return "Sin Asignar";
        }
      }
    }
  }
}


