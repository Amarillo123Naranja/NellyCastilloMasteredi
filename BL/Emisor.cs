using Microsoft.EntityFrameworkCore;

namespace BL
{
    public class Emisor
    {

        public static ML.Result GetAll()
        {
            ML.Result result = new ML.Result();

            try
            {
                using (DL.NellyCastilloEmisorContext context = new DL.NellyCastilloEmisorContext())
                {
                    var query = context.Emisors.FromSqlRaw("EmisorGetAll").ToList();

                    result.Objects = new List<Object>();

                    if (query != null)
                    {
                        foreach (var registro in query)
                        {
                            ML.Emisor emisor = new ML.Emisor();

                            emisor.IdEmisor = registro.IdEmisor;

                            emisor.Rfc = registro.Rfc;

                            emisor.FechaInicioOperacion = Convert.ToDateTime(registro.FechaInicioOperacion);

                            emisor.Capital = registro.Capital.Value;

                            result.Objects.Add(emisor);

                        }

                        result.Correct = true;

                    }

                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "No se encontraron registros";
                    }

                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
                result.Ex = ex;


            }

            return result;
        }

        public static ML.Result Add(ML.Emisor emisor)
        {
            ML.Result result = new ML.Result();

            try
            {
                using (DL.NellyCastilloEmisorContext context = new DL.NellyCastilloEmisorContext())
                {
                    int filasAfectadas = context.Database.ExecuteSqlRaw($"EmisorAdd '{emisor.IdEmisor}', '{emisor.Rfc}', '{emisor.FechaInicioOperacion}', {emisor.Capital}");

                    if (filasAfectadas > 0)
                    {
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "Ocurrio un error al agregar";
                    }

                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
                result.Ex = ex;


            }

            return result;
        }

        public static ML.Result GetById(string IdEmisor)
        {
            ML.Result result = new ML.Result();

            try
            {
                using (DL.NellyCastilloEmisorContext context = new DL.NellyCastilloEmisorContext())
                {
                    var query = context.Emisors.FromSqlRaw($"EmisorGetById '{IdEmisor}'").AsEnumerable().SingleOrDefault();

                    result.Object = new List<Object>();

                    if (query != null)
                    {
                        ML.Emisor emisor = new ML.Emisor();

                        emisor.IdEmisor = query.IdEmisor;

                        emisor.Rfc = query.Rfc;

                        emisor.FechaInicioOperacion = Convert.ToDateTime(query.FechaInicioOperacion);

                        emisor.Capital = query.Capital.Value;

                        result.Object = (emisor);

                        result.Correct = true;

                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "Ocurrio un error al  consultar";
                    }


                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
                result.Ex = ex;

            }

            return result;
        }

    }
}