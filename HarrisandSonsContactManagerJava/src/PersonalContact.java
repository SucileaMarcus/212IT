import java.awt.BorderLayout;
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
	private JTable table;
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
		scrollPane.setBounds(53, 92, 483, 220);
		contentPane.add(scrollPane);
				
		table = new JTable();
		scrollPane.setViewportView(table);
		DbConn d = new DbConn();		
		JButton btnRefresh = new JButton("Refresh");
		btnRefresh.addActionListener(new ActionListener() {
			public void actionPerformed(ActionEvent e) {
			}
		});
		btnRefresh.addMouseListener(new MouseAdapter() {
			@Override
			public void mouseClicked(MouseEvent e) {
				
				table.setModel(DbUtils.resultSetToTableModel(d.GetAllPersonal()));
			}
		});
		
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
		
		JButton btnNewButton = new JButton("New button");
		
		JButton btnNewButton_1 = new JButton("New button");
		
		JButton btnNewButton_2 = new JButton("New button");
		
		JButton btnNewButton_3 = new JButton("New button");
		
		JButton btnNewButton_4 = new JButton("New button");
		GroupLayout gl_contentPane = new GroupLayout(contentPane);
		gl_contentPane.setHorizontalGroup(
			gl_contentPane.createParallelGroup(Alignment.LEADING)
				.addGroup(gl_contentPane.createSequentialGroup()
					.addGroup(gl_contentPane.createParallelGroup(Alignment.LEADING)
						.addGroup(gl_contentPane.createSequentialGroup()
							.addGap(60)
							.addGroup(gl_contentPane.createParallelGroup(Alignment.TRAILING)
								.addGroup(gl_contentPane.createParallelGroup(Alignment.LEADING)
									.addComponent(lblNewLabel)
									.addComponent(lblLastName, GroupLayout.PREFERRED_SIZE, 51, GroupLayout.PREFERRED_SIZE))
								.addComponent(lblEmail, GroupLayout.PREFERRED_SIZE, 51, GroupLayout.PREFERRED_SIZE))
							.addPreferredGap(ComponentPlacement.UNRELATED)
							.addGroup(gl_contentPane.createParallelGroup(Alignment.LEADING)
								.addComponent(tbLname, GroupLayout.PREFERRED_SIZE, GroupLayout.DEFAULT_SIZE, GroupLayout.PREFERRED_SIZE)
								.addComponent(tbFname, GroupLayout.PREFERRED_SIZE, GroupLayout.DEFAULT_SIZE, GroupLayout.PREFERRED_SIZE)
								.addComponent(tbEmail, GroupLayout.PREFERRED_SIZE, GroupLayout.DEFAULT_SIZE, GroupLayout.PREFERRED_SIZE))
							.addPreferredGap(ComponentPlacement.RELATED)
							.addGroup(gl_contentPane.createParallelGroup(Alignment.LEADING)
								.addComponent(lblAddress, GroupLayout.PREFERRED_SIZE, 51, GroupLayout.PREFERRED_SIZE)
								.addComponent(lblNewLabel_1_1, GroupLayout.PREFERRED_SIZE, 51, GroupLayout.PREFERRED_SIZE)
								.addComponent(lblNewLabel_1_1_1, GroupLayout.PREFERRED_SIZE, 51, GroupLayout.PREFERRED_SIZE))
							.addGap(9)
							.addGroup(gl_contentPane.createParallelGroup(Alignment.TRAILING)
								.addComponent(tbAddress2, GroupLayout.PREFERRED_SIZE, GroupLayout.DEFAULT_SIZE, GroupLayout.PREFERRED_SIZE)
								.addComponent(tbAddress1, GroupLayout.PREFERRED_SIZE, GroupLayout.DEFAULT_SIZE, GroupLayout.PREFERRED_SIZE)
								.addComponent(tbCity, GroupLayout.PREFERRED_SIZE, GroupLayout.DEFAULT_SIZE, GroupLayout.PREFERRED_SIZE))
							.addPreferredGap(ComponentPlacement.RELATED)
							.addGroup(gl_contentPane.createParallelGroup(Alignment.LEADING)
								.addComponent(lblNewLabel_1_2, GroupLayout.PREFERRED_SIZE, 51, GroupLayout.PREFERRED_SIZE)
								.addComponent(lblNewLabel_1_2_1, GroupLayout.PREFERRED_SIZE, 59, GroupLayout.PREFERRED_SIZE))
							.addPreferredGap(ComponentPlacement.RELATED)
							.addGroup(gl_contentPane.createParallelGroup(Alignment.LEADING)
								.addComponent(tbPostCode, GroupLayout.PREFERRED_SIZE, GroupLayout.DEFAULT_SIZE, GroupLayout.PREFERRED_SIZE)
								.addComponent(tbTelNumber, GroupLayout.PREFERRED_SIZE, GroupLayout.DEFAULT_SIZE, GroupLayout.PREFERRED_SIZE))
							.addGap(18)
							.addGroup(gl_contentPane.createParallelGroup(Alignment.LEADING)
								.addGroup(gl_contentPane.createSequentialGroup()
									.addComponent(btnNewButton)
									.addPreferredGap(ComponentPlacement.RELATED, GroupLayout.DEFAULT_SIZE, Short.MAX_VALUE)
									.addComponent(btnNewButton_3))
								.addGroup(gl_contentPane.createSequentialGroup()
									.addComponent(btnNewButton_1)
									.addPreferredGap(ComponentPlacement.RELATED)
									.addComponent(btnNewButton_4))
								.addComponent(btnNewButton_2)))
						.addGroup(gl_contentPane.createSequentialGroup()
							.addGap(25)
							.addGroup(gl_contentPane.createParallelGroup(Alignment.TRAILING)
								.addComponent(btnRefresh)
								.addComponent(scrollPane, GroupLayout.PREFERRED_SIZE, 670, GroupLayout.PREFERRED_SIZE))))
					.addContainerGap())
		);
		gl_contentPane.setVerticalGroup(
			gl_contentPane.createParallelGroup(Alignment.LEADING)
				.addGroup(gl_contentPane.createSequentialGroup()
					.addGap(23)
					.addGroup(gl_contentPane.createParallelGroup(Alignment.BASELINE)
						.addComponent(lblNewLabel)
						.addComponent(tbFname, GroupLayout.PREFERRED_SIZE, GroupLayout.DEFAULT_SIZE, GroupLayout.PREFERRED_SIZE)
						.addComponent(tbAddress1, GroupLayout.PREFERRED_SIZE, GroupLayout.DEFAULT_SIZE, GroupLayout.PREFERRED_SIZE)
						.addComponent(lblAddress)
						.addComponent(lblNewLabel_1_2)
						.addComponent(tbPostCode, GroupLayout.PREFERRED_SIZE, GroupLayout.DEFAULT_SIZE, GroupLayout.PREFERRED_SIZE)
						.addComponent(btnNewButton)
						.addComponent(btnNewButton_3))
					.addPreferredGap(ComponentPlacement.UNRELATED)
					.addGroup(gl_contentPane.createParallelGroup(Alignment.LEADING)
						.addGroup(gl_contentPane.createSequentialGroup()
							.addGroup(gl_contentPane.createParallelGroup(Alignment.BASELINE)
								.addComponent(lblLastName)
								.addComponent(tbLname, GroupLayout.PREFERRED_SIZE, GroupLayout.DEFAULT_SIZE, GroupLayout.PREFERRED_SIZE)
								.addComponent(tbAddress2, GroupLayout.PREFERRED_SIZE, GroupLayout.DEFAULT_SIZE, GroupLayout.PREFERRED_SIZE)
								.addComponent(lblNewLabel_1_1)
								.addComponent(lblNewLabel_1_2_1)
								.addComponent(tbTelNumber, GroupLayout.PREFERRED_SIZE, GroupLayout.DEFAULT_SIZE, GroupLayout.PREFERRED_SIZE))
							.addPreferredGap(ComponentPlacement.UNRELATED)
							.addGroup(gl_contentPane.createParallelGroup(Alignment.BASELINE)
								.addComponent(tbEmail, GroupLayout.PREFERRED_SIZE, GroupLayout.DEFAULT_SIZE, GroupLayout.PREFERRED_SIZE)
								.addComponent(lblEmail)
								.addComponent(tbCity, GroupLayout.PREFERRED_SIZE, GroupLayout.DEFAULT_SIZE, GroupLayout.PREFERRED_SIZE)
								.addComponent(lblNewLabel_1_1_1))
							.addPreferredGap(ComponentPlacement.RELATED, 42, Short.MAX_VALUE)
							.addComponent(btnRefresh))
						.addGroup(gl_contentPane.createSequentialGroup()
							.addGroup(gl_contentPane.createParallelGroup(Alignment.BASELINE)
								.addComponent(btnNewButton_1)
								.addComponent(btnNewButton_4))
							.addPreferredGap(ComponentPlacement.UNRELATED)
							.addComponent(btnNewButton_2)))
					.addPreferredGap(ComponentPlacement.RELATED)
					.addComponent(scrollPane, GroupLayout.PREFERRED_SIZE, 157, GroupLayout.PREFERRED_SIZE)
					.addContainerGap())
		);
		
		table = new JTable();
		scrollPane.setViewportView(table);
		contentPane.setLayout(gl_contentPane);
	}
}
