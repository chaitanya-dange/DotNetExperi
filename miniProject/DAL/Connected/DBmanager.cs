
namespace DAL;
using BOL;
using MySql.Data;
using MySql.Data.MySqlClient;

public class DBmanager {
    public static string conString=@"server=localhost;port=3306;user=root;password=9420012844;database=transflower";


    // to see all the data from tables;
    public static List<Department> GetAllDepartments(){
        List<Department> allDepartment= new List<Department>();
        // STEP 01:
            MySqlConnection con=new MySqlConnection();
            con.ConnectionString=conString;

            con.Open();
            //STEP 02:
             // fire query to database
              string query="select * from departments";
            MySqlCommand cmd= new MySqlCommand(query,con);

            //STEP03:
          
            MySqlDataReader reader=cmd.ExecuteReader();

            while(reader.Read()){
                // taking data from database and then saving into variable and making that variable into new instance..
                int id= int.Parse(reader["id"].ToString());   // the value inside reader should match exactly with table name in mysql.
                string name=reader["name"].ToString();
                string location =reader["location"].ToString();

                Department dept= new Department{
                    Id=id,
                    Name=name,
                    Location=location
                };
                allDepartment.Add(dept);
            }

            con.Close();


        return allDepartment;
        
    }

    // get department details form id

  public static Department GetDepartmentDetails(int id){
     Department dept=null;
    MySqlConnection con =new MySqlConnection();
    con.ConnectionString=conString;
    con.Open();

    string query="select * from departments where id="+1;
    MySqlCommand cmd=new MySqlCommand(query,con);
    MySqlDataReader reader= cmd.ExecuteReader();

    if(reader.Read()){
         id=int.Parse(reader["id"].ToString());
        string name=reader["name"].ToString();
        String location=reader["location"].ToString();

        dept = new Department{
            Id=id,
            Name=name,
            Location=location
        };
        
    }
    

    con.Close(); 
    Console.WriteLine(dept.Id);
    return dept;
  

  }

  public static void InsertData(Department dept){
   
    

    string query="insert into departments(id,name,location) values('" +dept.Id+ "','" + dept.Name+"','"+dept.Location+" ')";

    MySqlConnection conn= new MySqlConnection();
    conn.ConnectionString=conString;
    conn.Open();

    MySqlCommand cmd= new MySqlCommand(query,conn);
    cmd.ExecuteNonQuery();// DML command
    Console.WriteLine(dept.Name);
    Console.WriteLine("added successfully");
    

    conn.Close();

    
    

}

public static void DeleteData(int id){
    string query="delete from departments where id="+id;
    MySqlConnection con= new MySqlConnection();
    con.ConnectionString= conString;
     
     con.Open();

    MySqlCommand cmd= new MySqlCommand(query,con);
    cmd.ExecuteNonQuery();
    Console.WriteLine("deleted successfully");


    con.Close();

}




}


