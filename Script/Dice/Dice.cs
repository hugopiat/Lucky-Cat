using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dice : MonoBehaviour
{
    private int m_IdDice;
    private int m_Size;

    public Dice (int IdDice, int Size) 
    {
        m_IdDice = IdDice;
        m_Size = Size;
    }

    public void DestroyDice()
    {
        Destroy(this);
    }
    public int GetIdDice() { return m_IdDice; }
    public int GetSize() { return m_Size; }
}
