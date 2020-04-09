import java.awt.BorderLayout;
import java.awt.Component;
import java.awt.EventQueue;

import javax.swing.JFrame;
import javax.swing.JPanel;
import javax.swing.border.EmptyBorder;

import net.proteanit.sql.DbUtils;

import javax.swing.JScrollPane;
import javax.swing.JTable;
import javax.swing.GroupLayout;
import javax.swing.GroupLayout.Alignment;
import javax.swing.LayoutStyle.ComponentPlacement;
import javax.swing.JButton;
import javax.swing.JTextField;
import javax.swing.JLabel;
import java.awt.event.MouseAdapter;
import java.awt.event.MouseEvent;
import java.awt.event.ActionListener;
import java.awt.event.ActionEvent;

public class PersonalContact extends JFrame {

	
	private JPanel contentPane;
	private JTable table_Personal;
	private JTextField tbFname;
	private JTextField tbLname;
	private JTextField tbAddress1;
	private JTextField tbAddress2;
	private JTextField tbPostCode;
	private JTextField tbTelNumber;
	private JTextField tbEmail;
	private JTextField tbCity;

	/**
	 * Launch the application.
	 */
	public static void main(String[] args) {
		EventQueue.invokeLater(new Runnable() {
			public void run() {
				try {
					PersonalContact frame = new PersonalContact();
					frame.setVisible(true);
				} catch (Exception e) {
					e.printStackTrace();
				}
			}
		});
	}

