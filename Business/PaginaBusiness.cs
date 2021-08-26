using Database;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public class PaginaBusiness
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Conteudo { get; set; }
        public DateTime Data { get; set; }

        public List<PaginaBusiness> Lista()
        {
            var lista = new List<PaginaBusiness>();
            var paginaDb = new PaginaDb();
            foreach (DataRow row in paginaDb.Lista().Rows)
            {
                var pagina = new PaginaBusiness();
                pagina.Id = Convert.ToInt32(row["id"]);
                pagina.Nome = row["nome"].ToString();
                pagina.Conteudo = row["conteudo"].ToString();
                pagina.Data = Convert.ToDateTime(row["data"]);

                lista.Add(pagina);
            }

            return lista;
        }

   

        public static PaginaBusiness BuscarPorId(int id)
        {
            var pagina = new PaginaBusiness();
            var paginaDb = new PaginaDb();
            foreach (DataRow row in paginaDb.BuscaPorId(id).Rows)
            {
                pagina.Id = Convert.ToInt32(row["id"]);
                pagina.Nome = row["nome"].ToString();
                pagina.Conteudo = row["conteudo"].ToString();
                pagina.Data = Convert.ToDateTime(row["data"]);

            }
            return pagina;
        }

        public void Save()
        {
            new PaginaDb().Salvar(this.Id, this.Nome, this.Conteudo, this.Data);
        }

        public static void Excluir(int id)
        {
            new PaginaDb().Excluir(id);
        }
    }

}

