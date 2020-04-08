import java.awt.EventQueue;

import javax.swing.JFrame;
import javax.swing.JButton;
import java.awt.BorderLayout;
import java.awt.event.MouseAdapter;
import java.awt.event.MouseEvent;

public class ContactManager {

	private JFrame frame;

	/**
	 * Launch the application.
	 */
	public static void main(String[] args) {
		EventQueue.invokeLater(new Runnable() {
			public void run() {
				try {
					ContactManager window = new ContactManager();
					window.frame.setVisible(true);
				} catch (Exception e) {
					e.printStackTrace();
				}
			}
		});
	}

	/**
	 * Create the application.
	 */
	public ContactManager() {
		initialize();
	}

	/**
	 * Initialize the contents of the frame.
	 */
	private void initialize() {
		frame = new JFrame();
		frame.setBounds(100, 100, 664, 351);
		frame.setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
		frame.getContentPane().setLayout(null);
		
		JButton btnBusinessContact = new JButton("Business Contact");
		btnBusinessContact.setBounds(350, 91, 148, 23);
		frame.getContentPane().add(btnBusinessContact);
		
		JButton btnPersonalContact = new JButton("Personal Contact");
		btnPersonalContact.addMouseListener(new MouseAdapter() {
			@Override
			public void mouseClicked(MouseEvent e) {				
				PersonalContact personalContact = new PersonalContact();
				frame.dispose();
				personalContact.setVisible(true);
				
			}
		});
		btnPersonalContact.setBounds(151, 91, 130, 23);
		frame.getContentPane().add(btnPersonalContact);
	}
}
