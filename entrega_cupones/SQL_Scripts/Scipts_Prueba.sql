select * from ddjjt where CUIT_STR = '27238382756' order by periodo

select cuit, (titem1 + titem2 ) as 'Deuda' from ddjjt where CAST(periodo as date) = CONVERT(date,'2020-05-01') and impban1 = 0  order by CUIT_STR

select sum(titem1+titem2) as 'Deuda' from ddjjt where CAST(periodo as date) = CONVERT(date,'2020-05-01') and impban1 = 0 -- order by CUIT_STR

select * from ddjjt where CUIT_STR = '30715622315' and CAST(periodo as date) = CONVERT(date,'2021-03-01') order by periodo

select * from ddjjt where CUIT_STR = '20210468154' and CAST(periodo as date) = CONVERT(date,'2021-03-01') order by periodo

select sum(titem1+titem2) as 'Deuda'   from ddjjt where CUIT_STR = '30659735527' and CAST(periodo as date) >= CONVERT(date,'2020-04-01') and estado =1-- order by periodo

select * from ddjjt where CUIT_STR = '30714612251' and CAST(periodo as date) = CONVERT(date,'2021-02-01') order by periodo

select  sum(titem1+titem2) as 'DDJJ', sum( impban1 ) as 'cobrado' from ddjjt where  CAST(periodo as date) = CONVERT(date,'2022-09-01') -- order by periodo

select  sum(titem1+titem2) as 'DDJJ', sum( impban1 - ctrlimp) as 'cobrado', sum ((titem1+titem2) - (impban1 - ctrlimp)) as 'Falta Cobrar' , sum(ctrlimp ) as 'Ctrl1' from ddjjt where  CAST(periodo as date) = CONVERT(date,'2022-09-01') -- order by periodo

select ctrlimp from ddjjt where  CAST(periodo as date) = CONVERT(date,'2020-05-01') order by periodo


 select * from ddjjt where CUIT_STR in (20130014691,20139694601,20173276541,20174984760,20178906721,20210468154,20216324901,20224404167,20229527747,20230944696,20238083886,20240348293,20254703738,20258596804,20260402898,20263841604,20270582185,20276089413,20284758308,20288845337,20289177605,20292366664,20303161725,20353442229,20374443004,20387180843,20387181734,23120029509,23213412264,23261610159,27105620727,27111436156,27129239307,27173278743,27221691577,27221695335,27227223834,27231248531,27240348441,27247469384,27257095482,27330888690,30570797987,30623621223,30686642530,30708419695,30709102687,30709268534,30709883859,30709897809,30712254277,30714612251,30715025708,30716302640,30716378701,30717206661,30717442322,30717557707,33570645639) and CAST(periodo as date) = CONVERT(date,'2022-09-01') order by periodo
--  (20130014691,20139694601,20173276541,20174984760,20178906721,20210468154,20216324901,20224404167,20229527747,20230944696,20238083886,20240348293,20254703738,20258596804,20260402898,20263841604,20270582185,20276089413,20284758308,20288845337,20289177605,20292366664,20303161725,20353442229,20374443004,20387180843,20387181734,23120029509,23213412264,23261610159,27105620727,27111436156,27129239307,27173278743,27221691577,27221695335,27227223834,27231248531,27240348441,27247469384,27257095482,27330888690,30570797987,30623621223,30686642530,30708419695,30709102687,30709268534,30709883859,30709897809,30712254277,30714612251,30715025708,30716302640,30716378701,30717206661,30717442322,30717557707,33570645639)

select periodo, cuit, count(*) 
from ddjjt 
where CAST(periodo as date) = CONVERT(date,'2022-09-01')
group by periodo,cuit
having count (*) > 1

select CUIT_STR, impban1, ctrlimp  from ddjjt where CUIT_STR = '30596263980'and CAST(periodo as date) = CONVERT(date,'2022-09-01')

select sum(titem1+titem2) as 'DDJJ' ,  sum( impban1 - ctrlimp) as 'cobrado' , sum ((titem1+titem2) - (impban1 - ctrlimp)) as 'Falta Cobrar' from ddjjt where  CAST(periodo as date) = CONVERT(date,'2022-09-01') --order by periodo

select sum(titem1+titem2) as 'Falta Cobrar' from ddjjt where CAST(periodo as date) = CONVERT(date,'2022-09-01') and impban1 = 0

select * from ddjjt where CUIT_STR = '30716378701' and CAST(periodo as date) = CONVERT(date,'2022-09-01') order by periodo

-- delete from ddjjt where CAST(periodo as date) = CONVERT(date,'2022-09-01')  and CUIT_STR ='30716378701' and rect = 0

