using MyLib;
using System;
using System.Collections.Generic;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Xceed.Document.NET;
using Xceed.Words.NET;

namespace oaip5
{
    class DocumentWork
    {
        Users users;
        public DocumentWork(Users users)
        {
            this.users = users;
        }
        private void OutputDocFile()
        {
            
            string pathDocument = AppDomain.CurrentDomain.BaseDirectory + "first.docx";
            DocX document = DocX.Create(pathDocument);
            document.MarginLeft = 60.0f;
            document.MarginRight = 60.0f;
            document.MarginTop = 60.0f;
            document.MarginBottom = 60.0f;

            document.InsertParagraph("федеральное государственное бюджетное образовательное учреждение высшего образования «Казанский национальный исследовательский технический университет им.А.Н.Туполева - КАИ» (КНИТУ - КАИ)").
            Bold().


             Font("Times New Roman").

             FontSize(14).

            Alignment = Alignment.center;
            document.InsertParagraph("\n" + "ОТДЕЛЕНИЕ СРЕДНЕГО ПРОФЕССИОНАЛЬНОГО ОБРАЗОВАНИЯ" + "\n\n").
            Font("Times New Roman").
            FontSize(14).
            Alignment = Alignment.center;
            document.InsertParagraph("У Т В Е Р Ж Д А Ю" + "\n\n" +
           "Директор отделения СПО ИКТЗИ" + "\n").
            Font("Times New Roman").
            FontSize(12).
            Alignment = Alignment.right;
            document.InsertParagraph("_______________, Осадчая Д.М." +

           "\n").
            Font("Times New Roman").
            FontSize(12).
            Alignment = Alignment.right;
            document.InsertParagraph("«____»______________20_____г." +
           "\n").
            Font("Times New Roman").
            FontSize(12).
            Alignment = Alignment.right;
            document.InsertParagraph("З А Д А Н И Е").
            Font("Times New Roman").
            FontSize(16).Bold().
            Alignment = Alignment.center;

            document.InsertParagraph("на дипломный проект").
            Font("Times New Roman").
            FontSize(12).
            Bold().
            Alignment = Alignment.center;
            Table table = document.AddTable(4, 2);
            table.Alignment = Alignment.center;
            table.Design = TableDesign.TableGrid;
            table.SetWidths(new float[] { 180.0f, 600.0f });
            table.Rows[0].Cells[0].Paragraphs[0].Append("Обучающийся").Font("Times New Roman").
            FontSize(12).
            Bold();
            table.Rows[0].Cells[1].Paragraphs[0].Append("this.users.Student.Name").Font("Times New Roman").

 FontSize(12).UnderlineStyle(UnderlineStyle.singleLine);
            table.Rows[1].Cells[0].Paragraphs[0]
           .Append("Специальность").Font("Times New Roman").
            FontSize(12).
            Bold();
            table.Rows[2].Cells[0].Paragraphs[0]
           .Append("Группа").Font("Times New Roman").
            FontSize(12).
            Bold();

            table.Rows[2].Cells[1].Paragraphs[0]
            .Append("this.users.Student.NumberGroup.ToString()").Font("Times New Roman").


             FontSize(12).
             Bold();
            table.Rows[3].Cells[0].Paragraphs[0]
           .Append("Тема дипломного проекта").Font("Times New Roman").
            FontSize(12).
            Bold();
            table.Rows[3].Cells[1].Paragraphs[0]
           .Append("this.users.Professor.Thesis.ToList()").Font("Times New Roman").
            FontSize(12).
            Bold();
            document.InsertParagraph().InsertTableAfterSelf(table);
            Paragraph p1 = document.InsertParagraph();
            p1.AppendLine("Тема утверждена приказом по университету от «__»__________20__г. №______").Font("Times New Roman").
             FontSize(12);
            p1.AppendLine();
            p1.AppendLine("Срок сдачи дипломного проекта «__»______________20__г. ")
            .Font("Times New Roman").
             FontSize(12).
             Bold();
            p1.AppendLine("Содержание дипломного проекта").Font("Times New Roman").FontSize(12).Bold().Append("(перечень вопросов, подлежащих рассмотрению):").FontSize(12).Font("Times New Roman");
            p1.AppendLine("__________________________________________________________________________________");
            p1.AppendLine("__________________________________________________________________________________");
            p1.AppendLine("__________________________________________________________________________________");
            Table t1 = document.AddTable(3, 4);
            t1.Alignment = Alignment.center;
            t1.Design = TableDesign.TableGrid;
            t1.SetWidths(new float[] { 180.0f, 600.0f });
            t1.Rows[0].Cells[0].Paragraphs[0].Append("Задание по специальному разделу дипломного проекта");
            t1.Rows[0].Cells[1].Paragraphs[0].Append("Консультант");
            t1.Rows[0].MergeCells(2, 3);
            t1.Rows[0].Cells[2].Paragraphs[0].Append("Подпись, дата");
            t1.Rows[1].Cells[2].Paragraphs[0].Append("задание выдал");
            t1.Rows[1].Cells[3].Paragraphs[0].Append("задание принял");
            t1.Rows[2].MergeCells(0, 3);
            t1.MergeCellsInColumn(0, 0, 1);
            t1.MergeCellsInColumn(1, 0, 1);
            document.InsertParagraph().InsertTableAfterSelf(t1);
            Paragraph p2 = document.InsertParagraph();
            p2.AppendLine("Перечень иллюстративного материала ").Font("Times New Roman").FontSize(12).Bold().Append("(кол-во листов и их содержание)").Font("Times New Roman").FontSize(12);
            p2.AppendLine("__________________________________________________________________________________");
            p2.AppendLine("__________________________________________________________________________________");
            p2.AppendLine("__________________________________________________________________________________");

            Paragraph p3 = document.InsertParagraph();
            p3.AppendLine("Руководитель проекта            ").Font("Times New Roman").FontSize(12).Bold().Append("_____________________________________________________").Alignment = Alignment.left;
            p3.AppendLine("                          (Имя, Отчество, Фамилия)").Alignment = Alignment.center;
            p3.AppendLine();
            document.InsertParagraph().AppendLine();
            document.InsertParagraph().AppendLine();
            document.InsertParagraph().AppendLine();
            document.InsertParagraph().AppendLine();
            p3.AppendLine("График выполнения проекта").Font("Times New Roman").FontSize(12).Bold().Alignment = Alignment.center;


            Table t2 = document.AddTable(14, 3);
            t2.Alignment = Alignment.center;
            t2.Design = TableDesign.TableGrid;
            t2.SetWidths(new float[] { 180.0f, 600.0f });
            t2.Rows[0].Cells[0].Paragraphs[0].Append("Раздел проекта").Font("Times New Roman").FontSize(12).Alignment = Alignment.center;
            t2.Rows[0].Cells[1].Paragraphs[0].Append("Календарный срок выполнения").Font("Times New Roman").FontSize(12).Alignment = Alignment.center;
            t2.Rows[0].Cells[2].Paragraphs[0].Append("Отметка о выполнении").Font("Times New Roman").FontSize(12).Alignment = Alignment.center;
            document.InsertParagraph().InsertTableAfterSelf(t2);


            Paragraph p4 = document.InsertParagraph();
            p4.AppendLine("Дата выдачи задания    	").Font("Times New Roman").FontSize(12).Bold().Italic().Append("_____________________               _________________________");
            p4.AppendLine("                                                     (подпись руководителя, дата)	     (И.О.Ф. руководителя)");
            p4.AppendLine();
            p4.AppendLine("С заданием ознакомлен(а)    	").Font("Times New Roman").FontSize(12).Bold().Italic().Append("_____________________              ____________________");
            p4.AppendLine("                                                                 (подпись обучающегося, дата)	   (И.О.Ф. обучающегося)");
            Paragraph p5 = document.InsertParagraph();
            p5.AppendLine("Руководитель	    ").Font("Times New Roman").FontSize(12).Bold().Italic().Append("_____________________               _________________________");
            p5.AppendLine("                                           (подпись руководителя и дата)       	(И.О.Ф. руководителя)");
            p5.AppendLine();
            p5.AppendLine("Нормоконтроль	").Font("Times New Roman").FontSize(12).Bold().Italic().Append("_____________________                _________________________");
            p5.AppendLine("                                                    (подпись и дата)	                                       (И.О.Ф.)");
            p5.AppendLine();
            p5.AppendLine("Обучающийся_______________ полностью выполнил(а) задание и может быть допущен(а) к защите дипломного проекта:").Font("Times New Roman").FontSize(12);

            Table t3 = document.AddTable(2, 3);
            t3.Alignment = Alignment.center;
            t3.Design = TableDesign.TableGrid;
            t3.SetWidths(new float[] { 180.0f, 600.0f });
            t3.Rows[0].Cells[0].Paragraphs[0].Append("Зав.кафедрой / Председатель цикловой комиссии/ Ответственный по специальности").Font("Times New Roman").FontSize(12).Bold();
            t3.Rows[1].Cells[1].Paragraphs[0].Append("(подпись и дата)").Alignment = Alignment.center;
            t3.Rows[1].Cells[2].Paragraphs[0].Append("(И.О.Ф.)").Alignment = Alignment.center;
            document.InsertParagraph().InsertTableAfterSelf(t3);
            document.InsertParagraph().AppendLine();

            Table t4 = document.AddTable(2, 3);
            t3.Alignment = Alignment.center;
            t3.Design = TableDesign.TableGrid;
            t3.SetWidths(new float[] { 180.0f, 600.0f });
            t4.Rows[0].Cells[0].Paragraphs[0].Append("Директор отделения СПО").Font("Times New Roman").FontSize(12).Bold();
            t4.Rows[1].Cells[1].Paragraphs[0].Append("(подпись и дата)").Alignment = Alignment.center;
            t4.Rows[1].Cells[2].Paragraphs[0].Append(" (И.О.Ф.)").Alignment = Alignment.center;
            document.InsertParagraph().InsertTableAfterSelf(t4);

            //t2.Rows[0].Cells[1].Paragraphs[1].Append("Перечень иллюстративного материала (кол-во листов и их содержание)");
            //t2.Rows[1].MergeCells(0, 1);
            //t2.Rows[2].MergeCells(0, 1);
            //t2.Rows[3].MergeCells(0, 1);




            /*table.Rows[22].Cells[0].Paragraphs[0].Append("Задание по специальному разделу дипломного проекта").Font("Times New Roman").
            FontSize(12).
            Bold();
            table.Rows[22].Cells[1].Paragraphs[0].Append("Консультант").Font("Times New Roman").
            FontSize(12).
            Bold();
            table.Rows[24].Cells[0].Paragraphs[0].Append("Перечень иллюстративного материала (кол-во листов и их содержание)").Font("Times New Roman").
            FontSize(12).
            Bold();
            table.Rows[28].Cells[0].Paragraphs[0].Append("Руководитель проекта	______________________").Font("Times New Roman").
            FontSize(12).
            Bold();
            table.Rows[29].Cells[0].Paragraphs[0].Append("(Имя, Отчество, Фамилия)").Font("Times New Roman").
            FontSize(12).
            Bold().Alignment = Alignment.left;
            table.Rows[30].Cells[0].Paragraphs[0].Append("График выполнения проекта").Font("Times New Roman").
            FontSize(12).
            Bold().Alignment = Alignment.center;
            table.Rows[31].Cells[0].Paragraphs[0].Append("Раздел проекта").Font("Times New Roman").
            FontSize(12).
            Bold();
            table.Rows[31].Cells[1].Paragraphs[0].Append("Календарный срок выполнения").Font("Times New Roman").
            FontSize(12).
            Bold();
            table.Rows[31].Cells[2].Paragraphs[0].Append("Отметка o выполнении").Font("Times New Roman").
            FontSize(12).
            Bold();*/



            document.Save();
        }
        string printContent = "";
        private void PrintDoc()
        {

            //this.printContent = richTextBoxName.Text + "\n" +
            //richTextBoxNumberGroup.Text + "\n"
            //+ richTextBoxPassword.Text + "\n" +
            //richTextBoxPersonalData.Text + "\n" +
            //richTextBoxProfessor.Text + "\n" +
            //richTextBoxThesis.Text;
            //PrintDocument printDocument = new PrintDocument();
            //PrintDialog printDialog = new PrintDialog();
            //printDocument.PrintPage += PrintPageHandler;
            //printDialog.Document = printDocument;

            //if (printDialog.ShowDialog() == DialogResult.OK)
            //{
            //    printDialog.Document.Print();
            //}
        }

    }
}
