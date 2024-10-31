using aBustillosS5B.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace aBustillosS5B.Utils
{
    public class PersonaRepository
    {
        string dbpath;
        private SQLiteConnection conn;
        public string status { get; set; }
        public PersonaRepository(string path)
        {
            dbpath = path;
        }

        public void Init()
        {
            if (conn is not null)
                return;
            conn = new(dbpath);
            conn.CreateTable<Persona>();
        }

        public void AddNewPerson(string name)
        {
            int result = 0;

            try
            {
                Init();
                if (string.IsNullOrEmpty(name))
                    throw new Exception("El nombre es requerido");

                Persona person = new() { Name = name };
                result = conn.Insert(person);
                status = string.Format("Dato ingresado");
            }
            catch (Exception)
            {
                status = string.Format("Error al Ingresar");
            }
        }

        public List<Persona> GetAllPerson()
        {
            List<Persona> personas = new List<Persona>();

            try
            {
                Init();
                personas =  conn.Table<Persona>().ToList();
            }
            catch (Exception)
            {
                status = string.Format("Error al Listar");
            }
            return personas;
        }

        //Update y Delete
    }
}
