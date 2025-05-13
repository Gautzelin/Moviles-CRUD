using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using jcorreaS5A.Models;
using Microsoft.Win32.SafeHandles;
using SQLite;

namespace jcorreaS5A.Repositories
{
    public class PersonRepository
    {
        string dbPath;
        private SQLiteConnection conn;

        public string statusMessage {  get; set; }

        public PersonRepository(string path)
        {
            dbPath = path;
        }

        private void Init()
        {
            if (conn is not null)
                return;
            conn = new (dbPath);
            conn.CreateTable<Persona>();
            
        }

        public void AddNewPerson(String name)
        {
            int result = 0;
            try
            {
                Init();
                if (string.IsNullOrEmpty(name))
                    throw new Exception("El nombre es requerido");

                Persona person = new() { Name=name};
                
                result = conn.Insert(person);
                statusMessage = string.Format("Dato Ingresado");
            }
            catch (Exception ex)
            {
                statusMessage = string.Format("Error "+ ex);
            }
        }

        public List<Persona> GetAllPerson()
        {
            try
            {
                Init();
                return conn.Table<Persona>().ToList();
            }
            catch (Exception ex)
            {

                statusMessage = string.Format("Error"+ex);
            }
            return new List<Persona>();
        }

        public void UpdatePerson(int id, string newName)
        {
            try
            {
                Init();
                var personToUpdate = conn.Table<Persona>().FirstOrDefault(p => p.Id == id);
                if (personToUpdate == null)
                    throw new Exception("Persona no encontrada");

                personToUpdate.Name = newName;
                conn.Update(personToUpdate);
                statusMessage = "Dato actualizado correctamente.";
            }
            catch (Exception ex)
            {
                statusMessage = $"Error: {ex.Message}";
            }
        }

        public void DeletePerson(int id)
        {
            try
            {
                Init();
                var personToDelete = conn.Table<Persona>().FirstOrDefault(p => p.Id == id);
                if (personToDelete == null)
                    throw new Exception("Persona no encontrada");

                conn.Delete(personToDelete);
                statusMessage = "Dato eliminado correctamente.";
            }
            catch (Exception ex)
            {
                statusMessage = $"Error: {ex.Message}";
            }
        }

    }
}