select sum (ctrlimp  ) as '> 0'  from ddjjt where CAST(periodo as date) = CONVERT(date,'2022-09-01') and ctrlimp > 0 --  and impban1 = 0

select sum (ctrlimp  ) as '< 0'  from ddjjt where CAST(periodo as date) = CONVERT(date,'2022-09-01') and ctrlimp < 0

select * from ddjjt where cuit_str = '20270534185' and  CAST(periodo as date) = CONVERT(date,'2022-09-01')

select (titem1 + titem2) as 'capital', impban1,ctrlimp as 'Interes', CUIT_STR from ddjjt where  CAST(periodo as date) = CONVERT(date,'2022-09-01') order by capital


select * from vd_inspector 

select * from VD_Detalle

update VD_Detalle set VDInspectorId = 30 where id=655


   --var informe = (from a in context.ddjjt.Where(x => x.periodo >= Convert.ToDateTime(Desde))
   --                    group a by a.periodo into gp
   --                    select new Mdl_InformeDDJJCobrosActas
   --                    {
   --                      Periodo = (DateTime)gp.Key,
   --                      ImporteDDJJ = (decimal)(gp.Sum(x => x.titem1) + gp.Sum(x => x.titem2)),
   --                      CobradoDDJJ = (decimal)gp.Sum(x => x.impban1),
   --                      FaltaCobrar = (decimal)(gp.Sum(x => x.titem1 + x.titem2) - (gp.Sum(x => x.impban1))),
   --                      Empresas = (List<MdlDeudaEmpresa>)gp.Where(x => x.periodo == gp.Key && x.impban1 == 0).Select(x => new MdlDeudaEmpresa
   --                      {
   --                        CUIT = x.CUIT_STR,
   --                        Empresa = (from a in context.maeemp.Where(y => y.MEEMP_CUIT_STR == x.CUIT_STR) select a).SingleOrDefault().MAEEMP_RAZSOC.Trim(),  // context.maeemp.Select(z => z.MAEEMP_RAZSOC).Where(y => y.MEEMP_CUIT_STR == x.CUIT_STR)//mtdEmpresas.GetEmpresaNombre(x.CUIT_STR).Trim(),
   --                        Deuda = (decimal)((x.titem1 + x.titem2)),
   --                        Periodo = (DateTime)x.periodo,
   --                      }),

   --                    }).OrderBy(x => x.Periodo);


   -- (decimal)gp.Where(x => x.ImporteDepositado == 0).Sum(x => (x.AporteLey + x.AporteSocio)),


   --System.InvalidCastException: No se puede convertir un objeto de tipo 'WhereSelectListIterator`2[entrega_cupones.Modelos.EstadoDDJJ,entrega_cupones.Modelos.MdlDeudaEmpresa]' al tipo 'System.Collections.Generic.List`1[entrega_cupones.Modelos.MdlDeudaEmpresa]'.
   --en entrega_cupones.Formularios.Tesoreria.Frm_InformeComparativoDDJJPagosActas.dgv_ddjj_SelectionChanged(Object sender, EventArgs e) en D:\Proyectos\entrega_cupones\entrega_cupones\Formularios\Informes\Frm_InformeComparativoDDJJPagosActas.cs:línea 136

   select * from vd_detalle


   select * from fotos_.maeemp where MAEEMP_CUIT = 33570645639

   select* from fotos_.socemp where SOCEMP_CUIL = 20273909134

   select * from fotos_.maesoc 



    -- public void MostrarListaSocios()
    --{

    --  //var xxx = mtdSocios.GetSocioBuscado
    --  //  (_SociosABuscar, Txt_Buscar.Text.ToUpper(), Cbx_Filtrar.SelectedIndex, Convert.ToString(Cbx_Empresa.SelectedValue))
    --  //if (xxx.Count() > 0)
    --  //{
    --  //  Dgv_Socios.DataSource = xxx;
    --  //  Txt_CantidadSocios.Text = xxx.Count(x => x.EsSocioString == "SI").ToString("N0");
    --  //}
    --  //else
    --  //{
    --  //  Dgv_Socios.DataSource = null;
    --  //  PicBox_FotoSocio.Image = null;
    --  //  Txt_CantidadSocios.Text = "0";
    --  //}
    --}

    --//public void MostrarListaSocios2()
    --//{
    --//  int Index = Cbx_Filtrar.SelectedIndex;
    --//  string CUIT = Convert.ToString(Cbx_Empresa.SelectedValue);

    --//  var xxx = (from a in _SociosABuscar.Where(x => x.Concat.Contains(Txt_Buscar.Text.ToUpper()))
    --//           .Where(x => (Index == 1 ? (x.EsSocioString == "SI") : Index == 2 ? (x.EsSocioString == "NO") : (x.EsSocioString == "SI" || x.EsSocioString == "NO")))
    --//           .Where(x => CUIT == "" ? x.CUIT != "" : x.CUIT == CUIT)
    --//             select a).ToList();

    --//  if (xxx.Count() > 0)
    --//  {
    --//    Dgv_Socios.DataSource = xxx;
    --//    Txt_CantidadSocios.Text = xxx.Count(x => x.EsSocioString == "SI").ToString("N0");
    --//  }
    --//  else
    --//  {
    --//    Dgv_Socios.DataSource = null;
    --//    PicBox_FotoSocio.Image = null;
    --//    Txt_CantidadSocios.Text = "0";
    --//  }
    --//}


    select * from fotos_.maesoc 

    update fotos_.maesoc set MAESOC_GRUPOSANG = 1

    select * from fotos_.maesoc where MAESOC_FECHANAc is null

    select * from fotos_.fotos

   --  ALTER TABLE fotos_.fotos ADD CUIL_STR varchar(50)
   -- update fotos_.fotos set CUIL_STR = CONVERT (bigint, FOTOS_CUIL)

  --  ALTER TABLE fotos_.socflia ADD CUIL_STR varchar(50)
  --  update fotos_.socflia set CUIL_STR = CONVERT (varchar, SOCFLIA_CUIL)
  select * from fotos_.maeflia

  ALTER TABLE fotos_.fotos ADD CUIL_STR varchar(50)
