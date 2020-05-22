using Microsoft.Ajax.Utilities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using labo_n1.Models;
using System.Web.UI.WebControls;

namespace labo_n1.Controllers
{
    public class FilmsController : Controller
    {
        string chaineConnexion = @"Data Source=(LocalDb)\MSSQLLocalDB;Initial Catalog=BDFilms;Integrated Security=true";
        // GET: Films
        public ActionResult Index()
        {
            DataTable tabFilms = new DataTable();
            using (SqlConnection con = new SqlConnection(chaineConnexion))
            {
                con.Open();
                SqlDataAdapter adp = new SqlDataAdapter("SELECT * FROM Films", con);
                adp.Fill(tabFilms);
            }
            return View(tabFilms);
        }

        // GET: Films/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Films/Create
        public ActionResult Create()
        {
            return View(new Film());
        }

        // POST: Films/Create
        [HttpPost]
        public ActionResult Create(Film film)
        {
            try
            {

                using (SqlConnection con = new SqlConnection(chaineConnexion))
                {
                    con.Open();
                    string requete = "INSERT INTO films VALUES(@Titre, @Duree, @Realisateur, @Categorie)";
                    SqlCommand cmd = new SqlCommand(requete, con);
                    cmd.Parameters.AddWithValue("@Titre", film.Titre);
                    cmd.Parameters.AddWithValue("@Duree", film.Duree);
                    cmd.Parameters.AddWithValue("@Realisateur", film.Realisateur);
                    cmd.Parameters.AddWithValue("@Categorie", film.Categorie.ToString());
                    cmd.ExecuteNonQuery();
                }

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Films/Edit/5
        public ActionResult Edit(int id)
        {
            Film film = new Film();
            DataTable tabFilms = new DataTable();
            using (SqlConnection con = new SqlConnection(chaineConnexion))
            {
                con.Open();
                string requete = "SELECT * FROM films WHERE Id =@Id";
                SqlDataAdapter sda = new SqlDataAdapter(requete, con);
                sda.SelectCommand.Parameters.AddWithValue("@Id", id);
                sda.Fill(tabFilms);
            }
            if (tabFilms.Rows.Count == 1)
            {
                film.Id = Convert.ToInt32(tabFilms.Rows[0][0].ToString());
                film.Titre = tabFilms.Rows[0][1].ToString();
                film.Duree = Convert.ToInt32(tabFilms.Rows[0][2].ToString());
                film.Realisateur = tabFilms.Rows[0][3].ToString();
                return View(film);
            }
            else
            {
                return RedirectToAction("Index");
            }
        }

        // POST: Films/Edit/5
        [HttpPost]
        public ActionResult Edit(Film film)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(chaineConnexion))
                {
                    con.Open();
                    string requete = "UPDATE films SET Titre=@Titre, Duree=@Duree, Realisateur=@Realisateur, Categorie=@Categorie  WHERE Id=@Id";
                    SqlCommand cmd = new SqlCommand(requete, con);
                    cmd.Parameters.AddWithValue("@Id", film.Id);
                    cmd.Parameters.AddWithValue("@Titre", film.Titre);
                    cmd.Parameters.AddWithValue("@Duree", film.Duree);
                    cmd.Parameters.AddWithValue("@Realisateur", film.Realisateur);
                    cmd.Parameters.AddWithValue("@Categorie", film.Categorie.ToString());
                    cmd.ExecuteNonQuery();
                }

                    return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Films/Delete/5
        public ActionResult Delete(int id)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(chaineConnexion))
                {
                    con.Open();
                    string requete = "DELETE FROM films WHERE Id=@Id";
                    SqlCommand cmd = new SqlCommand(requete, con);
                    cmd.Parameters.AddWithValue("@Id", id);
                    cmd.ExecuteNonQuery();
                }
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // POST: Films/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
