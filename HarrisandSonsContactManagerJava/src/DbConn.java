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
	
}
