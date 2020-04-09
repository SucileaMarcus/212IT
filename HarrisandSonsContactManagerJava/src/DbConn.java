import java.sql.DriverManager;
import java.sql.ResultSet;
import java.sql.SQLException;
import javax.swing.table.TableModel;
import com.mysql.cj.jdbc.CallableStatement;
import java.sql.Connection;

public class DbConn {
	
	String connString = "jdbc:mysql://it212db.c4zu499kghzi.us-east-1.rds.amazonaws.com/HarrisandSonsContactsDb";
	String username = "admin";
	String password = "Heemiola123!";
	java.sql.Connection conn = null;
	
	public DbConn() {
		try {
			conn = DriverManager.getConnection(connString,username,password);
			System.out.println("Connected!");
		} catch (SQLException e) {
			// TODO Auto-generated catch block
			e.printStackTrace();
			System.out.println("Not Connected!");
		}
	}
	
	public ResultSet GetAllPersonal() {
		ResultSet rs = null;
		String sql = "{CALL selectAllPersonal()}";
		try {
			java.sql.CallableStatement cst = conn.prepareCall(sql);
			rs=cst.executeQuery();
		} catch (SQLException e) {
			// TODO Auto-generated catch block
			e.printStackTrace();
		}
		return rs;	
	}
	
	public void UpdatePersonal(String Fname, String Lname, String Email, String Address1, String Address2, String PostCode, String City, String TelNumber, int id) {
		ResultSet rs = null;
		String sql = "{CALL updatePersonal(?,?,?,?,?,?,?,?,?)}";
		try {
			java.sql.CallableStatement cst = conn.prepareCall(sql);		
			cst.setInt(1, id);
			cst.setString(2, Fname);
			cst.setString(3, Lname);
			cst.setString(4, Email);
			cst.setString(5, Address1);
			cst.setString(6, Address2);
			cst.setString(7, PostCode);
			cst.setString(8, City);
			cst.setString(9, TelNumber);
			rs=cst.executeQuery();
		} catch (SQLException e) {
			// TODO Auto-generated catch block
			e.printStackTrace();
		}
	}
	
}
