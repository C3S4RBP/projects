/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package model;

import java.io.Serializable;
import javax.persistence.Basic;
import javax.persistence.Column;
import javax.persistence.Entity;
import javax.persistence.Id;
import javax.persistence.NamedQueries;
import javax.persistence.NamedQuery;
import javax.persistence.Table;
import javax.xml.bind.annotation.XmlRootElement;

/**
 *
 * @author cabejarano
 */
@Entity
@Table(name = "palabras")
@XmlRootElement
@NamedQueries({
    @NamedQuery(name = "Palabras.findAll", query = "SELECT p FROM Palabras p")
    , @NamedQuery(name = "Palabras.findByPalabra", query = "SELECT p FROM Palabras p WHERE p.palabra = :palabra")
    , @NamedQuery(name = "Palabras.findByDefinici\u00f3n", query = "SELECT p FROM Palabras p WHERE p.definici\u00f3n = :definici\u00f3n")})
public class Palabras implements Serializable {

    private static final long serialVersionUID = 1L;
    @Id
    @Basic(optional = false)
    @Column(name = "palabra")
    private String palabra;
    @Basic(optional = false)
    @Column(name = "definici\u00f3n")
    private String definición;

    public Palabras() {
    }

    public Palabras(String palabra) {
        this.palabra = palabra;
    }

    public Palabras(String palabra, String definición) {
        this.palabra = palabra;
        this.definición = definición;
    }

    public String getPalabra() {
        return palabra;
    }

    public void setPalabra(String palabra) {
        this.palabra = palabra;
    }

    public String getDefinición() {
        return definición;
    }

    public void setDefinición(String definición) {
        this.definición = definición;
    }

    @Override
    public int hashCode() {
        int hash = 0;
        hash += (palabra != null ? palabra.hashCode() : 0);
        return hash;
    }

    @Override
    public boolean equals(Object object) {
        // TODO: Warning - this method won't work in the case the id fields are not set
        if (!(object instanceof Palabras)) {
            return false;
        }
        Palabras other = (Palabras) object;
        if ((this.palabra == null && other.palabra != null) || (this.palabra != null && !this.palabra.equals(other.palabra))) {
            return false;
        }
        return true;
    }

    @Override
    public String toString() {
        return "model.Palabras[ palabra=" + palabra + " ]";
    }
    
}
