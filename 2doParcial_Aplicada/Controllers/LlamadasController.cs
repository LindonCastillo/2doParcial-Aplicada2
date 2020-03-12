using _2doParcial_Aplicada.Data;
using _2doParcial_Aplicada.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace _2doParcial_Aplicada.Controllers
{
    public class LlamadasController
    {

        public bool Guardar(LLamadas llamada)
        {
            Contexto db = new Contexto();
            bool paso = false;

            try
            {
                if(db.Llamadas.Any(A => A.LlamadaId == llamada.LlamadaId))
                {
                    paso = Modificar(llamada);
                }
                else
                {
                    paso = Insertar(llamada);
                }
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                db.Dispose();
            }
            return paso;
        }
        
        public bool Insertar(LLamadas llamadas)
        {
            Contexto db = new Contexto();
            bool paso = false;
            try
            {
                db.Llamadas.Add(llamadas);
                paso = db.SaveChanges() > 0;
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                db.Dispose();
            }
            return paso;
        }

        public bool  Modificar(LLamadas llamada)
        {
            Contexto db = new Contexto();
            bool paso = false;

            try
            {
                var anterior = Buscar(llamada.LlamadaId);

                foreach (var item in llamada.Detalle)
                {
                    if(item.Id == 0)
                    {
                        db.Entry(item).State = EntityState.Added;
                    }
                }

                foreach (var item in anterior.Detalle)
                {
                    if(!llamada.Detalle.Any(A => A.Id == item.Id))
                    {
                        db.Entry(item).State = EntityState.Deleted;
                    }
                }


                db.Entry(llamada).State = EntityState.Modified;
                paso = db.SaveChanges() > 0;
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                db.Dispose();
            }

            return paso;
        }

        public bool Eliminar(int id)
        {
            Contexto db = new Contexto();
            bool paso = false;

            try
            {
                var eliminar = db.Llamadas.Find(id);
                db.Entry(eliminar).State = EntityState.Deleted;
                paso = db.SaveChanges() > 0; ;
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                db.Dispose();
            }
            return paso;
        }

        public LLamadas Buscar(int id)
        {
            Contexto db = new Contexto();
            LLamadas lLamadas;

            try
            {
                lLamadas = db.Llamadas.Where(A => A.LlamadaId == id).Include(A => A.Detalle).FirstOrDefault();
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                db.Dispose();
            }

            return lLamadas;
        }

        public List<LLamadas> GetList(Expression<Func<LLamadas,bool>>expression)
        {
            Contexto db = new Contexto();
            List<LLamadas> lista = new List<LLamadas>();

            try
            {
                lista = db.Llamadas.Where(expression).ToList();
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                db.Dispose();
            }

            return lista;
        }
    }
}
