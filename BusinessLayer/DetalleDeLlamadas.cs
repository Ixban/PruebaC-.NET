using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class DetalleDeLlamadas
    {

        public static ML.Result getAll(string FilterNumero, string FilterDescripcion)
        {
            ML.Result result = new ML.Result();

            try
            {

                FilterNumero = FilterNumero == "None" ? "" : FilterNumero;
                FilterDescripcion = FilterDescripcion == "None" ? "" : FilterDescripcion;

                using (DataLayer.pruebaEntities1 context = new DataLayer.pruebaEntities1())
                {

                    var DetalleConsult = context.getDetallesDeLlamadas(FilterNumero, FilterDescripcion).ToList();

                    var DetalleConsultV = DetalleConsult;

                    result.Objects = new List<object>();

                    if (DetalleConsult != null)
                    {
                        result.Correct = true;

                        foreach (DataLayer.getDetallesDeLlamadas_Result DetalleItem in DetalleConsult)
                        {
                            ML.DetalleDeLlamadas detalle = new ML.DetalleDeLlamadas();
                            detalle.CallDetailId = Convert.ToInt32(DetalleItem.CallDetailId.ToString());
                            detalle.MobileLine = DetalleItem.MobileLine.ToString();
                            detalle.CalledPartyNumber = DetalleItem.CalledPartyNumber.ToString();
                            detalle.CalledPartyDescription = DetalleItem.CalledPartyDescription.ToString();
                            string[] fecha = DetalleItem.DateTime.Split(' ');
                            detalle.DateTime = fecha[0];
                            detalle.HourTime = fecha[1];
                            detalle.LineasCelulares = new ML.LineasCelulares();
                            detalle.LineasCelulares.Description = DetalleItem.Description;
                            detalle.Duration = DetalleItem.Duration;
                            detalle.TotalCost = float.Parse(DetalleItem.TotalCost.ToString());
                            result.Objects.Add(detalle);
                        }

                    }
                    else
                    {
                        result.Correct = false;
                        result.MessageError = "No existen registros";
                        //No existen registros
                    }


                }

            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.MessageError = ex.Message;
            }


            return result;
        }

    }
}
