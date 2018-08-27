package diccionario;

import database.accessDatabase;
import java.io.BufferedReader;
import java.io.IOException;
import java.io.InputStreamReader;
import java.util.logging.Level;
import java.util.logging.Logger;

public class Diccionario {

    public static void main(String[] args) {
        accessDatabase db = new accessDatabase();
        if(db.connDatabase()){
            try {
                InputStreamReader isr = new InputStreamReader(System.in);
                BufferedReader br = new BufferedReader (isr);
                System.out.println("Digite una palabra");
                String palabra = br.readLine();
                String response = db.selectPalabra(palabra);
                if(response.length() == 0){
                    System.out.print("\033[H\033[2J");
                    System.out.flush();
                    System.out.println("Palabra no encontrada ¿desea registrarla? (si=1 / no=0)");
                    String addPalabra = br.readLine();
                    if("1".equals(addPalabra)){
                        System.out.println("Digite la definición para la palabra: " + palabra);
                        String defincion = br.readLine();
                        db.insertPalabra(palabra, defincion);
                        System.out.println("La palabra " + palabra+", fue agregada existosamente");
                    }else{
                        System.out.println("Perfecto, feliz resto de dia");
                    }
                }else{
                    System.out.flush();
                    System.out.println("Definición: "+response);
                }
            } catch (IOException ex) {
                Logger.getLogger(Diccionario.class.getName()).log(Level.SEVERE, null, ex);
            }
        }else{
            System.out.println("No se encuentra conectado a la BD");
        }
    }
  
}
