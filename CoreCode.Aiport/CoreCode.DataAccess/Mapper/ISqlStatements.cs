using CoreCode.Entities.POJO;
using DataAccess.Dao;

namespace DataAccess.Mapper
{
    public interface ISqlStatements
    {
        SqlOperation GetCreateStatement(BaseEntity entity);
        SqlOperation GetRetrieveStatement(BaseEntity entity);
        SqlOperation GetRetrieveAllStatement();
        SqlOperation GetUpdateStatement(BaseEntity entity);
        SqlOperation GetDeleteStatement(BaseEntity entity);
    }
}