using Dapper;
using WebAPI.Models;
using System.Data.SqlClient;

namespace WebAPI.Repository
{
    public class ClienteRepository
    {
        Conexao connData = new Conexao();

        public List<Cliente> selectCliente(int? id = null)
        {
            try
            {
                List<Cliente> listResult = new List<Cliente>();

                string query = @"SELECT * 
                                    FROM Cliente 
                                WHERE Id = COALESCE(@id, id);";

                using (SqlConnection connection = new SqlConnection(connData.ConnectionPath))
                {
                    listResult = connection.Query<Cliente>(query, new { id }).ToList();
                }
                return listResult;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool insertCliente(Cliente clienteUpdate)
        {
            try
            {
                bool retorno = false;

                string query = @"INSERT INTO Cliente 
                                    (CPF, Nome, RG, Data_Expedicao, Orgao_expedicao, Data_Nasc, Genero, 
                                     Estado_Civil, CEP, Logadouro, Numero, Complemento, Bairro, Cidade, UF)
                                    VALUES 
                                    (@CPF, @Nome, @RG, @Data_Expedicao, @Orgao_Expedicao, @Data_Nasc, @Genero,
                                     @Estado_Civil, @CEP, @Logadouro, @Numero, @Complemento, @Bairro, @Cidade, @UF);";

                using (SqlConnection connection = new SqlConnection(connData.ConnectionPath))
                {
                    connection.Query<Cliente>(query, clienteUpdate).ToList();
                    retorno = true;
                }
                return retorno;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool deleteCliente(int id)
        {
            try
            {
                bool retorno = false;

                string query = @"DELETE FROM Cliente 
                                    WHERE Id = @id;";

                using (SqlConnection connection = new SqlConnection(connData.ConnectionPath))
                {
                    connection.Query<Cliente>(query, new { id }).ToList();
                    retorno = true;
                }
                return retorno;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool updateCliente(Cliente clienteUpdate)
        {
            try
            {
                bool retorno = false;

                string query = @"UPDATE Cliente 
                                    SET 
                                    CPF = @CPF,
                                    Nome = @Nome,
                                    RG = @RG,
                                    Data_Expedicao = @Data_Expedicao,
                                    Orgao_expedicao = @Orgao_Expedicao,
                                    Data_Nasc = @Data_Nasc,
                                    Genero = @Genero,
                                    Estado_Civil = @Estado_Civil,
                                    CEP = @CEP,
                                    Logadouro = @Logadouro,
                                    Numero = @Numero,
                                    Complemento = @Complemento,
                                    Bairro = @Bairro,
                                    Cidade = @Cidade,
                                    UF = @UF
                                 WHERE Id = @id;";

                using (SqlConnection connection = new SqlConnection(connData.ConnectionPath))
                {
                    connection.Query<Cliente>(query, clienteUpdate).ToList();
                    retorno = true;
                }
                return retorno;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}