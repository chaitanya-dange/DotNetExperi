namespace BLL;
using BOL;
using DAL;
public class CatalogManager
{
    public List<Department> GetAllDepartment(){
        List<Department> allDepartment= new List<Department>();
        allDepartment=DBmanager.GetAllDepartments();
        return allDepartment;
    }

     public Department GetDepartmentDetail(int id){
       
        Department deptDisplay=DBmanager.GetDepartmentDetails( id);
        
       
        return deptDisplay;
    }

    public void Insert(Department dept){
        DBmanager.InsertData(dept);
       }


     public void Delete(int id){
        DBmanager.DeleteData(id);
     }  



}
