using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace AwesomeCanvas
{
    //-------------------------------------------------------------------------
    // A class to be used to represent 2D vectors within the drawing program   
    //-------------------------------------------------------------------------
    class Vector2D
    {
        // Member variables
        private float m_x;                  // The x component
        private float m_y;                  // The y component
        private double m_magnitude;         // The size of the vector
        private bool m_staleMagnitude;      // If the magnitude needs calculating again
        private PointF m_normalisedVector;  // The normalised vector
        private bool m_staleNormalisation;  // If the normalised vector needs calculating again
        
        // Constructor
        public Vector2D(float x, float y)
        {
            // Initialise variables
            m_x = x;
            m_y = y;
            m_staleMagnitude = true;
            m_staleNormalisation = true;
        }
        
        // Get the basic variables
        public float GetX() { return m_x; }
        public float GetY() { return m_y; }
        public PointF AsPoint() { return new PointF(m_x, m_y); }
        
        // Set the x components
        public void SetX(float x) 
        {
            m_x = x;
            m_staleMagnitude = true;
            m_staleNormalisation = true;
        }
        
        // Set the y component
        public void SetY(float y) 
        {
            m_y = y;
            m_staleMagnitude = true;
            m_staleNormalisation = true;
        }
        
        // Set both x and y components
        public void SetAsPoint(PointF point) 
        { 
            m_x = point.X;
            m_y = point.Y;
            m_staleMagnitude = true;
            m_staleNormalisation = true;
        }

        // Return the magnitude. Recalculate it if the source variables have changed
        public double GetMagnitude()
        {
            if (m_staleMagnitude)
            { 
                // Calculate the magnitude - pythagorise
                m_magnitude = Math.Sqrt((double)((m_x * m_x) + (m_y * m_y)));

                // This is now a fresh calculation
                m_staleMagnitude = false;
            }

            return m_magnitude;
        }

        // Return the normalised vector. Recalculate it if the source variables have changed
        public PointF GetNormalisedVector()
        {
            if (m_staleNormalisation)
            {
                // Normalise the vector
                m_normalisedVector.X = m_x / (float)GetMagnitude();
                m_normalisedVector.Y = m_y / (float)GetMagnitude();

                // This is now a fresh calculation
                m_staleNormalisation = false;
            }

            // Return the normalised vector
            return m_normalisedVector;
        }
    }
}
