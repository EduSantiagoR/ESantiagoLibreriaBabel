using Microsoft.EntityFrameworkCore;

namespace BL
{
    public class Libro
    {
        public static ML.Result GetAll()
        {
            ML.Result result = new ML.Result();
            try
            {
                using(DL.ESantiagoBibliotecaBabelContext context = new DL.ESantiagoBibliotecaBabelContext())
                {
                    var query = (from libro in context.Libros
                                 join ubicacion in context.Ubicacions on libro.IdUbicacion equals ubicacion.IdUbicacion
                                 select new
                                 {
                                     IdLibro = libro.IdLibro,
                                     Titulo = libro.Titulo,
                                     Volumen = libro.Volumen,
                                     IdUbicacion = ubicacion.IdUbicacion,
                                     Sala = ubicacion.Sala,
                                     Librero = ubicacion.Librero,
                                     Estante = ubicacion.Estante,
                                     Posicion = ubicacion.Posicion
                                 }).ToList();
                    if(query != null)
                    {
                        result.Objtecs = new List<object>();
                        foreach(var item in query)
                        {
                            ML.Libro libro = new ML.Libro();
                            libro.Ubicacion = new ML.Ubicacion();

                            libro.IdLibro = item.IdLibro;
                            libro.Titulo = item.Titulo;
                            libro.Volumen = item.Volumen;
                            libro.Ubicacion.IdUbicacion = item.IdUbicacion;
                            libro.Ubicacion.Sala = item.Sala;
                            libro.Ubicacion.Librero = item.Librero;
                            libro.Ubicacion.Estante = item.Estante;
                            libro.Ubicacion.Posicion = item.Posicion;

                            result.Objtecs.Add(libro);
                        }
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.Message = "Error al recuperar los libros.";
                    }
                }
            }
            catch(Exception ex)
            {
                result.Correct = false;
                result.Message = ex.Message;
                result.Ex = ex;
            }
            return result;
        }
        public static ML.Result GetById(int idLibro)
        {
            ML.Result result = new ML.Result();
            try
            {
                using(DL.ESantiagoBibliotecaBabelContext context = new DL.ESantiagoBibliotecaBabelContext())
                {
                    var query = (from libro in context.Libros
                                 join ubicacion in context.Ubicacions on libro.IdUbicacion equals ubicacion.IdUbicacion
                                 where libro.IdLibro == idLibro
                                 select new
                                 {
                                     IdLibro = libro.IdLibro,
                                     Titulo = libro.Titulo,
                                     Volumen = libro.Volumen,
                                     IdUbicacion = ubicacion.IdUbicacion,
                                     Sala = ubicacion.Sala,
                                     Librero = ubicacion.Librero,
                                     Estante = ubicacion.Estante,
                                     Posicion = ubicacion.Posicion
                                 }).AsEnumerable().FirstOrDefault();
                    if(query != null)
                    {
                        result.Object = new object();
                        ML.Libro libro = new ML.Libro();
                        libro.Ubicacion = new ML.Ubicacion();

                        libro.IdLibro = query.IdLibro;
                        libro.Titulo = query.Titulo;
                        libro.Volumen = query.Volumen;
                        libro.Ubicacion.IdUbicacion = query.IdUbicacion;
                        libro.Ubicacion.Sala = query.Sala;
                        libro.Ubicacion.Librero = query.Librero;
                        libro.Ubicacion.Estante = query.Estante;
                        libro.Ubicacion.Posicion = query.Posicion;

                        result.Object = libro;
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.Message = "Error al consultar el libro.";
                    }
                }
            }
            catch(Exception ex)
            {
                result.Correct = false;
                result.Message = ex.Message;
                result.Ex = ex;
            }
            return result;
        }
        public static ML.Result Add(ML.Libro libro)
        {
            ML.Result result = new ML.Result();
            try
            {
                using(DL.ESantiagoBibliotecaBabelContext context = new DL.ESantiagoBibliotecaBabelContext())
                {
                    int rowsAffected = context.Database.ExecuteSqlRaw($"LibroAdd '{libro.Titulo}','{libro.Volumen}','{libro.Ubicacion.Sala}','{libro.Ubicacion.Librero}','{libro.Ubicacion.Estante}','{libro.Ubicacion.Posicion}'");
                    if(rowsAffected > 0)
                    {
                        result.Correct = true;
                        result.Message = "Libro agregado correctamente.";
                    }
                    else
                    {
                        result.Correct = false;
                        result.Message = "Error al agregar el libro.";
                    }
                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.Message = ex.Message;
                result.Ex = ex;
            }
            return result;
        }
        public static ML.Result Update(ML.Libro libro)
        {
            ML.Result result = new ML.Result();
            try
            {
                using(DL.ESantiagoBibliotecaBabelContext context = new DL.ESantiagoBibliotecaBabelContext())
                {
                    int rowsAffected = context.Database.ExecuteSqlRaw($"LibroUpdate {libro.IdLibro},'{libro.Titulo}','{libro.Volumen}','{libro.Ubicacion.Sala}','{libro.Ubicacion.Librero}','{libro.Ubicacion.Estante}','{libro.Ubicacion.Posicion}'");
                    if (rowsAffected > 0)
                    {
                        result.Correct = true;
                        result.Message = "Libro actualizado correctamente.";
                    }
                    else
                    {
                        result.Correct = false;
                        result.Message = "Error al actualizar el libro.";
                    }
                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.Message = ex.Message;
                result.Ex = ex;
            }
            return result;
        }
        public static ML.Result Delete(int idLibro)
        {
            ML.Result result = new ML.Result();
            try
            {
                using(DL.ESantiagoBibliotecaBabelContext context = new DL.ESantiagoBibliotecaBabelContext())
                {
                    int rowsAffected = context.Database.ExecuteSqlRaw($"LibroDelete {idLibro}");
                    if (rowsAffected > 0)
                    {
                        result.Correct = true;
                        result.Message = "Libro eliminado correctamente.";
                    }
                    else
                    {
                        result.Correct = false;
                        result.Message = "Error al eliminar el libro.";
                    }
                }
            }
            catch(Exception ex)
            {
                result.Correct = false;
                result.Message = ex.Message;
                result.Ex = ex;
            }
            return result;
        }
    }
}