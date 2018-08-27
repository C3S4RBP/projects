package database;
import diccionario.Diccionario;
import java.sql.Connection;
import java.sql.DriverManager;
import java.sql.SQLException;
import java.util.List;
import java.util.logging.Level;
import java.util.logging.Logger;
import javax.persistence.EntityManager;
import javax.persistence.EntityManagerFactory;
import javax.persistence.Persistence;
import javax.persistence.TypedQuery;
import model.Palabras;

public class accessDatabase {
    
    public boolean connDatabase() {
        boolean response = false;
        Connection conn = null;
     
        String driver   = "com.mysql.jdbc.Driver";
        String db       = "diccionario";
        String url      = "jdbc:mysql://localhost/" + db;
        String user     = "root";
        String pass     = "Clave";
  
        try {
            try {
                Class.forName(driver);
            } catch (ClassNotFoundException ex) {
                Logger.getLogger(Diccionario.class.getName()).log(Level.SEVERE, null, ex);
            }
            conn = DriverManager.getConnection(url,user,pass);
            System.out.println("Connected to database : " + db);
            response = true;
        } catch (SQLException e) {
            System.out.println("SQLException: "+e.getMessage());
            System.out.println("SQLState: "+e.getSQLState());
            System.out.println("VendorError: "+e.getErrorCode());
        }
        return response;
    }
    
    public String selectPalabra(String in_palabra){
        String response = "";
        EntityManagerFactory emf = Persistence.createEntityManagerFactory("DiccionarioPU");
        EntityManager em = emf.createEntityManager();
        TypedQuery<Palabras> consultaPalabra = em.createNamedQuery("Palabras.findByPalabra", Palabras.class);
        consultaPalabra.setParameter("palabra",in_palabra);
        List<Palabras> lista= consultaPalabra.getResultList();
        for (Palabras a :lista) {
            response = a.getDefinición();
        }
        em.close();
        return response;
    }
    
    public void insertPalabra(String in_palabra, String in_definicion){
        EntityManagerFactory emf = Persistence.createEntityManagerFactory("DiccionarioPU");
        EntityManager em = emf.createEntityManager();
        Palabras palabra = new Palabras(in_palabra,in_definicion);
        em.getTransaction().begin();
        em.persist(palabra);
        em.getTransaction().commit();
    }
}
