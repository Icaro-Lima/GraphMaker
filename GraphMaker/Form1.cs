using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace GraphMaker
{
    public partial class Form1 : Form
    {
        private List<Tuple<Button, Button, bool>> listOfEdges = new List<Tuple<Button, Button, bool>>();
        private Point mouseDownLocation;
        private Graphics graphicsPanel1 = null;

        public Form1()
        {
            InitializeComponent();

            graphicsPanel1 = panel1.CreateGraphics();
        }

        public bool HaveButtonWithSameText(Control.ControlCollection listOfButtons, string text)
        {
            for (int i = 0; i < listOfButtons.Count; i++)
            {
                if (listOfButtons[i].Text == text)
                {
                    return true;
                }
            }

            return false;
        }

        public Button GetButtonWithThisText(Control.ControlCollection listOfButtons, string text)
        {
            for (int i = 0; i < listOfButtons.Count; i++)
            {
                if (listOfButtons[i].Text == text)
                {
                    return listOfButtons[i] as Button;
                }
            }

            return null;
        }

        public string ValidateTextBoxVertexes()
        {
            string[] vertexes = textBoxVertexes.Text.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);

            if (vertexes.Length != 0)
            {
                return "";
            }
            else
            {
                return "A lista de vértices não pode estar vazia.";
            }
        }

        public static bool HaveUnique(string text, char[] tokens)
        {
            int count = 0;

            for (int i = 0; i < text.Length; i++)
            {
                if (tokens.Contains(text[i]))
                {
                    count++;
                }
            }

            return count == 1 || count == 0;
        }

        public string ValidateAndProcessTextBoxEdges()
        {
            listOfEdges.Clear();

            string[] edges = textBoxEdges.Text.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);

            if (edges.Length != 0)
            {
                for (int i = 0; i < edges.Length; i++)
                {
                    if (edges[i].Length > 2)
                    {
                        if (HaveUnique(edges[i], new char[] { '-', '>', '<' }))
                        {
                            if (edges[i].Contains('-') && edges[i].Split(new char[] { '-' }, StringSplitOptions.RemoveEmptyEntries).Length == 2)
                            {
                                string[] tokens = edges[i].Split(new char[] { '-' }, StringSplitOptions.RemoveEmptyEntries);

                                if (HaveButtonWithSameText(panel1.Controls, tokens[0]) && HaveButtonWithSameText(panel1.Controls, tokens[1]))
                                {
                                    listOfEdges.Add(new Tuple<Button, Button, bool>(GetButtonWithThisText(panel1.Controls, tokens[0]), GetButtonWithThisText(panel1.Controls, tokens[1]), false));
                                    DrawEdges();
                                }
                                else
                                {
                                    return "Problema em: \"" + edges[i] + "\"\nAlgum dos dois vértices ainda não existe";
                                }
                            }
                            else if (edges[i].Contains('>') && edges[i].Split(new char[] { '>' }, StringSplitOptions.RemoveEmptyEntries).Length == 2)
                            {
                                string[] tokens = edges[i].Split(new char[] { '>' }, StringSplitOptions.RemoveEmptyEntries);

                                if (HaveButtonWithSameText(panel1.Controls, tokens[0]) && HaveButtonWithSameText(panel1.Controls, tokens[1]))
                                {
                                    listOfEdges.Add(new Tuple<Button, Button, bool>(GetButtonWithThisText(panel1.Controls, tokens[0]), GetButtonWithThisText(panel1.Controls, tokens[1]), true));
                                    DrawEdges();
                                }
                                else
                                {
                                    return "Problema em: \"" + edges[i] + "\"\nAlgum dos dois vértices ainda não existe";
                                }
                            }
                            else if (edges[i].Contains('<') && edges[i].Split(new char[] { '<' }, StringSplitOptions.RemoveEmptyEntries).Length == 2)
                            {
                                string[] tokens = edges[i].Split(new char[] { '<' }, StringSplitOptions.RemoveEmptyEntries);

                                if (HaveButtonWithSameText(panel1.Controls, tokens[0]) && HaveButtonWithSameText(panel1.Controls, tokens[1]))
                                {
                                    listOfEdges.Add(new Tuple<Button, Button, bool>(GetButtonWithThisText(panel1.Controls, tokens[1]), GetButtonWithThisText(panel1.Controls, tokens[0]), true));
                                    DrawEdges();
                                }
                                else
                                {
                                    return "Problema em: \"" + edges[i] + "\"\nAlgum dos dois vértices ainda não existe";
                                }
                            }
                            else
                            {
                                return "Problema em: \"" + edges[i] + "\"\nPara vertices com mais de um caractere, use algum desses separadores: '-', '>' e '<'";
                            }
                        }
                        else
                        {
                            return "Problema em: \"" + edges[i] + "\"\nUtilize apenas um '-' ou apenas um '>' ou apenas um '<'";
                        }
                    }
                    else if (edges[i].Length == 2 && !edges[i].Contains('-') && !edges[i].Contains('>') && !edges[i].Contains('<'))
                    {
                        if (HaveButtonWithSameText(panel1.Controls, edges[i][0].ToString()) && HaveButtonWithSameText(panel1.Controls, edges[i][1].ToString()))
                        {
                            listOfEdges.Add(new Tuple<Button, Button, bool>(GetButtonWithThisText(panel1.Controls, edges[i][0].ToString()), GetButtonWithThisText(panel1.Controls, edges[i][1].ToString()), false));
                            DrawEdges();
                        }
                        else
                        {
                            return "Problema em: \"" + edges[i] + "\"\nAlgum dos dois vértices ainda não existe";
                        }
                    }
                    else
                    {
                        return "Problema em: \"" + edges[i] + "\"";
                    }
                }

                return "";
            }
            else
            {
                return "";
            }
        }

        private void buttonCreate_Click(object sender, EventArgs e)
        {
            string validationVertexResult = ValidateTextBoxVertexes();

            if (validationVertexResult.Length == 0)
            {
                string[] vertexes = textBoxVertexes.Text.Split(',');

                for (int i = 0; i < panel1.Controls.Count; i++)
                {
                    if (!vertexes.Contains(panel1.Controls[i].Text))
                    {
                        panel1.Controls.RemoveAt(i);
                        i--;
                    }
                }

                for (int i = 0; i < vertexes.Length; i++)
                {
                    if (!HaveButtonWithSameText(panel1.Controls, vertexes[i]))
                    {
                        Button buttonVertex = new Button();
                        buttonVertex.Size = new Size(10, 10);
                        buttonVertex.AutoSize = true;
                        buttonVertex.AutoSizeMode = AutoSizeMode.GrowOnly;
                        buttonVertex.Text = vertexes[i];
                        buttonVertex.Location = new Point(panel1.Width / 2, panel1.Height / 2);
                        buttonVertex.MouseDown += new MouseEventHandler(buttonVertex_MouseDown);
                        buttonVertex.MouseMove += new MouseEventHandler(buttonVertex_MouseMove);

                        panel1.Controls.Add(buttonVertex);
                    }
                }

                string validationEdgeResult = ValidateAndProcessTextBoxEdges();

                if (validationEdgeResult.Length != 0)
                {
                    MessageBox.Show(validationEdgeResult);
                }
            }
            else
            {
                MessageBox.Show(validationVertexResult);
            }
        }

        public static bool LineSegementsIntersect(Vector p, Vector p2, Vector q, Vector q2,
    out Vector intersection, bool considerCollinearOverlapAsIntersect = false)
        {
            intersection = new Vector();

            var r = p2 - p;
            var s = q2 - q;
            var rxs = r.Cross(s);
            var qpxr = (q - p).Cross(r);

            // If r x s = 0 and (q - p) x r = 0, then the two lines are collinear.
            if (rxs.IsZero() && qpxr.IsZero())
            {
                // 1. If either  0 <= (q - p) * r <= r * r or 0 <= (p - q) * s <= * s
                // then the two lines are overlapping,
                if (considerCollinearOverlapAsIntersect)
                    if ((0 <= (q - p) * r && (q - p) * r <= r * r) || (0 <= (p - q) * s && (p - q) * s <= s * s))
                        return true;

                // 2. If neither 0 <= (q - p) * r = r * r nor 0 <= (p - q) * s <= s * s
                // then the two lines are collinear but disjoint.
                // No need to implement this expression, as it follows from the expression above.
                return false;
            }

            // 3. If r x s = 0 and (q - p) x r != 0, then the two lines are parallel and non-intersecting.
            if (rxs.IsZero() && !qpxr.IsZero())
                return false;

            // t = (q - p) x s / (r x s)
            var t = (q - p).Cross(s) / rxs;

            // u = (q - p) x r / (r x s)

            var u = (q - p).Cross(r) / rxs;

            // 4. If r x s != 0 and 0 <= t <= 1 and 0 <= u <= 1
            // the two line segments meet at the point p + t r = q + u s.
            if (!rxs.IsZero() && (0 <= t && t <= 1) && (0 <= u && u <= 1))
            {
                // We can calculate the intersection point using either t or u.
                intersection = p + t * r;

                // An intersection was found.
                return true;
            }

            // 5. Otherwise, the two line segments are not parallel but do not intersect.
            return false;
        }

        public Point IntersectionLineAndRectangle(Point a, Point b, Rectangle rect, out bool sucess)
        {
            Vector vectorIntersection;
            sucess = false;

            try
            {
                if (LineSegementsIntersect(new Vector(a.X, a.Y), new Vector(b.X, b.Y), new Vector(rect.X, rect.Y), new Vector(rect.Right, rect.Y), out vectorIntersection, true))
                {
                    sucess = true;
                    return new Point((int)vectorIntersection.X, (int)vectorIntersection.Y);
                }
                else if (LineSegementsIntersect(new Vector(a.X, a.Y), new Vector(b.X, b.Y), new Vector(rect.X, rect.Y), new Vector(rect.X, rect.Bottom), out vectorIntersection, true))
                {
                    sucess = true;
                    return new Point((int)vectorIntersection.X, (int)vectorIntersection.Y);
                }
                else if (LineSegementsIntersect(new Vector(a.X, a.Y), new Vector(b.X, b.Y), new Vector(rect.X, rect.Bottom), new Vector(rect.Right, rect.Bottom), out vectorIntersection, true))
                {
                    sucess = true;
                    return new Point((int)vectorIntersection.X, (int)vectorIntersection.Y);
                }
                else if (LineSegementsIntersect(new Vector(a.X, a.Y), new Vector(b.X, b.Y), new Vector(rect.Right, rect.Y), new Vector(rect.Right, rect.Bottom), out vectorIntersection, true))
                {
                    sucess = true;
                    return new Point((int)vectorIntersection.X, (int)vectorIntersection.Y);
                }
                else
                {
                    return new Point();
                }
            }
            catch
            {
                return new Point();
            }
        }

        public void DrawEdges()
        {
            graphicsPanel1.Clear(Color.White);

            Pen pen = new Pen(buttonColorPicker.BackColor)
            {
                Width = 1
            };

            AdjustableArrowCap bigArrow = new AdjustableArrowCap(5, 5);
            Pen penWithArrow = new Pen(buttonColorPicker.BackColor)
            {
                CustomEndCap = bigArrow,
                Width = 1
            };

            for (int i = 0; i < listOfEdges.Count; i++)
            {
                Tuple<Button, Button, bool> tuple = listOfEdges[i];

                Point output = tuple.Item1.Location;
                output.X += tuple.Item1.Width / 2;
                output.Y += tuple.Item1.Height / 2;

                Point input = tuple.Item2.Location;
                input.X += tuple.Item2.Width / 2;
                input.Y += tuple.Item2.Height / 2;

                if (tuple.Item3 == false)
                {
                    graphicsPanel1.DrawLine(pen, output, input);
                }
                else
                {
                    bool sucess;
                    Point pointIntersect = IntersectionLineAndRectangle(output, input, tuple.Item2.Bounds, out sucess);

                    if (input != output && sucess)
                    {
                        graphicsPanel1.DrawLine(penWithArrow, output, pointIntersect);
                    }
                }
            }
        }

        private void buttonVertex_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                mouseDownLocation = e.Location;
            }
        }

        private void buttonVertex_MouseMove(object sender, MouseEventArgs e)
        {
            Button buttonSender = sender as Button;

            if (e.Button == MouseButtons.Left)
            {
                buttonSender.Left = e.X + buttonSender.Left - mouseDownLocation.X;
                buttonSender.Top = e.Y + buttonSender.Top - mouseDownLocation.Y;

                DrawEdges();
            }
        }

        private void buttonColorPicker_Click(object sender, EventArgs e)
        {
            ColorDialog colorDialog = new ColorDialog()
            {
                Color = buttonColorPicker.BackColor
            };

            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                buttonColorPicker.BackColor = colorDialog.Color;
            }
        }

        private void Form1_Activated(object sender, EventArgs e)
        {
            DrawEdges();
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            DrawEdges();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Random random = new Random((int)System.DateTime.Now.Ticks);

            string nameGraph = "grafo" + random.Next();

            System.IO.StreamWriter file = new System.IO.StreamWriter("CodigoDoGrafoPython.txt", false);

            file.WriteLine(nameGraph + " = {}");

            for (int i = 0; i < panel1.Controls.Count; i++)
            {
                file.WriteLine(string.Format("add_vertex({0}, \"{1}\")", nameGraph, panel1.Controls[i].Text));
            }

            for (int i = 0; i < listOfEdges.Count; i++)
            {
                file.WriteLine(string.Format("add_edge({0}, {{\"{1}\", \"{2}\"}})", nameGraph, listOfEdges[i].Item1.Text, listOfEdges[i].Item2.Text));
            }

            file.WriteLine();

            file.Close();

            System.Diagnostics.Process.Start("CodigoDoGrafoPython.txt");
        }
    }
}