	/**
	 * Create the frame.
	 */
	public PersonalContact() {
		setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
		setBounds(100, 100, 746, 396);
		contentPane = new JPanel();
		contentPane.setBorder(new EmptyBorder(5, 5, 5, 5));
		setContentPane(contentPane);
		
		JScrollPane scrollPane = new JScrollPane();
		scrollPane.addMouseListener(new MouseAdapter() {			
			@Override
			public void mousePressed(MouseEvent e) {
				
			}
		});
		scrollPane.setBounds(53, 92, 483, 220);
		contentPane.add(scrollPane);
		DbConn d = new DbConn();		
		
		
		tbFname = new JTextField();
		tbFname.setColumns(10);
		
		tbLname = new JTextField();
		tbLname.setColumns(10);
		
		tbAddress1 = new JTextField();
		tbAddress1.setColumns(10);
		
		tbAddress2 = new JTextField();
		tbAddress2.setColumns(10);
		
		tbPostCode = new JTextField();
		tbPostCode.setColumns(10);
		
		tbTelNumber = new JTextField();
		tbTelNumber.setColumns(10);
		
		tbEmail = new JTextField();
		tbEmail.setColumns(10);
		
		tbCity = new JTextField();
		tbCity.setColumns(10);
		
		JLabel lblNewLabel = new JLabel("First Name");
		
		JLabel lblLastName = new JLabel("Last Name");
		
		JLabel lblEmail = new JLabel("Email");
		
		JLabel lblAddress = new JLabel("Address 1");
		
		JLabel lblNewLabel_1_1 = new JLabel("Address 2");
		
		JLabel lblNewLabel_1_1_1 = new JLabel("City");
		
		JLabel lblNewLabel_1_2 = new JLabel("Post Code");
		
		JLabel lblNewLabel_1_2_1 = new JLabel("Tel Number");
		
		JButton btnUpdate = new JButton("Update");
		JButton btnRefresh = new JButton("Refresh");
		JButton btnAddNew = new JButton("Add New");
		JButton btnDelete = new JButton("Delete");
		JButton btnSaveSelected = new JButton("Save Selected");
		JButton btnSave = new JButton("Save");
		
		btnRefresh.addMouseListener(new MouseAdapter() {
			@Override
			public void mouseClicked(MouseEvent e) {
				table_Personal.setModel(DbUtils.resultSetToTableModel(d.GetAllPersonal()));
			}
		});		
		
		btnAddNew.addActionListener(new ActionListener() {
			public void actionPerformed(ActionEvent e) {
				btnUpdate.setEnabled(false);
				btnSaveSelected.setEnabled(false);
				btnSave.setEnabled(true);
				btnDelete.setEnabled(false);
				btnAddNew.setEnabled(false);
				
				
			}
		});		
		
		btnDelete.addActionListener(new ActionListener() {
			public void actionPerformed(ActionEvent e) {
			}
		});
				
		btnSaveSelected.addMouseListener(new MouseAdapter() {
			@Override
			public void mouseClicked(MouseEvent e) {
				String Fname = tbFname.getText();
				String Lname = tbLname.getText();
				String Email = tbEmail.getText();
				String Address1 = tbAddress1.getText();
				String Address2 = tbAddress2.getText();
				String PostCode = tbPostCode.getText();
				String City = tbCity.getText();
				String TelNumber = tbTelNumber.getText();
				int id = Integer.parseInt(table_Personal.getValueAt(table_Personal.getSelectedRow(), 0).toString());					
				d.UpdatePersonal(Fname, Lname, Email, Address1, Address2, PostCode, City, TelNumber, id);
				table_Personal.setModel(DbUtils.resultSetToTableModel(d.GetAllPersonal()));
			}
		});
		btnSaveSelected.addActionListener(new ActionListener() {
			public void actionPerformed(ActionEvent e) {
			}
		});
		btnSaveSelected.setEnabled(false);		
		
		btnSave.addActionListener(new ActionListener() {
			public void actionPerformed(ActionEvent e) {
			}
		});
		
		btnSave.setEnabled(false);
		
		
		btnUpdate.addMouseListener(new MouseAdapter() {
			@Override
			public void mouseClicked(MouseEvent e) {
				btnUpdate.setEnabled(false);
				btnAddNew.setEnabled(false);
				btnSave.setEnabled(false);
				btnDelete.setEnabled(false);
				btnSaveSelected.setEnabled(true);
				btnSave.setEnabled(false);
			
			}
		});

		table_Personal = new JTable();
		table_Personal.addMouseListener(new MouseAdapter() {
			@Override
			public void mousePressed(MouseEvent e) {
				tbFname.setText(table_Personal.getValueAt(table_Personal.getSelectedRow(),1).toString());
				tbLname.setText(table_Personal.getValueAt(table_Personal.getSelectedRow(),2).toString());
				tbEmail.setText(table_Personal.getValueAt(table_Personal.getSelectedRow(),3).toString());
				tbAddress1.setText(table_Personal.getValueAt(table_Personal.getSelectedRow(),4).toString());
				tbAddress2.setText(table_Personal.getValueAt(table_Personal.getSelectedRow(),5).toString());
				tbPostCode.setText(table_Personal.getValueAt(table_Personal.getSelectedRow(),6).toString());
				tbCity.setText(table_Personal.getValueAt(table_Personal.getSelectedRow(),7).toString());
				tbTelNumber.setText(table_Personal.getValueAt(table_Personal.getSelectedRow(),8).toString());
				
			}
		});
		scrollPane.setViewportView(table_Personal);
		
		
		GroupLayout gl_contentPane = new GroupLayout(contentPane);
		gl_contentPane.setHorizontalGroup(
			gl_contentPane.createParallelGroup(Alignment.LEADING)
				.addGroup(gl_contentPane.createSequentialGroup()
					.addGap(60)
					.addComponent(lblNewLabel, GroupLayout.DEFAULT_SIZE, GroupLayout.DEFAULT_SIZE, Short.MAX_VALUE)
					.addGap(10)
					.addComponent(tbFname, GroupLayout.DEFAULT_SIZE, 86, Short.MAX_VALUE)
					.addGap(4)
					.addComponent(lblAddress, GroupLayout.DEFAULT_SIZE, 51, Short.MAX_VALUE)
					.addGap(9)
					.addComponent(tbAddress1, GroupLayout.DEFAULT_SIZE, 86, Short.MAX_VALUE)
					.addGap(4)
					.addComponent(lblNewLabel_1_2, GroupLayout.DEFAULT_SIZE, 51, Short.MAX_VALUE)
					.addGap(12)
					.addComponent(tbPostCode, GroupLayout.DEFAULT_SIZE, 86, Short.MAX_VALUE)
					.addGap(18)
					.addComponent(btnUpdate, GroupLayout.DEFAULT_SIZE, 67, Short.MAX_VALUE)
					.addGap(14)
					.addComponent(btnSaveSelected, GroupLayout.DEFAULT_SIZE, 101, Short.MAX_VALUE)
					.addGap(10))
				.addGroup(gl_contentPane.createSequentialGroup()
					.addGap(60)
					.addComponent(lblLastName, GroupLayout.DEFAULT_SIZE, 51, Short.MAX_VALUE)
					.addGap(10)
					.addComponent(tbLname, GroupLayout.DEFAULT_SIZE, 86, Short.MAX_VALUE)
					.addGap(4)
					.addComponent(lblNewLabel_1_1, GroupLayout.DEFAULT_SIZE, 51, Short.MAX_VALUE)
					.addGap(9)
					.addComponent(tbAddress2, GroupLayout.DEFAULT_SIZE, 86, Short.MAX_VALUE)
					.addGap(4)
					.addComponent(lblNewLabel_1_2_1, GroupLayout.DEFAULT_SIZE, 59, Short.MAX_VALUE)
					.addGap(4)
					.addComponent(tbTelNumber, GroupLayout.DEFAULT_SIZE, 86, Short.MAX_VALUE)
					.addGap(18)
					.addComponent(btnAddNew, GroupLayout.DEFAULT_SIZE, 75, Short.MAX_VALUE)
					.addGap(6)
					.addComponent(btnSave, GroupLayout.DEFAULT_SIZE, 57, Short.MAX_VALUE)
					.addGap(54))
				.addGroup(Alignment.TRAILING, gl_contentPane.createSequentialGroup()
					.addGap(106)
					.addComponent(scrollPane, GroupLayout.DEFAULT_SIZE, 670, Short.MAX_VALUE)
					.addContainerGap())
				.addGroup(Alignment.TRAILING, gl_contentPane.createSequentialGroup()
					.addGap(60)
					.addComponent(lblEmail, GroupLayout.DEFAULT_SIZE, 51, Short.MAX_VALUE)
					.addGap(10)
					.addComponent(tbEmail, GroupLayout.DEFAULT_SIZE, 86, Short.MAX_VALUE)
					.addGap(4)
					.addComponent(lblNewLabel_1_1_1, GroupLayout.DEFAULT_SIZE, 51, Short.MAX_VALUE)
					.addGap(9)
					.addComponent(tbCity, GroupLayout.DEFAULT_SIZE, 86, Short.MAX_VALUE)
					.addGap(171)
					.addComponent(btnDelete, GroupLayout.DEFAULT_SIZE, 63, Short.MAX_VALUE)
					.addGap(129))
				.addGroup(Alignment.TRAILING, gl_contentPane.createSequentialGroup()
					.addContainerGap(639, Short.MAX_VALUE)
					.addComponent(btnRefresh)
					.addContainerGap())
		);
		gl_contentPane.setVerticalGroup(
			gl_contentPane.createParallelGroup(Alignment.LEADING)
				.addGroup(gl_contentPane.createSequentialGroup()
					.addGap(23)
					.addGroup(gl_contentPane.createParallelGroup(Alignment.LEADING, false)
						.addGroup(gl_contentPane.createSequentialGroup()
							.addGap(4)
							.addComponent(lblNewLabel))
						.addGroup(gl_contentPane.createSequentialGroup()
							.addGap(1)
							.addComponent(tbFname, GroupLayout.PREFERRED_SIZE, GroupLayout.DEFAULT_SIZE, GroupLayout.PREFERRED_SIZE))
						.addGroup(gl_contentPane.createSequentialGroup()
							.addGap(4)
							.addComponent(lblAddress))
						.addGroup(gl_contentPane.createSequentialGroup()
							.addGap(1)
							.addComponent(tbAddress1, GroupLayout.PREFERRED_SIZE, GroupLayout.DEFAULT_SIZE, GroupLayout.PREFERRED_SIZE))
						.addGroup(gl_contentPane.createSequentialGroup()
							.addGap(4)
							.addComponent(lblNewLabel_1_2))
						.addGroup(gl_contentPane.createSequentialGroup()
							.addGap(1)
							.addComponent(tbPostCode, GroupLayout.PREFERRED_SIZE, GroupLayout.DEFAULT_SIZE, GroupLayout.PREFERRED_SIZE))
						.addComponent(btnUpdate)
						.addComponent(btnSaveSelected))
					.addGap(11)
					.addGroup(gl_contentPane.createParallelGroup(Alignment.LEADING, false)
						.addGroup(gl_contentPane.createSequentialGroup()
							.addGap(3)
							.addComponent(lblLastName))
						.addComponent(tbLname, GroupLayout.PREFERRED_SIZE, GroupLayout.DEFAULT_SIZE, GroupLayout.PREFERRED_SIZE)
						.addGroup(gl_contentPane.createSequentialGroup()
							.addGap(3)
							.addComponent(lblNewLabel_1_1))
						.addComponent(tbAddress2, GroupLayout.PREFERRED_SIZE, GroupLayout.DEFAULT_SIZE, GroupLayout.PREFERRED_SIZE)
						.addGroup(gl_contentPane.createSequentialGroup()
							.addGap(3)
							.addComponent(lblNewLabel_1_2_1))
						.addComponent(tbTelNumber, GroupLayout.PREFERRED_SIZE, GroupLayout.DEFAULT_SIZE, GroupLayout.PREFERRED_SIZE)
						.addComponent(btnAddNew)
						.addComponent(btnSave))
					.addGap(8)
					.addGroup(gl_contentPane.createParallelGroup(Alignment.LEADING, false)
						.addGroup(gl_contentPane.createSequentialGroup()
							.addGap(3)
							.addComponent(lblEmail))
						.addGroup(gl_contentPane.createSequentialGroup()
							.addComponent(tbEmail, GroupLayout.PREFERRED_SIZE, GroupLayout.DEFAULT_SIZE, GroupLayout.PREFERRED_SIZE)
							.addPreferredGap(ComponentPlacement.RELATED, 6, Short.MAX_VALUE))
						.addGroup(gl_contentPane.createSequentialGroup()
							.addGap(3)
							.addComponent(lblNewLabel_1_1_1))
						.addGroup(gl_contentPane.createSequentialGroup()
							.addComponent(tbCity, GroupLayout.PREFERRED_SIZE, GroupLayout.DEFAULT_SIZE, GroupLayout.PREFERRED_SIZE)
							.addPreferredGap(ComponentPlacement.RELATED, 6, Short.MAX_VALUE))
						.addGroup(gl_contentPane.createSequentialGroup()
							.addPreferredGap(ComponentPlacement.RELATED, 3, Short.MAX_VALUE)
							.addComponent(btnDelete)))
					.addGap(24)
					.addComponent(btnRefresh)
					.addPreferredGap(ComponentPlacement.RELATED)
					.addComponent(scrollPane, GroupLayout.DEFAULT_SIZE, 180, Short.MAX_VALUE))
		);
		contentPane.setLayout(gl_contentPane);
	}
}
