namespace FMS.Report
{
    partial class ServiceDetailsReport
    {
        #region Component Designer generated code
        /// <summary>
        /// Required method for telerik Reporting designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ServiceDetailsReport));
            Telerik.Reporting.Group group1 = new Telerik.Reporting.Group();
            Telerik.Reporting.ReportParameter reportParameter1 = new Telerik.Reporting.ReportParameter();
            Telerik.Reporting.ReportParameter reportParameter2 = new Telerik.Reporting.ReportParameter();
            Telerik.Reporting.ReportParameter reportParameter3 = new Telerik.Reporting.ReportParameter();
            Telerik.Reporting.ReportParameter reportParameter4 = new Telerik.Reporting.ReportParameter();
            Telerik.Reporting.ReportParameter reportParameter5 = new Telerik.Reporting.ReportParameter();
            Telerik.Reporting.ReportParameter reportParameter6 = new Telerik.Reporting.ReportParameter();
            Telerik.Reporting.ReportParameter reportParameter7 = new Telerik.Reporting.ReportParameter();
            Telerik.Reporting.ReportParameter reportParameter8 = new Telerik.Reporting.ReportParameter();
            Telerik.Reporting.ReportParameter reportParameter9 = new Telerik.Reporting.ReportParameter();
            Telerik.Reporting.Drawing.StyleRule styleRule1 = new Telerik.Reporting.Drawing.StyleRule();
            this.GroupFooterArea2 = new Telerik.Reporting.GroupFooterSection();
            this.GroupHeaderArea2 = new Telerik.Reporting.GroupHeaderSection();
            this.GroupNameBusinessGroup1 = new Telerik.Reporting.TextBox();
            this.Text17 = new Telerik.Reporting.TextBox();
            this.PrintDate1 = new Telerik.Reporting.TextBox();
            this.Text8 = new Telerik.Reporting.TextBox();
            this.Area2 = new Telerik.Reporting.PageHeaderSection();
            this.Box1 = new Telerik.Reporting.Shape();
            this.Text13 = new Telerik.Reporting.TextBox();
            this.Text2 = new Telerik.Reporting.TextBox();
            this.Text3 = new Telerik.Reporting.TextBox();
            this.Text4 = new Telerik.Reporting.TextBox();
            this.Text6 = new Telerik.Reporting.TextBox();
            this.Text7 = new Telerik.Reporting.TextBox();
            this.Text10 = new Telerik.Reporting.TextBox();
            this.Text12 = new Telerik.Reporting.TextBox();
            this.Text14 = new Telerik.Reporting.TextBox();
            this.Text5 = new Telerik.Reporting.TextBox();
            this.Text9 = new Telerik.Reporting.TextBox();
            this.Text11 = new Telerik.Reporting.TextBox();
            this.imgLogo = new Telerik.Reporting.PictureBox();
            this.Area3 = new Telerik.Reporting.DetailSection();
            this.Year1 = new Telerik.Reporting.TextBox();
            this.RegistrationNumber1 = new Telerik.Reporting.TextBox();
            this.VehicleDescription1 = new Telerik.Reporting.TextBox();
            this.Center1 = new Telerik.Reporting.TextBox();
            this.ServiceDate1 = new Telerik.Reporting.TextBox();
            this.ServiceEndDate1 = new Telerik.Reporting.TextBox();
            this.ServiceType1 = new Telerik.Reporting.TextBox();
            this.Mechanic1 = new Telerik.Reporting.TextBox();
            this.ServiceProvider1 = new Telerik.Reporting.TextBox();
            this.Description1 = new Telerik.Reporting.TextBox();
            this.Cost1 = new Telerik.Reporting.TextBox();
            this.PORefNumber1 = new Telerik.Reporting.TextBox();
            this.Area4 = new Telerik.Reporting.ReportFooterSection();
            this.Area5 = new Telerik.Reporting.PageFooterSection();
            this.Box2 = new Telerik.Reporting.Shape();
            this.PageNofM1 = new Telerik.Reporting.TextBox();
            this.sqdsServiceDetailsReport = new Telerik.Reporting.SqlDataSource();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // GroupFooterArea2
            // 
            this.GroupFooterArea2.Height = Telerik.Reporting.Drawing.Unit.Inch(0.153D);
            this.GroupFooterArea2.KeepTogether = false;
            this.GroupFooterArea2.Name = "GroupFooterArea2";
            this.GroupFooterArea2.PageBreak = Telerik.Reporting.PageBreak.None;
            this.GroupFooterArea2.Style.BackgroundColor = System.Drawing.Color.White;
            this.GroupFooterArea2.Style.Visible = true;
            // 
            // GroupHeaderArea2
            // 
            this.GroupHeaderArea2.Height = Telerik.Reporting.Drawing.Unit.Inch(0.16D);
            this.GroupHeaderArea2.Items.AddRange(new Telerik.Reporting.ReportItemBase[] {
            this.GroupNameBusinessGroup1});
            this.GroupHeaderArea2.KeepTogether = false;
            this.GroupHeaderArea2.Name = "GroupHeaderArea2";
            this.GroupHeaderArea2.PageBreak = Telerik.Reporting.PageBreak.None;
            this.GroupHeaderArea2.Style.BackgroundColor = System.Drawing.Color.White;
            this.GroupHeaderArea2.Style.Visible = true;
            // 
            // GroupNameBusinessGroup1
            // 
            this.GroupNameBusinessGroup1.CanGrow = false;
            this.GroupNameBusinessGroup1.CanShrink = false;
            this.GroupNameBusinessGroup1.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(0D), Telerik.Reporting.Drawing.Unit.Inch(0D));
            this.GroupNameBusinessGroup1.Name = "GroupNameBusinessGroup1";
            this.GroupNameBusinessGroup1.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(1.805D), Telerik.Reporting.Drawing.Unit.Inch(0.16D));
            this.GroupNameBusinessGroup1.Style.BackgroundColor = System.Drawing.Color.White;
            this.GroupNameBusinessGroup1.Style.BorderColor.Default = System.Drawing.Color.Black;
            this.GroupNameBusinessGroup1.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.None;
            this.GroupNameBusinessGroup1.Style.Color = System.Drawing.Color.Black;
            this.GroupNameBusinessGroup1.Style.Font.Bold = true;
            this.GroupNameBusinessGroup1.Style.Font.Italic = false;
            this.GroupNameBusinessGroup1.Style.Font.Name = "Arial";
            this.GroupNameBusinessGroup1.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(10D);
            this.GroupNameBusinessGroup1.Style.Font.Strikeout = false;
            this.GroupNameBusinessGroup1.Style.Font.Underline = false;
            this.GroupNameBusinessGroup1.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Left;
            this.GroupNameBusinessGroup1.Style.Visible = true;
            this.GroupNameBusinessGroup1.Value = "=Fields.[BusinessGroup]";
            // 
            // Text17
            // 
            this.Text17.CanGrow = false;
            this.Text17.CanShrink = false;
            this.Text17.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(4D), Telerik.Reporting.Drawing.Unit.Inch(0.2D));
            this.Text17.Name = "Text17";
            this.Text17.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(2.8D), Telerik.Reporting.Drawing.Unit.Inch(0.291D));
            this.Text17.Style.BackgroundColor = System.Drawing.Color.White;
            this.Text17.Style.BorderColor.Default = System.Drawing.Color.Black;
            this.Text17.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.None;
            this.Text17.Style.Color = System.Drawing.Color.Black;
            this.Text17.Style.Font.Bold = false;
            this.Text17.Style.Font.Italic = false;
            this.Text17.Style.Font.Name = "Calibri";
            this.Text17.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(16D);
            this.Text17.Style.Font.Strikeout = false;
            this.Text17.Style.Font.Underline = false;
            this.Text17.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Left;
            this.Text17.Style.Visible = true;
            this.Text17.Value = "Vehicle Service Details Report";
            // 
            // PrintDate1
            // 
            this.PrintDate1.CanGrow = false;
            this.PrintDate1.CanShrink = false;
            this.PrintDate1.Format = "{0:d}";
            this.PrintDate1.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(10.179D), Telerik.Reporting.Drawing.Unit.Inch(0.142D));
            this.PrintDate1.Name = "PrintDate1";
            this.PrintDate1.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(0.785D), Telerik.Reporting.Drawing.Unit.Inch(0.16D));
            this.PrintDate1.Style.BackgroundColor = System.Drawing.Color.White;
            this.PrintDate1.Style.BorderColor.Default = System.Drawing.Color.Black;
            this.PrintDate1.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.None;
            this.PrintDate1.Style.Color = System.Drawing.Color.Black;
            this.PrintDate1.Style.Font.Bold = false;
            this.PrintDate1.Style.Font.Italic = false;
            this.PrintDate1.Style.Font.Name = "Arial";
            this.PrintDate1.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(10D);
            this.PrintDate1.Style.Font.Strikeout = false;
            this.PrintDate1.Style.Font.Underline = false;
            this.PrintDate1.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center;
            this.PrintDate1.Style.Visible = true;
            this.PrintDate1.Value = "=Now()";
            // 
            // Text8
            // 
            this.Text8.CanGrow = false;
            this.Text8.CanShrink = false;
            this.Text8.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(9.663D), Telerik.Reporting.Drawing.Unit.Inch(0.148D));
            this.Text8.Name = "Text8";
            this.Text8.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(0.481D), Telerik.Reporting.Drawing.Unit.Inch(0.153D));
            this.Text8.Style.BackgroundColor = System.Drawing.Color.White;
            this.Text8.Style.BorderColor.Default = System.Drawing.Color.Black;
            this.Text8.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.None;
            this.Text8.Style.Color = System.Drawing.Color.Black;
            this.Text8.Style.Font.Bold = false;
            this.Text8.Style.Font.Italic = false;
            this.Text8.Style.Font.Name = "Arial";
            this.Text8.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(10D);
            this.Text8.Style.Font.Strikeout = false;
            this.Text8.Style.Font.Underline = false;
            this.Text8.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Left;
            this.Text8.Style.Visible = true;
            this.Text8.Value = "Date:";
            // 
            // Area2
            // 
            this.Area2.Height = Telerik.Reporting.Drawing.Unit.Inch(1.1D);
            this.Area2.Items.AddRange(new Telerik.Reporting.ReportItemBase[] {
            this.Box1,
            this.Text13,
            this.Text2,
            this.Text3,
            this.Text4,
            this.Text6,
            this.Text7,
            this.Text10,
            this.Text12,
            this.Text14,
            this.Text5,
            this.Text9,
            this.Text11,
            this.Text17,
            this.Text8,
            this.PrintDate1,
            this.imgLogo});
            this.Area2.Name = "Area2";
            this.Area2.PrintOnFirstPage = true;
            this.Area2.PrintOnLastPage = true;
            this.Area2.Style.BackgroundColor = System.Drawing.Color.White;
            this.Area2.Style.Visible = true;
            // 
            // Box1
            // 
            this.Box1.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(0.052D), Telerik.Reporting.Drawing.Unit.Inch(0.7D));
            this.Box1.Name = "Box1";
            this.Box1.ShapeType = new Telerik.Reporting.Drawing.Shapes.PolygonShape(4, 45D, 0);
            this.Box1.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(11.555D), Telerik.Reporting.Drawing.Unit.Inch(0.375D));
            this.Box1.Stretch = true;
            this.Box1.Style.BackgroundColor = System.Drawing.Color.Silver;
            this.Box1.Style.Color = System.Drawing.Color.Silver;
            this.Box1.Style.LineStyle = Telerik.Reporting.Drawing.LineStyle.Solid;
            this.Box1.Style.LineWidth = Telerik.Reporting.Drawing.Unit.Point(1D);
            this.Box1.Style.Visible = true;
            // 
            // Text13
            // 
            this.Text13.CanGrow = false;
            this.Text13.CanShrink = false;
            this.Text13.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(5.6D), Telerik.Reporting.Drawing.Unit.Inch(0.72D));
            this.Text13.Name = "Text13";
            this.Text13.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(0.667D), Telerik.Reporting.Drawing.Unit.Inch(0.323D));
            this.Text13.Style.BackgroundColor = System.Drawing.Color.Silver;
            this.Text13.Style.BorderColor.Default = System.Drawing.Color.Black;
            this.Text13.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.None;
            this.Text13.Style.Color = System.Drawing.Color.Black;
            this.Text13.Style.Font.Bold = true;
            this.Text13.Style.Font.Italic = false;
            this.Text13.Style.Font.Name = "Arial";
            this.Text13.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(10D);
            this.Text13.Style.Font.Strikeout = false;
            this.Text13.Style.Font.Underline = false;
            this.Text13.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center;
            this.Text13.Style.Visible = true;
            this.Text13.Value = "Service End Date\n";
            // 
            // Text2
            // 
            this.Text2.CanGrow = true;
            this.Text2.CanShrink = false;
            this.Text2.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(0.115D), Telerik.Reporting.Drawing.Unit.Inch(0.824D));
            this.Text2.Name = "Text2";
            this.Text2.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(0.643D), Telerik.Reporting.Drawing.Unit.Inch(0.16D));
            this.Text2.Style.BackgroundColor = System.Drawing.Color.Silver;
            this.Text2.Style.BorderColor.Default = System.Drawing.Color.Black;
            this.Text2.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.None;
            this.Text2.Style.Color = System.Drawing.Color.Black;
            this.Text2.Style.Font.Bold = true;
            this.Text2.Style.Font.Italic = false;
            this.Text2.Style.Font.Name = "Arial";
            this.Text2.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(10D);
            this.Text2.Style.Font.Strikeout = false;
            this.Text2.Style.Font.Underline = false;
            this.Text2.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Left;
            this.Text2.Style.Visible = true;
            this.Text2.Value = "Year";
            // 
            // Text3
            // 
            this.Text3.CanGrow = false;
            this.Text3.CanShrink = false;
            this.Text3.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(0.799D), Telerik.Reporting.Drawing.Unit.Inch(0.824D));
            this.Text3.Name = "Text3";
            this.Text3.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(0.907D), Telerik.Reporting.Drawing.Unit.Inch(0.16D));
            this.Text3.Style.BackgroundColor = System.Drawing.Color.Silver;
            this.Text3.Style.BorderColor.Default = System.Drawing.Color.Black;
            this.Text3.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.None;
            this.Text3.Style.Color = System.Drawing.Color.Black;
            this.Text3.Style.Font.Bold = true;
            this.Text3.Style.Font.Italic = false;
            this.Text3.Style.Font.Name = "Arial";
            this.Text3.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(10D);
            this.Text3.Style.Font.Strikeout = false;
            this.Text3.Style.Font.Underline = false;
            this.Text3.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Left;
            this.Text3.Style.Visible = true;
            this.Text3.Value = "Reg. Number";
            // 
            // Text4
            // 
            this.Text4.CanGrow = false;
            this.Text4.CanShrink = false;
            this.Text4.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(1.785D), Telerik.Reporting.Drawing.Unit.Inch(0.824D));
            this.Text4.Name = "Text4";
            this.Text4.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(1.657D), Telerik.Reporting.Drawing.Unit.Inch(0.16D));
            this.Text4.Style.BackgroundColor = System.Drawing.Color.Silver;
            this.Text4.Style.BorderColor.Default = System.Drawing.Color.Black;
            this.Text4.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.None;
            this.Text4.Style.Color = System.Drawing.Color.Black;
            this.Text4.Style.Font.Bold = true;
            this.Text4.Style.Font.Italic = false;
            this.Text4.Style.Font.Name = "Arial";
            this.Text4.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(10D);
            this.Text4.Style.Font.Strikeout = false;
            this.Text4.Style.Font.Underline = false;
            this.Text4.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Left;
            this.Text4.Style.Visible = true;
            this.Text4.Value = "Vehicle Description";
            // 
            // Text6
            // 
            this.Text6.CanGrow = false;
            this.Text6.CanShrink = false;
            this.Text6.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(3.486D), Telerik.Reporting.Drawing.Unit.Inch(0.835D));
            this.Text6.Name = "Text6";
            this.Text6.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(1.074D), Telerik.Reporting.Drawing.Unit.Inch(0.16D));
            this.Text6.Style.BackgroundColor = System.Drawing.Color.Silver;
            this.Text6.Style.BorderColor.Default = System.Drawing.Color.Black;
            this.Text6.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.None;
            this.Text6.Style.Color = System.Drawing.Color.Black;
            this.Text6.Style.Font.Bold = true;
            this.Text6.Style.Font.Italic = false;
            this.Text6.Style.Font.Name = "Arial";
            this.Text6.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(10D);
            this.Text6.Style.Font.Strikeout = false;
            this.Text6.Style.Font.Underline = false;
            this.Text6.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Left;
            this.Text6.Style.Visible = true;
            this.Text6.Value = "Center";
            // 
            // Text7
            // 
            this.Text7.CanGrow = false;
            this.Text7.CanShrink = false;
            this.Text7.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(4.594D), Telerik.Reporting.Drawing.Unit.Inch(0.733D));
            this.Text7.Name = "Text7";
            this.Text7.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(0.667D), Telerik.Reporting.Drawing.Unit.Inch(0.323D));
            this.Text7.Style.BackgroundColor = System.Drawing.Color.Silver;
            this.Text7.Style.BorderColor.Default = System.Drawing.Color.Black;
            this.Text7.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.None;
            this.Text7.Style.Color = System.Drawing.Color.Black;
            this.Text7.Style.Font.Bold = true;
            this.Text7.Style.Font.Italic = false;
            this.Text7.Style.Font.Name = "Arial";
            this.Text7.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(10D);
            this.Text7.Style.Font.Strikeout = false;
            this.Text7.Style.Font.Underline = false;
            this.Text7.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center;
            this.Text7.Style.Visible = true;
            this.Text7.Value = "Service Date\n";
            // 
            // Text10
            // 
            this.Text10.CanGrow = false;
            this.Text10.CanShrink = false;
            this.Text10.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(8.378D), Telerik.Reporting.Drawing.Unit.Inch(0.699D));
            this.Text10.Name = "Text10";
            this.Text10.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(0.642D), Telerik.Reporting.Drawing.Unit.Inch(0.333D));
            this.Text10.Style.BackgroundColor = System.Drawing.Color.Silver;
            this.Text10.Style.BorderColor.Default = System.Drawing.Color.Black;
            this.Text10.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.None;
            this.Text10.Style.Color = System.Drawing.Color.Black;
            this.Text10.Style.Font.Bold = true;
            this.Text10.Style.Font.Italic = false;
            this.Text10.Style.Font.Name = "Arial";
            this.Text10.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(10D);
            this.Text10.Style.Font.Strikeout = false;
            this.Text10.Style.Font.Underline = false;
            this.Text10.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Left;
            this.Text10.Style.Visible = true;
            this.Text10.Value = "Service\nProvider";
            // 
            // Text12
            // 
            this.Text12.CanGrow = false;
            this.Text12.CanShrink = false;
            this.Text12.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(10.118D), Telerik.Reporting.Drawing.Unit.Inch(0.814D));
            this.Text12.Name = "Text12";
            this.Text12.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(0.708D), Telerik.Reporting.Drawing.Unit.Inch(0.153D));
            this.Text12.Style.BackgroundColor = System.Drawing.Color.Silver;
            this.Text12.Style.BorderColor.Default = System.Drawing.Color.Black;
            this.Text12.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.None;
            this.Text12.Style.Color = System.Drawing.Color.Black;
            this.Text12.Style.Font.Bold = true;
            this.Text12.Style.Font.Italic = false;
            this.Text12.Style.Font.Name = "Arial";
            this.Text12.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(10D);
            this.Text12.Style.Font.Strikeout = false;
            this.Text12.Style.Font.Underline = false;
            this.Text12.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center;
            this.Text12.Style.Visible = true;
            this.Text12.Value = "Cost";
            // 
            // Text14
            // 
            this.Text14.CanGrow = false;
            this.Text14.CanShrink = false;
            this.Text14.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(7.423D), Telerik.Reporting.Drawing.Unit.Inch(0.848D));
            this.Text14.Name = "Text14";
            this.Text14.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(0.875D), Telerik.Reporting.Drawing.Unit.Inch(0.153D));
            this.Text14.Style.BackgroundColor = System.Drawing.Color.Silver;
            this.Text14.Style.BorderColor.Default = System.Drawing.Color.Black;
            this.Text14.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.None;
            this.Text14.Style.Color = System.Drawing.Color.Black;
            this.Text14.Style.Font.Bold = true;
            this.Text14.Style.Font.Italic = false;
            this.Text14.Style.Font.Name = "Arial";
            this.Text14.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(10D);
            this.Text14.Style.Font.Strikeout = false;
            this.Text14.Style.Font.Underline = false;
            this.Text14.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Left;
            this.Text14.Style.Visible = true;
            this.Text14.Value = "Mechanic";
            // 
            // Text5
            // 
            this.Text5.CanGrow = false;
            this.Text5.CanShrink = false;
            this.Text5.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(6.5D), Telerik.Reporting.Drawing.Unit.Inch(0.741D));
            this.Text5.Name = "Text5";
            this.Text5.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(0.875D), Telerik.Reporting.Drawing.Unit.Inch(0.323D));
            this.Text5.Style.BackgroundColor = System.Drawing.Color.Silver;
            this.Text5.Style.BorderColor.Default = System.Drawing.Color.Black;
            this.Text5.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.None;
            this.Text5.Style.Color = System.Drawing.Color.Black;
            this.Text5.Style.Font.Bold = true;
            this.Text5.Style.Font.Italic = false;
            this.Text5.Style.Font.Name = "Arial";
            this.Text5.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(10D);
            this.Text5.Style.Font.Strikeout = false;
            this.Text5.Style.Font.Underline = false;
            this.Text5.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Left;
            this.Text5.Style.Visible = true;
            this.Text5.Value = "Service Type\n";
            // 
            // Text9
            // 
            this.Text9.CanGrow = false;
            this.Text9.CanShrink = false;
            this.Text9.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(9.055D), Telerik.Reporting.Drawing.Unit.Inch(0.793D));
            this.Text9.Name = "Text9";
            this.Text9.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(1D), Telerik.Reporting.Drawing.Unit.Inch(0.153D));
            this.Text9.Style.BackgroundColor = System.Drawing.Color.Silver;
            this.Text9.Style.BorderColor.Default = System.Drawing.Color.Black;
            this.Text9.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.None;
            this.Text9.Style.Color = System.Drawing.Color.Black;
            this.Text9.Style.Font.Bold = true;
            this.Text9.Style.Font.Italic = false;
            this.Text9.Style.Font.Name = "Arial";
            this.Text9.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(10D);
            this.Text9.Style.Font.Strikeout = false;
            this.Text9.Style.Font.Underline = false;
            this.Text9.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Left;
            this.Text9.Style.Visible = true;
            this.Text9.Value = "Description";
            // 
            // Text11
            // 
            this.Text11.CanGrow = false;
            this.Text11.CanShrink = false;
            this.Text11.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(10.899D), Telerik.Reporting.Drawing.Unit.Inch(0.793D));
            this.Text11.Name = "Text11";
            this.Text11.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(0.708D), Telerik.Reporting.Drawing.Unit.Inch(0.153D));
            this.Text11.Style.BackgroundColor = System.Drawing.Color.Silver;
            this.Text11.Style.BorderColor.Default = System.Drawing.Color.Black;
            this.Text11.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.None;
            this.Text11.Style.Color = System.Drawing.Color.Black;
            this.Text11.Style.Font.Bold = true;
            this.Text11.Style.Font.Italic = false;
            this.Text11.Style.Font.Name = "Arial";
            this.Text11.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(10D);
            this.Text11.Style.Font.Strikeout = false;
            this.Text11.Style.Font.Underline = false;
            this.Text11.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Left;
            this.Text11.Style.Visible = true;
            this.Text11.Value = "PO Ref";
            // 
            // imgLogo
            // 
            this.imgLogo.Anchoring = Telerik.Reporting.AnchoringStyles.Top;
            this.imgLogo.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Mm(5.46D), Telerik.Reporting.Drawing.Unit.Inch(0D));
            this.imgLogo.MimeType = "image/png";
            this.imgLogo.Name = "imgLogo";
            this.imgLogo.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Mm(37.4D), Telerik.Reporting.Drawing.Unit.Mm(14.16D));
            this.imgLogo.Sizing = Telerik.Reporting.Drawing.ImageSizeMode.Stretch;
            this.imgLogo.Value = ((object)(resources.GetObject("imgLogo.Value")));
            // 
            // Area3
            // 
            this.Area3.Height = Telerik.Reporting.Drawing.Unit.Inch(0.271D);
            this.Area3.Items.AddRange(new Telerik.Reporting.ReportItemBase[] {
            this.Year1,
            this.RegistrationNumber1,
            this.VehicleDescription1,
            this.Center1,
            this.ServiceDate1,
            this.ServiceEndDate1,
            this.ServiceType1,
            this.Mechanic1,
            this.ServiceProvider1,
            this.Description1,
            this.Cost1,
            this.PORefNumber1});
            this.Area3.KeepTogether = false;
            this.Area3.Name = "Area3";
            this.Area3.PageBreak = Telerik.Reporting.PageBreak.None;
            this.Area3.Style.BackgroundColor = System.Drawing.Color.White;
            this.Area3.Style.Visible = true;
            // 
            // Year1
            // 
            this.Year1.CanGrow = true;
            this.Year1.CanShrink = false;
            this.Year1.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(0.08D), Telerik.Reporting.Drawing.Unit.Inch(0.069D));
            this.Year1.Name = "Year1";
            this.Year1.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(0.643D), Telerik.Reporting.Drawing.Unit.Inch(0.16D));
            this.Year1.Style.BackgroundColor = System.Drawing.Color.White;
            this.Year1.Style.BorderColor.Default = System.Drawing.Color.Black;
            this.Year1.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.None;
            this.Year1.Style.Color = System.Drawing.Color.Black;
            this.Year1.Style.Font.Bold = false;
            this.Year1.Style.Font.Italic = false;
            this.Year1.Style.Font.Name = "Arial";
            this.Year1.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(10D);
            this.Year1.Style.Font.Strikeout = false;
            this.Year1.Style.Font.Underline = false;
            this.Year1.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Left;
            this.Year1.Style.Visible = true;
            this.Year1.Value = "=Fields.[Year]";
            // 
            // RegistrationNumber1
            // 
            this.RegistrationNumber1.CanGrow = true;
            this.RegistrationNumber1.CanShrink = false;
            this.RegistrationNumber1.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(0.764D), Telerik.Reporting.Drawing.Unit.Inch(0.08D));
            this.RegistrationNumber1.Name = "RegistrationNumber1";
            this.RegistrationNumber1.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(0.907D), Telerik.Reporting.Drawing.Unit.Inch(0.16D));
            this.RegistrationNumber1.Style.BackgroundColor = System.Drawing.Color.White;
            this.RegistrationNumber1.Style.BorderColor.Default = System.Drawing.Color.Black;
            this.RegistrationNumber1.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.None;
            this.RegistrationNumber1.Style.Color = System.Drawing.Color.Black;
            this.RegistrationNumber1.Style.Font.Bold = false;
            this.RegistrationNumber1.Style.Font.Italic = false;
            this.RegistrationNumber1.Style.Font.Name = "Arial";
            this.RegistrationNumber1.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(10D);
            this.RegistrationNumber1.Style.Font.Strikeout = false;
            this.RegistrationNumber1.Style.Font.Underline = false;
            this.RegistrationNumber1.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Left;
            this.RegistrationNumber1.Style.Visible = true;
            this.RegistrationNumber1.Value = "=Fields.[Registration Number]";
            // 
            // VehicleDescription1
            // 
            this.VehicleDescription1.CanGrow = true;
            this.VehicleDescription1.CanShrink = false;
            this.VehicleDescription1.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(1.75D), Telerik.Reporting.Drawing.Unit.Inch(0.069D));
            this.VehicleDescription1.Name = "VehicleDescription1";
            this.VehicleDescription1.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(1.657D), Telerik.Reporting.Drawing.Unit.Inch(0.16D));
            this.VehicleDescription1.Style.BackgroundColor = System.Drawing.Color.White;
            this.VehicleDescription1.Style.BorderColor.Default = System.Drawing.Color.Black;
            this.VehicleDescription1.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.None;
            this.VehicleDescription1.Style.Color = System.Drawing.Color.Black;
            this.VehicleDescription1.Style.Font.Bold = false;
            this.VehicleDescription1.Style.Font.Italic = false;
            this.VehicleDescription1.Style.Font.Name = "Arial";
            this.VehicleDescription1.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(10D);
            this.VehicleDescription1.Style.Font.Strikeout = false;
            this.VehicleDescription1.Style.Font.Underline = false;
            this.VehicleDescription1.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Left;
            this.VehicleDescription1.Style.Visible = true;
            this.VehicleDescription1.Value = "=Fields.[Vehicle Description]";
            // 
            // Center1
            // 
            this.Center1.CanGrow = true;
            this.Center1.CanShrink = false;
            this.Center1.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(3.462D), Telerik.Reporting.Drawing.Unit.Inch(0.08D));
            this.Center1.Name = "Center1";
            this.Center1.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(1.074D), Telerik.Reporting.Drawing.Unit.Inch(0.16D));
            this.Center1.Style.BackgroundColor = System.Drawing.Color.White;
            this.Center1.Style.BorderColor.Default = System.Drawing.Color.Black;
            this.Center1.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.None;
            this.Center1.Style.Color = System.Drawing.Color.Black;
            this.Center1.Style.Font.Bold = false;
            this.Center1.Style.Font.Italic = false;
            this.Center1.Style.Font.Name = "Arial";
            this.Center1.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(10D);
            this.Center1.Style.Font.Strikeout = false;
            this.Center1.Style.Font.Underline = false;
            this.Center1.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Left;
            this.Center1.Style.Visible = true;
            this.Center1.Value = "=Fields.[Center]";
            // 
            // ServiceDate1
            // 
            this.ServiceDate1.CanGrow = true;
            this.ServiceDate1.CanShrink = false;
            this.ServiceDate1.Format = "{0:d}";
            this.ServiceDate1.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(4.58D), Telerik.Reporting.Drawing.Unit.Inch(0.09D));
            this.ServiceDate1.Name = "ServiceDate1";
            this.ServiceDate1.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(0.995D), Telerik.Reporting.Drawing.Unit.Inch(0.16D));
            this.ServiceDate1.Style.BackgroundColor = System.Drawing.Color.White;
            this.ServiceDate1.Style.BorderColor.Default = System.Drawing.Color.Black;
            this.ServiceDate1.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.None;
            this.ServiceDate1.Style.Color = System.Drawing.Color.Black;
            this.ServiceDate1.Style.Font.Bold = false;
            this.ServiceDate1.Style.Font.Italic = false;
            this.ServiceDate1.Style.Font.Name = "Arial";
            this.ServiceDate1.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(10D);
            this.ServiceDate1.Style.Font.Strikeout = false;
            this.ServiceDate1.Style.Font.Underline = false;
            this.ServiceDate1.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Left;
            this.ServiceDate1.Style.Visible = true;
            this.ServiceDate1.Value = "=Fields.[ServiceDate]";
            // 
            // ServiceEndDate1
            // 
            this.ServiceEndDate1.CanGrow = true;
            this.ServiceEndDate1.CanShrink = false;
            this.ServiceEndDate1.Format = "{0:d}";
            this.ServiceEndDate1.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(5.575D), Telerik.Reporting.Drawing.Unit.Inch(0.111D));
            this.ServiceEndDate1.Name = "ServiceEndDate1";
            this.ServiceEndDate1.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(0.825D), Telerik.Reporting.Drawing.Unit.Inch(0.16D));
            this.ServiceEndDate1.Style.BackgroundColor = System.Drawing.Color.White;
            this.ServiceEndDate1.Style.BorderColor.Default = System.Drawing.Color.Black;
            this.ServiceEndDate1.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.None;
            this.ServiceEndDate1.Style.Color = System.Drawing.Color.Black;
            this.ServiceEndDate1.Style.Font.Bold = false;
            this.ServiceEndDate1.Style.Font.Italic = false;
            this.ServiceEndDate1.Style.Font.Name = "Arial";
            this.ServiceEndDate1.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(10D);
            this.ServiceEndDate1.Style.Font.Strikeout = false;
            this.ServiceEndDate1.Style.Font.Underline = false;
            this.ServiceEndDate1.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Left;
            this.ServiceEndDate1.Style.Visible = true;
            this.ServiceEndDate1.Value = "=Fields.[ServiceEndDate]";
            // 
            // ServiceType1
            // 
            this.ServiceType1.CanGrow = true;
            this.ServiceType1.CanShrink = false;
            this.ServiceType1.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(6.489D), Telerik.Reporting.Drawing.Unit.Inch(0.111D));
            this.ServiceType1.Name = "ServiceType1";
            this.ServiceType1.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(0.875D), Telerik.Reporting.Drawing.Unit.Inch(0.16D));
            this.ServiceType1.Style.BackgroundColor = System.Drawing.Color.White;
            this.ServiceType1.Style.BorderColor.Default = System.Drawing.Color.Black;
            this.ServiceType1.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.None;
            this.ServiceType1.Style.Color = System.Drawing.Color.Black;
            this.ServiceType1.Style.Font.Bold = false;
            this.ServiceType1.Style.Font.Italic = false;
            this.ServiceType1.Style.Font.Name = "Arial";
            this.ServiceType1.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(10D);
            this.ServiceType1.Style.Font.Strikeout = false;
            this.ServiceType1.Style.Font.Underline = false;
            this.ServiceType1.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Left;
            this.ServiceType1.Style.Visible = true;
            this.ServiceType1.Value = "=Fields.[ServiceType]";
            // 
            // Mechanic1
            // 
            this.Mechanic1.CanGrow = true;
            this.Mechanic1.CanShrink = false;
            this.Mechanic1.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(7.413D), Telerik.Reporting.Drawing.Unit.Inch(0.111D));
            this.Mechanic1.Name = "Mechanic1";
            this.Mechanic1.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(0.875D), Telerik.Reporting.Drawing.Unit.Inch(0.16D));
            this.Mechanic1.Style.BackgroundColor = System.Drawing.Color.White;
            this.Mechanic1.Style.BorderColor.Default = System.Drawing.Color.Black;
            this.Mechanic1.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.None;
            this.Mechanic1.Style.Color = System.Drawing.Color.Black;
            this.Mechanic1.Style.Font.Bold = false;
            this.Mechanic1.Style.Font.Italic = false;
            this.Mechanic1.Style.Font.Name = "Arial";
            this.Mechanic1.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(10D);
            this.Mechanic1.Style.Font.Strikeout = false;
            this.Mechanic1.Style.Font.Underline = false;
            this.Mechanic1.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Left;
            this.Mechanic1.Style.Visible = true;
            this.Mechanic1.Value = "=Fields.[Mechanic]";
            // 
            // ServiceProvider1
            // 
            this.ServiceProvider1.CanGrow = true;
            this.ServiceProvider1.CanShrink = false;
            this.ServiceProvider1.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(8.368D), Telerik.Reporting.Drawing.Unit.Inch(0.08D));
            this.ServiceProvider1.Name = "ServiceProvider1";
            this.ServiceProvider1.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(0.642D), Telerik.Reporting.Drawing.Unit.Inch(0.16D));
            this.ServiceProvider1.Style.BackgroundColor = System.Drawing.Color.White;
            this.ServiceProvider1.Style.BorderColor.Default = System.Drawing.Color.Black;
            this.ServiceProvider1.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.None;
            this.ServiceProvider1.Style.Color = System.Drawing.Color.Black;
            this.ServiceProvider1.Style.Font.Bold = false;
            this.ServiceProvider1.Style.Font.Italic = false;
            this.ServiceProvider1.Style.Font.Name = "Arial";
            this.ServiceProvider1.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(10D);
            this.ServiceProvider1.Style.Font.Strikeout = false;
            this.ServiceProvider1.Style.Font.Underline = false;
            this.ServiceProvider1.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Left;
            this.ServiceProvider1.Style.Visible = true;
            this.ServiceProvider1.Value = "=Fields.[ServiceProvider]";
            // 
            // Description1
            // 
            this.Description1.CanGrow = true;
            this.Description1.CanShrink = false;
            this.Description1.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(9.055D), Telerik.Reporting.Drawing.Unit.Inch(0.08D));
            this.Description1.Name = "Description1";
            this.Description1.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(1D), Telerik.Reporting.Drawing.Unit.Inch(0.16D));
            this.Description1.Style.BackgroundColor = System.Drawing.Color.White;
            this.Description1.Style.BorderColor.Default = System.Drawing.Color.Black;
            this.Description1.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.None;
            this.Description1.Style.Color = System.Drawing.Color.Black;
            this.Description1.Style.Font.Bold = false;
            this.Description1.Style.Font.Italic = false;
            this.Description1.Style.Font.Name = "Arial";
            this.Description1.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(10D);
            this.Description1.Style.Font.Strikeout = false;
            this.Description1.Style.Font.Underline = false;
            this.Description1.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Left;
            this.Description1.Style.Visible = true;
            this.Description1.Value = "=Fields.[Description]";
            // 
            // Cost1
            // 
            this.Cost1.CanGrow = true;
            this.Cost1.CanShrink = false;
            this.Cost1.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(10.114D), Telerik.Reporting.Drawing.Unit.Inch(0.059D));
            this.Cost1.Name = "Cost1";
            this.Cost1.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(0.708D), Telerik.Reporting.Drawing.Unit.Inch(0.16D));
            this.Cost1.Style.BackgroundColor = System.Drawing.Color.White;
            this.Cost1.Style.BorderColor.Default = System.Drawing.Color.Black;
            this.Cost1.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.None;
            this.Cost1.Style.Color = System.Drawing.Color.Black;
            this.Cost1.Style.Font.Bold = false;
            this.Cost1.Style.Font.Italic = false;
            this.Cost1.Style.Font.Name = "Arial";
            this.Cost1.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(10D);
            this.Cost1.Style.Font.Strikeout = false;
            this.Cost1.Style.Font.Underline = false;
            this.Cost1.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center;
            this.Cost1.Style.Visible = true;
            this.Cost1.Value = "=Fields.[Cost]";
            // 
            // PORefNumber1
            // 
            this.PORefNumber1.CanGrow = true;
            this.PORefNumber1.CanShrink = false;
            this.PORefNumber1.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(10.899D), Telerik.Reporting.Drawing.Unit.Inch(0.069D));
            this.PORefNumber1.Name = "PORefNumber1";
            this.PORefNumber1.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(0.708D), Telerik.Reporting.Drawing.Unit.Inch(0.16D));
            this.PORefNumber1.Style.BackgroundColor = System.Drawing.Color.White;
            this.PORefNumber1.Style.BorderColor.Default = System.Drawing.Color.Black;
            this.PORefNumber1.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.None;
            this.PORefNumber1.Style.Color = System.Drawing.Color.Black;
            this.PORefNumber1.Style.Font.Bold = false;
            this.PORefNumber1.Style.Font.Italic = false;
            this.PORefNumber1.Style.Font.Name = "Arial";
            this.PORefNumber1.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(10D);
            this.PORefNumber1.Style.Font.Strikeout = false;
            this.PORefNumber1.Style.Font.Underline = false;
            this.PORefNumber1.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Left;
            this.PORefNumber1.Style.Visible = true;
            this.PORefNumber1.Value = "=Fields.[PORefNumber]";
            // 
            // Area4
            // 
            this.Area4.Height = Telerik.Reporting.Drawing.Unit.Inch(0.222D);
            this.Area4.KeepTogether = false;
            this.Area4.Name = "Area4";
            this.Area4.PageBreak = Telerik.Reporting.PageBreak.After;
            this.Area4.Style.BackgroundColor = System.Drawing.Color.White;
            this.Area4.Style.Visible = true;
            // 
            // Area5
            // 
            this.Area5.Height = Telerik.Reporting.Drawing.Unit.Inch(0.316D);
            this.Area5.Items.AddRange(new Telerik.Reporting.ReportItemBase[] {
            this.Box2,
            this.PageNofM1});
            this.Area5.Name = "Area5";
            this.Area5.PrintOnFirstPage = true;
            this.Area5.PrintOnLastPage = true;
            this.Area5.Style.BackgroundColor = System.Drawing.Color.White;
            this.Area5.Style.Visible = true;
            // 
            // Box2
            // 
            this.Box2.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(0.052D), Telerik.Reporting.Drawing.Unit.Inch(0.001D));
            this.Box2.Name = "Box2";
            this.Box2.ShapeType = new Telerik.Reporting.Drawing.Shapes.PolygonShape(4, 45D, 0);
            this.Box2.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(11.555D), Telerik.Reporting.Drawing.Unit.Inch(0.245D));
            this.Box2.Stretch = true;
            this.Box2.Style.BackgroundColor = System.Drawing.Color.Silver;
            this.Box2.Style.Color = System.Drawing.Color.Silver;
            this.Box2.Style.LineStyle = Telerik.Reporting.Drawing.LineStyle.Solid;
            this.Box2.Style.LineWidth = Telerik.Reporting.Drawing.Unit.Point(1D);
            this.Box2.Style.Visible = true;
            // 
            // PageNofM1
            // 
            this.PageNofM1.CanGrow = false;
            this.PageNofM1.CanShrink = false;
            this.PageNofM1.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(9.847D), Telerik.Reporting.Drawing.Unit.Inch(0.016D));
            this.PageNofM1.Name = "PageNofM1";
            this.PageNofM1.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(1.385D), Telerik.Reporting.Drawing.Unit.Inch(0.16D));
            this.PageNofM1.Style.BackgroundColor = System.Drawing.Color.Silver;
            this.PageNofM1.Style.BorderColor.Default = System.Drawing.Color.Black;
            this.PageNofM1.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.None;
            this.PageNofM1.Style.Color = System.Drawing.Color.Black;
            this.PageNofM1.Style.Font.Bold = false;
            this.PageNofM1.Style.Font.Italic = false;
            this.PageNofM1.Style.Font.Name = "Arial";
            this.PageNofM1.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(10D);
            this.PageNofM1.Style.Font.Strikeout = false;
            this.PageNofM1.Style.Font.Underline = false;
            this.PageNofM1.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Right;
            this.PageNofM1.Style.Visible = true;
            this.PageNofM1.Value = "=\"Page \" + PageNumber + \" of \" + PageCount";
            // 
            // sqdsServiceDetailsReport
            // 
            this.sqdsServiceDetailsReport.ConnectionString = "FMSEntities";
            this.sqdsServiceDetailsReport.Name = "sqdsServiceDetailsReport";
            this.sqdsServiceDetailsReport.SelectCommand = " SELECT * \r\n FROM   \"ServiceDetailsReport\" \"ServiceDetailsReport\"\r\n ORDER BY \"Ser" +
    "viceDetailsReport\".\"BusinessGroup\"\r\n\r\n\r\n";
            // 
            // ServiceDetailsReport
            // 
            this.DataSource = this.sqdsServiceDetailsReport;
            this.Filters.Add(new Telerik.Reporting.Filter("= IIF(Fields.[Registration Number] is null, \"true\" ,Fields.[Registration Number])" +
            "", Telerik.Reporting.FilterOperator.Equal, "= IIF(Parameters.paramRegistrationNumber.Value is null, IsNull(Fields.[Registrati" +
            "on Number],\"true\"),Parameters.paramRegistrationNumber.Value)"));
            this.Filters.Add(new Telerik.Reporting.Filter("= IIF(Fields.BusinessGroup is null, \"true\" ,Fields.BusinessGroup)", Telerik.Reporting.FilterOperator.Equal, "= IIF(Parameters.paramBusinessGroup.Value is null, IsNull(Fields.BusinessGroup,\"t" +
            "rue\"),Parameters.paramBusinessGroup.Value)"));
            this.Filters.Add(new Telerik.Reporting.Filter("= IIF(Fields.BusinessUnit is null, \"true\" ,Fields.BusinessUnit)", Telerik.Reporting.FilterOperator.Equal, "= IIF(Parameters.paramBusinessUnit.Value is null, IsNull(Fields.BusinessUnit,\"tru" +
            "e\"),Parameters.paramBusinessUnit.Value)"));
            this.Filters.Add(new Telerik.Reporting.Filter("= IIF(Fields.Center is null, \"true\" ,Fields.Center)", Telerik.Reporting.FilterOperator.Equal, "= IIF(Parameters.paramCenter.Value is null, IsNull(Fields.Center,\"true\"),Paramete" +
            "rs.paramCenter.Value)"));
            this.Filters.Add(new Telerik.Reporting.Filter("= IIF(Fields.InService is null, \"true\" ,Fields.InService)", Telerik.Reporting.FilterOperator.Equal, "= IIF(Parameters.paramIsInService.Value is null, IsNull(Fields.InService,\"true\")," +
            "Parameters.paramIsInService.Value)"));
            this.Filters.Add(new Telerik.Reporting.Filter("= IIF(Fields.ServiceType is null, \"true\" ,Fields.ServiceType)", Telerik.Reporting.FilterOperator.Equal, "= IIF(Parameters.paramServiceType.Value is null, IsNull(Fields.ServiceType,\"true\"" +
            "),Parameters.paramServiceType.Value)"));
            this.Filters.Add(new Telerik.Reporting.Filter("= IIF(Fields.ServiceProvider is null, \"true\" ,Fields.ServiceProvider)", Telerik.Reporting.FilterOperator.Equal, "= IIF(Parameters.paramServiceProvider.Value is null, IsNull(Fields.ServiceProvide" +
            "r,\"true\"),Parameters.paramServiceProvider.Value)"));
            group1.GroupFooter = this.GroupFooterArea2;
            group1.GroupHeader = this.GroupHeaderArea2;
            group1.Groupings.Add(new Telerik.Reporting.Grouping("=Fields.[BusinessGroup]"));
            group1.Sortings.Add(new Telerik.Reporting.Sorting("=Fields.[BusinessGroup]", Telerik.Reporting.SortDirection.Asc));
            this.Groups.AddRange(new Telerik.Reporting.Group[] {
            group1});
            this.Items.AddRange(new Telerik.Reporting.ReportItemBase[] {
            this.GroupHeaderArea2,
            this.GroupFooterArea2,
            this.Area2,
            this.Area3,
            this.Area4,
            this.Area5});
            this.Name = "Servicedetailsreport";
            this.PageSettings.Landscape = true;
            this.PageSettings.Margins = new Telerik.Reporting.Drawing.MarginsU(Telerik.Reporting.Drawing.Unit.Mm(0.25D), Telerik.Reporting.Drawing.Unit.Mm(0.25D), Telerik.Reporting.Drawing.Unit.Mm(0.25D), Telerik.Reporting.Drawing.Unit.Mm(0.25D));
            this.PageSettings.PaperKind = System.Drawing.Printing.PaperKind.A4;
            reportParameter1.AllowNull = true;
            reportParameter1.Name = "paramServiceAlertDateFrom";
            reportParameter1.Type = Telerik.Reporting.ReportParameterType.DateTime;
            reportParameter2.AllowNull = true;
            reportParameter2.Name = "paramServiceAlertDateTo";
            reportParameter2.Type = Telerik.Reporting.ReportParameterType.DateTime;
            reportParameter3.AllowNull = true;
            reportParameter3.Name = "paramRegistrationNumber";
            reportParameter4.AllowNull = true;
            reportParameter4.Name = "paramServiceType";
            reportParameter5.AllowNull = true;
            reportParameter5.Name = "paramServiceProvider";
            reportParameter6.AllowNull = true;
            reportParameter6.Name = "paramIsInService";
            reportParameter7.AllowNull = true;
            reportParameter7.Name = "paramCenter";
            reportParameter8.AllowNull = true;
            reportParameter8.Name = "paramBusinessUnit";
            reportParameter9.AllowNull = true;
            reportParameter9.Name = "paramBusinessGroup";
            this.ReportParameters.Add(reportParameter1);
            this.ReportParameters.Add(reportParameter2);
            this.ReportParameters.Add(reportParameter3);
            this.ReportParameters.Add(reportParameter4);
            this.ReportParameters.Add(reportParameter5);
            this.ReportParameters.Add(reportParameter6);
            this.ReportParameters.Add(reportParameter7);
            this.ReportParameters.Add(reportParameter8);
            this.ReportParameters.Add(reportParameter9);
            styleRule1.Selectors.AddRange(new Telerik.Reporting.Drawing.ISelector[] {
            new Telerik.Reporting.Drawing.TypeSelector(typeof(Telerik.Reporting.TextItemBase)),
            new Telerik.Reporting.Drawing.TypeSelector(typeof(Telerik.Reporting.HtmlTextBox))});
            styleRule1.Style.Padding.Left = Telerik.Reporting.Drawing.Unit.Point(2D);
            styleRule1.Style.Padding.Right = Telerik.Reporting.Drawing.Unit.Point(2D);
            this.StyleSheet.AddRange(new Telerik.Reporting.Drawing.StyleRule[] {
            styleRule1});
            this.UnitOfMeasure = Telerik.Reporting.Drawing.UnitType.Mm;
            this.Width = Telerik.Reporting.Drawing.Unit.Mm(297D);
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

        }
        #endregion
        private Telerik.Reporting.TextBox Text17;
        private Telerik.Reporting.TextBox PrintDate1;
        private Telerik.Reporting.TextBox Text8;
        private Telerik.Reporting.PageHeaderSection Area2;
        private Telerik.Reporting.Shape Box1;
        private Telerik.Reporting.TextBox Text13;
        private Telerik.Reporting.TextBox Text2;
        private Telerik.Reporting.TextBox Text3;
        private Telerik.Reporting.TextBox Text4;
        private Telerik.Reporting.TextBox Text6;
        private Telerik.Reporting.TextBox Text7;
        private Telerik.Reporting.TextBox Text10;
        private Telerik.Reporting.TextBox Text12;
        private Telerik.Reporting.TextBox Text14;
        private Telerik.Reporting.TextBox Text5;
        private Telerik.Reporting.TextBox Text9;
        private Telerik.Reporting.TextBox Text11;
        private Telerik.Reporting.DetailSection Area3;
        private Telerik.Reporting.TextBox Year1;
        private Telerik.Reporting.TextBox RegistrationNumber1;
        private Telerik.Reporting.TextBox VehicleDescription1;
        private Telerik.Reporting.TextBox Center1;
        private Telerik.Reporting.TextBox ServiceDate1;
        private Telerik.Reporting.TextBox ServiceEndDate1;
        private Telerik.Reporting.TextBox ServiceType1;
        private Telerik.Reporting.TextBox Mechanic1;
        private Telerik.Reporting.TextBox ServiceProvider1;
        private Telerik.Reporting.TextBox Description1;
        private Telerik.Reporting.TextBox Cost1;
        private Telerik.Reporting.TextBox PORefNumber1;
        private Telerik.Reporting.ReportFooterSection Area4;
        private Telerik.Reporting.PageFooterSection Area5;
        private Telerik.Reporting.TextBox PageNofM1;
        private Telerik.Reporting.Shape Box2;
        private Telerik.Reporting.GroupHeaderSection GroupHeaderArea2;
        private Telerik.Reporting.TextBox GroupNameBusinessGroup1;
        private Telerik.Reporting.GroupFooterSection GroupFooterArea2;
        private Telerik.Reporting.PictureBox imgLogo;
        private Telerik.Reporting.SqlDataSource sqdsServiceDetailsReport;
    }
}