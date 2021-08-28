using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class LineasCelularess
    {

        public static ML.Result getAll()
        {
            ML.Result result = new ML.Result();

            try
            {

                using (DataLayer.pruebaEntities1 context = new DataLayer.pruebaEntities1())
                {

                    var LlamadaConsult = context.getLineasCelulares();

                    result.Objects = new List<object>();

                    if (LlamadaConsult != null)
                    {
                        result.Correct = true;

                        foreach (DataLayer.getLineasCelulares_Result llamadaItem in LlamadaConsult)
                        {
                            ML.LineasCelulares linea = new ML.LineasCelulares();
                            linea.MobileLineId = Convert.ToInt32(llamadaItem.MobileLineId.ToString());
                            linea.MobileLine = llamadaItem.MobileLine.ToString();
                            linea.Description = llamadaItem.Description.ToString();
                            result.Objects.Add(linea);
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