update fotos_.fotos set CUIL_STR = CONVERT (bigint, FOTOS_CUIL)

ALTER TABLE fotos_.socflia ADD CUIL_STR varchar(50)
update fotos_.socflia set CUIL_STR = CONVERT (bigint, SOCFLIA_CUIL)

select * from ddjj where cuil = 20228443949

select * from fotos_.socemp where SOCEMP_ULT_EMPRESA = 'S'

ALTER TABLE fotos_.socemp ADD SOCEMP_CUIL_STR varchar(50)
update fotos_.socemp set SOCEMP_CUIL_STR = CONVERT (bigint, SOCEMP_CUIL)

ALTER TABLE fotos_.socemp DROP COLUMN CUIL_STR;

select * from fotos_.maesoc where MAESOC_NRODOC = '29453503'-- 27 8

select * from ddjj where CUIL_STR = '23294535039' order by periodo desc



select * from fotos_.maesoc where MAESOC_CODLOC = 0

select * from categorias_empleado 

select * from localidad where MAELOC_CODLOC is null

select * from fotos_.maesoc

select * from  ddjj where CUIL_STR = '20297857941' order by periodo desc

select * from ddjj where CUIL_STR = '27352869355'  order by periodo desc

select * from fotos_.maesoc where MAESOC_CUIL_STR = '27352869355' 

select * from fotos_.socemp where SOCEMP_CUIL_STR = '20297857941' 

select * from fotos_.socemp where CONVERT(date, '01-01-1000' ) = CAST(SOCEMP_FECHABAJA AS date)

select * from fotos_.socemp where SOCEMP_ESTADO = 0;

select * from fotos_.socemp where SOCEMP_ESTADO = 1 and SOCEMP_SOCIOCENTRO = 1 and SOCEMP_ULT_EMPRESA = 'S';

select * from fotos_.socemp where SOCEMP_ESTADO = 1 and SOCEMP_SOCIOCENTRO = 0 and SOCEMP_ULT_EMPRESA = 'S';

select * from fotos_.soccen where SOCCEN_DESPEDIDO = 1 and SOCCEN_ESTADO = 1

select * from fotos_.maesoc where MAESOC_JUBIL = 1

select * from fotos_.maesoc where MAESOC_SEXO = 'M'

select MAESOC_ESTCIV from fotos_.maesoc where MAESOC_ESTCIV <> '' group by MAESOC_ESTCIV -- order by MAESOC_ESTCIV

select * from fotos_.maesoc where MAESOC_ESTCIV = 'B'

select * from ddjj where  jorp = 1 

select * from fotos_.maesoc where MAESOC_NRODOC = '11111111'

delete from fotos_.maesoc where MAESOC_NRODOC = '11111111'

select CUIL_STR from ddjj dj group by CUIL_STR 

select * from fotos_.maesoc ms left join ddjj dj on ms.MAESOC_CUIL = dj.CUIL_STR

select * from ddjj

select * from categorias_empleado

select * from localidad where MAELOC_CODPROV = 'G'

select * from fotos_.maesoc where MAESOC_CODLOC =0

select * from localidad where MAELOC_NOMBRE is null

insert into localidad values (0,'G',' TODAS')

delete localidad where MAELOC_CODLOC = 0

select * from localidad where  MAELOC_CODPROV = 'G'

select * from fotos_.maesoc where  MAESOC_CODLOC = 0

select * from jugadores



