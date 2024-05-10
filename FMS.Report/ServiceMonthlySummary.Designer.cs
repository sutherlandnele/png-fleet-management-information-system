namespace FMS.Report
{
    partial class ServiceMonthlySummary
    {
        #region Component Designer generated code
        /// <summary>
        /// Required method for telerik Reporting designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ServiceMonthlySummary));
            Telerik.Reporting.Drawing.StyleRule styleRule1 = new Telerik.Reporting.Drawing.StyleRule();

            Telerik.Reporting.ReportParameter reportParameter1 = new Telerik.Reporting.ReportParameter();
            Telerik.Reporting.ReportParameter reportParameter2 = new Telerik.Reporting.ReportParameter();
            Telerik.Reporting.ReportParameter reportParameter3 = new Telerik.Reporting.ReportParameter();
            Telerik.Reporting.ReportParameter reportParameter4 = new Telerik.Reporting.ReportParameter();
            Telerik.Reporting.ReportParameter reportParameter5 = new Telerik.Reporting.ReportParameter();
            Telerik.Reporting.ReportParameter reportParameter6 = new Telerik.Reporting.ReportParameter();
            Telerik.Reporting.ReportParameter reportParameter7 = new Telerik.Reporting.ReportParameter();
            Telerik.Reporting.ReportParameter reportParameter8 = new Telerik.Reporting.ReportParameter();
            Telerik.Reporting.ReportParameter reportParameter9 = new Telerik.Reporting.ReportParameter();

            this.Text4 = new Telerik.Reporting.TextBox();
            this.PrintDate1 = new Telerik.Reporting.TextBox();
            this.Text1 = new Telerik.Reporting.TextBox();
            this.Area2 = new Telerik.Reporting.PageHeaderSection();
            this.Box3 = new Telerik.Reporting.Shape();
            this.Text16 = new Telerik.Reporting.TextBox();
            this.Text17 = new Telerik.Reporting.TextBox();
            this.Text18 = new Telerik.Reporting.TextBox();
            this.Text19 = new Telerik.Reporting.TextBox();
            this.Text20 = new Telerik.Reporting.TextBox();
            this.imgLogo = new Telerik.Reporting.PictureBox();
            this.Area3 = new Telerik.Reporting.DetailSection();
            this.Section3 = new Telerik.Reporting.Panel();
            this.CenterName1 = new Telerik.Reporting.TextBox();
            this.NumberofScheduleService1 = new Telerik.Reporting.TextBox();
            this.CostofScheduleService1 = new Telerik.Reporting.TextBox();
            this.NumberofOtherService1 = new Telerik.Reporting.TextBox();
            this.CostofOtherService1 = new Telerik.Reporting.TextBox();
            this.Area4 = new Telerik.Reporting.ReportFooterSection();
            this.Area5 = new Telerik.Reporting.PageFooterSection();
            this.Box1 = new Telerik.Reporting.Shape();
            this.PageNofM1 = new Telerik.Reporting.TextBox();
            this.sqldsServiceMonthlySummary = new Telerik.Reporting.SqlDataSource();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // Text4
            // 
            this.Text4.CanGrow = false;
            this.Text4.CanShrink = false;
            this.Text4.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(2.2D), Telerik.Reporting.Drawing.Unit.Inch(0.2D));
            this.Text4.Name = "Text4";
            this.Text4.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(3.483D), Telerik.Reporting.Drawing.Unit.Inch(0.266D));
            this.Text4.Style.BackgroundColor = System.Drawing.Color.White;
            this.Text4.Style.BorderColor.Default = System.Drawing.Color.Black;
            this.Text4.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.None;
            this.Text4.Style.Color = System.Drawing.Color.Black;
            this.Text4.Style.Font.Bold = false;
            this.Text4.Style.Font.Italic = false;
            this.Text4.Style.Font.Name = "Arial";
            this.Text4.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(16D);
            this.Text4.Style.Font.Strikeout = false;
            this.Text4.Style.Font.Underline = false;
            this.Text4.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Left;
            this.Text4.Style.Visible = true;
            this.Text4.Value = "Service Monthly Summary Report";
            // 
            // PrintDate1
            // 
            this.PrintDate1.CanGrow = false;
            this.PrintDate1.CanShrink = false;
            this.PrintDate1.Format = "{0:d}";
            this.PrintDate1.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(6.95D), Telerik.Reporting.Drawing.Unit.Inch(0.2D));
            this.PrintDate1.Name = "PrintDate1";
            this.PrintDate1.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(0.854D), Telerik.Reporting.Drawing.Unit.Inch(0.157D));
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
            this.PrintDate1.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Right;
            this.PrintDate1.Style.Visible = true;
            this.PrintDate1.Value = "=Now()";
            // 
            // Text1
            // 
            this.Text1.CanGrow = false;
            this.Text1.CanShrink = false;
            this.Text1.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(6.367D), Telerik.Reporting.Drawing.Unit.Inch(0.2D));
            this.Text1.Name = "Text1";
            this.Text1.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(0.448D), Telerik.Reporting.Drawing.Unit.Inch(0.157D));
            this.Text1.Style.BackgroundColor = System.Drawing.Color.White;
            this.Text1.Style.BorderColor.Default = System.Drawing.Color.Black;
            this.Text1.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.None;
            this.Text1.Style.Color = System.Drawing.Color.Black;
            this.Text1.Style.Font.Bold = false;
            this.Text1.Style.Font.Italic = false;
            this.Text1.Style.Font.Name = "Arial";
            this.Text1.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(10D);
            this.Text1.Style.Font.Strikeout = false;
            this.Text1.Style.Font.Underline = false;
            this.Text1.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Left;
            this.Text1.Style.Visible = true;
            this.Text1.Value = "Date:";
            // 
            // Area2
            // 
            this.Area2.Height = Telerik.Reporting.Drawing.Unit.Inch(1.117D);
            this.Area2.Items.AddRange(new Telerik.Reporting.ReportItemBase[] {
            this.Box3,
            this.Text16,
            this.Text17,
            this.Text18,
            this.Text19,
            this.Text20,
            this.Text4,
            this.Text1,
            this.PrintDate1,
            this.imgLogo});
            this.Area2.Name = "Area2";
            this.Area2.PrintOnFirstPage = true;
            this.Area2.PrintOnLastPage = true;
            this.Area2.Style.BackgroundColor = System.Drawing.Color.White;
            this.Area2.Style.Visible = true;
            // 
            // Box3
            // 
            this.Box3.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(0.083D), Telerik.Reporting.Drawing.Unit.Inch(0.558D));
            this.Box3.Name = "Box3";
            this.Box3.ShapeType = new Telerik.Reporting.Drawing.Shapes.PolygonShape(4, 45D, 0);
            this.Box3.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(8.017D), Telerik.Reporting.Drawing.Unit.Inch(0.46D));
            this.Box3.Stretch = true;
            this.Box3.Style.BackgroundColor = System.Drawing.Color.Silver;
            this.Box3.Style.Color = System.Drawing.Color.FromArgb(((int)(((byte)(61)))), ((int)(((byte)(152)))), ((int)(((byte)(193)))));
            this.Box3.Style.LineStyle = Telerik.Reporting.Drawing.LineStyle.Solid;
            this.Box3.Style.LineWidth = Telerik.Reporting.Drawing.Unit.Point(1D);
            this.Box3.Style.Visible = true;
            // 
            // Text16
            // 
            this.Text16.CanGrow = false;
            this.Text16.CanShrink = false;
            this.Text16.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(0.3D), Telerik.Reporting.Drawing.Unit.Inch(0.7D));
            this.Text16.Name = "Text16";
            this.Text16.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(0.833D), Telerik.Reporting.Drawing.Unit.Inch(0.153D));
            this.Text16.Style.BackgroundColor = System.Drawing.Color.Silver;
            this.Text16.Style.BorderColor.Default = System.Drawing.Color.Black;
            this.Text16.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.None;
            this.Text16.Style.Color = System.Drawing.Color.Black;
            this.Text16.Style.Font.Bold = true;
            this.Text16.Style.Font.Italic = false;
            this.Text16.Style.Font.Name = "Arial";
            this.Text16.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(10D);
            this.Text16.Style.Font.Strikeout = false;
            this.Text16.Style.Font.Underline = false;
            this.Text16.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Left;
            this.Text16.Style.Visible = true;
            this.Text16.Value = "Center";
            // 
            // Text17
            // 
            this.Text17.CanGrow = false;
            this.Text17.CanShrink = false;
            this.Text17.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(1.4D), Telerik.Reporting.Drawing.Unit.Inch(0.6D));
            this.Text17.Name = "Text17";
            this.Text17.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(1.667D), Telerik.Reporting.Drawing.Unit.Inch(0.37D));
            this.Text17.Style.BackgroundColor = System.Drawing.Color.Silver;
            this.Text17.Style.BorderColor.Default = System.Drawing.Color.Black;
            this.Text17.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.None;
            this.Text17.Style.Color = System.Drawing.Color.Black;
            this.Text17.Style.Font.Bold = true;
            this.Text17.Style.Font.Italic = false;
            this.Text17.Style.Font.Name = "Arial";
            this.Text17.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(10D);
            this.Text17.Style.Font.Strikeout = false;
            this.Text17.Style.Font.Underline = false;
            this.Text17.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Left;
            this.Text17.Style.Visible = true;
            this.Text17.Value = "Number of Schedule Service";
            // 
            // Text18
            // 
            this.Text18.CanGrow = false;
            this.Text18.CanShrink = false;
            this.Text18.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(3.3D), Telerik.Reporting.Drawing.Unit.Inch(0.6D));
            this.Text18.Name = "Text18";
            this.Text18.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(1.5D), Telerik.Reporting.Drawing.Unit.Inch(0.37D));
            this.Text18.Style.BackgroundColor = System.Drawing.Color.Silver;
            this.Text18.Style.BorderColor.Default = System.Drawing.Color.Black;
            this.Text18.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.None;
            this.Text18.Style.Color = System.Drawing.Color.Black;
            this.Text18.Style.Font.Bold = true;
            this.Text18.Style.Font.Italic = false;
            this.Text18.Style.Font.Name = "Arial";
            this.Text18.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(10D);
            this.Text18.Style.Font.Strikeout = false;
            this.Text18.Style.Font.Underline = false;
            this.Text18.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Left;
            this.Text18.Style.Visible = true;
            this.Text18.Value = "Cost of Schedule Service";
            // 
            // Text19
            // 
            this.Text19.CanGrow = false;
            this.Text19.CanShrink = false;
            this.Text19.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(5D), Telerik.Reporting.Drawing.Unit.Inch(0.6D));
            this.Text19.Name = "Text19";
            this.Text19.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(1.417D), Telerik.Reporting.Drawing.Unit.Inch(0.37D));
            this.Text19.Style.BackgroundColor = System.Drawing.Color.Silver;
            this.Text19.Style.BorderColor.Default = System.Drawing.Color.Black;
            this.Text19.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.None;
            this.Text19.Style.Color = System.Drawing.Color.Black;
            this.Text19.Style.Font.Bold = true;
            this.Text19.Style.Font.Italic = false;
            this.Text19.Style.Font.Name = "Arial";
            this.Text19.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(10D);
            this.Text19.Style.Font.Strikeout = false;
            this.Text19.Style.Font.Underline = false;
            this.Text19.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Left;
            this.Text19.Style.Visible = true;
            this.Text19.Value = "Number of Other Service";
            // 
            // Text20
            // 
            this.Text20.CanGrow = false;
            this.Text20.CanShrink = false;
            this.Text20.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(6.6D), Telerik.Reporting.Drawing.Unit.Inch(0.6D));
            this.Text20.Name = "Text20";
            this.Text20.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(1.25D), Telerik.Reporting.Drawing.Unit.Inch(0.37D));
            this.Text20.Style.BackgroundColor = System.Drawing.Color.Silver;
            this.Text20.Style.BorderColor.Default = System.Drawing.Color.Black;
            this.Text20.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.None;
            this.Text20.Style.Color = System.Drawing.Color.Black;
            this.Text20.Style.Font.Bold = true;
            this.Text20.Style.Font.Italic = false;
            this.Text20.Style.Font.Name = "Arial";
            this.Text20.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(10D);
            this.Text20.Style.Font.Strikeout = false;
            this.Text20.Style.Font.Underline = false;
            this.Text20.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Left;
            this.Text20.Style.Visible = true;
            this.Text20.Value = "Cost of Other Service";
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
            this.Area3.Height = Telerik.Reporting.Drawing.Unit.Inch(0.283D);
            this.Area3.Items.AddRange(new Telerik.Reporting.ReportItemBase[] {
            this.Section3});
            this.Area3.KeepTogether = false;
            this.Area3.Name = "Area3";
            this.Area3.PageBreak = Telerik.Reporting.PageBreak.None;
            this.Area3.Style.Visible = true;
            // 
            // Section3
            // 
            this.Section3.Items.AddRange(new Telerik.Reporting.ReportItemBase[] {
            this.CenterName1,
            this.NumberofScheduleService1,
            this.CostofScheduleService1,
            this.NumberofOtherService1,
            this.CostofOtherService1});
            this.Section3.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(0D), Telerik.Reporting.Drawing.Unit.Inch(0D));
            this.Section3.Name = "Section3";
            this.Section3.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(8.177D), Telerik.Reporting.Drawing.Unit.Inch(0.283D));
            this.Section3.Style.BackgroundColor = System.Drawing.Color.White;
            this.Section3.Style.Visible = true;
            // 
            // CenterName1
            // 
            this.CenterName1.CanGrow = false;
            this.CenterName1.CanShrink = false;
            this.CenterName1.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(0.3D), Telerik.Reporting.Drawing.Unit.Inch(0.083D));
            this.CenterName1.Name = "CenterName1";
            this.CenterName1.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(0.833D), Telerik.Reporting.Drawing.Unit.Inch(0.153D));
            this.CenterName1.Style.BackgroundColor = System.Drawing.Color.White;
            this.CenterName1.Style.BorderColor.Default = System.Drawing.Color.Black;
            this.CenterName1.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.None;
            this.CenterName1.Style.Color = System.Drawing.Color.Black;
            this.CenterName1.Style.Font.Bold = false;
            this.CenterName1.Style.Font.Italic = false;
            this.CenterName1.Style.Font.Name = "Arial";
            this.CenterName1.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(10D);
            this.CenterName1.Style.Font.Strikeout = false;
            this.CenterName1.Style.Font.Underline = false;
            this.CenterName1.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Left;
            this.CenterName1.Style.Visible = true;
            this.CenterName1.Value = "=Fields.[CenterName]";
            // 
            // NumberofScheduleService1
            // 
            this.NumberofScheduleService1.CanGrow = false;
            this.NumberofScheduleService1.CanShrink = false;
            this.NumberofScheduleService1.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(1.4D), Telerik.Reporting.Drawing.Unit.Inch(0.083D));
            this.NumberofScheduleService1.Name = "NumberofScheduleService1";
            this.NumberofScheduleService1.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(1.667D), Telerik.Reporting.Drawing.Unit.Inch(0.153D));
            this.NumberofScheduleService1.Style.BackgroundColor = System.Drawing.Color.White;
            this.NumberofScheduleService1.Style.BorderColor.Default = System.Drawing.Color.Black;
            this.NumberofScheduleService1.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.None;
            this.NumberofScheduleService1.Style.Color = System.Drawing.Color.Black;
            this.NumberofScheduleService1.Style.Font.Bold = false;
            this.NumberofScheduleService1.Style.Font.Italic = false;
            this.NumberofScheduleService1.Style.Font.Name = "Arial";
            this.NumberofScheduleService1.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(10D);
            this.NumberofScheduleService1.Style.Font.Strikeout = false;
            this.NumberofScheduleService1.Style.Font.Underline = false;
            this.NumberofScheduleService1.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Left;
            this.NumberofScheduleService1.Style.Visible = true;
            this.NumberofScheduleService1.Value = "=Fields.[NumberofScheduleService]";
            // 
            // CostofScheduleService1
            // 
            this.CostofScheduleService1.CanGrow = false;
            this.CostofScheduleService1.CanShrink = false;
            this.CostofScheduleService1.Format = "{0:C2}";
            this.CostofScheduleService1.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(3.3D), Telerik.Reporting.Drawing.Unit.Inch(0.083D));
            this.CostofScheduleService1.Name = "CostofScheduleService1";
            this.CostofScheduleService1.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(1.5D), Telerik.Reporting.Drawing.Unit.Inch(0.153D));
            this.CostofScheduleService1.Style.BackgroundColor = System.Drawing.Color.White;
            this.CostofScheduleService1.Style.BorderColor.Default = System.Drawing.Color.Black;
            this.CostofScheduleService1.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.None;
            this.CostofScheduleService1.Style.Color = System.Drawing.Color.Black;
            this.CostofScheduleService1.Style.Font.Bold = false;
            this.CostofScheduleService1.Style.Font.Italic = false;
            this.CostofScheduleService1.Style.Font.Name = "Arial";
            this.CostofScheduleService1.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(10D);
            this.CostofScheduleService1.Style.Font.Strikeout = false;
            this.CostofScheduleService1.Style.Font.Underline = false;
            this.CostofScheduleService1.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Left;
            this.CostofScheduleService1.Style.Visible = true;
            this.CostofScheduleService1.Value = "=Fields.[CostofScheduleService]";
            // 
            // NumberofOtherService1
            // 
            this.NumberofOtherService1.CanGrow = false;
            this.NumberofOtherService1.CanShrink = false;
            this.NumberofOtherService1.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(5D), Telerik.Reporting.Drawing.Unit.Inch(0.083D));
            this.NumberofOtherService1.Name = "NumberofOtherService1";
            this.NumberofOtherService1.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(1.417D), Telerik.Reporting.Drawing.Unit.Inch(0.153D));
            this.NumberofOtherService1.Style.BackgroundColor = System.Drawing.Color.White;
            this.NumberofOtherService1.Style.BorderColor.Default = System.Drawing.Color.Black;
            this.NumberofOtherService1.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.None;
            this.NumberofOtherService1.Style.Color = System.Drawing.Color.Black;
            this.NumberofOtherService1.Style.Font.Bold = false;
            this.NumberofOtherService1.Style.Font.Italic = false;
            this.NumberofOtherService1.Style.Font.Name = "Arial";
            this.NumberofOtherService1.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(10D);
            this.NumberofOtherService1.Style.Font.Strikeout = false;
            this.NumberofOtherService1.Style.Font.Underline = false;
            this.NumberofOtherService1.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Left;
            this.NumberofOtherService1.Style.Visible = true;
            this.NumberofOtherService1.Value = "=Fields.[NumberofOtherService]";
            // 
            // CostofOtherService1
            // 
            this.CostofOtherService1.CanGrow = false;
            this.CostofOtherService1.CanShrink = false;
            this.CostofOtherService1.Format = "{0:C2}";
            this.CostofOtherService1.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(6.6D), Telerik.Reporting.Drawing.Unit.Inch(0.083D));
            this.CostofOtherService1.Name = "CostofOtherService1";
            this.CostofOtherService1.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(1.25D), Telerik.Reporting.Drawing.Unit.Inch(0.153D));
            this.CostofOtherService1.Style.BackgroundColor = System.Drawing.Color.White;
            this.CostofOtherService1.Style.BorderColor.Default = System.Drawing.Color.Black;
            this.CostofOtherService1.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.None;
            this.CostofOtherService1.Style.Color = System.Drawing.Color.Black;
            this.CostofOtherService1.Style.Font.Bold = false;
            this.CostofOtherService1.Style.Font.Italic = false;
            this.CostofOtherService1.Style.Font.Name = "Arial";
            this.CostofOtherService1.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(10D);
            this.CostofOtherService1.Style.Font.Strikeout = false;
            this.CostofOtherService1.Style.Font.Underline = false;
            this.CostofOtherService1.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Left;
            this.CostofOtherService1.Style.Visible = true;
            this.CostofOtherService1.Value = "=Fields.[CostofOtherService]";
            // 
            // Area4
            // 
            this.Area4.Height = Telerik.Reporting.Drawing.Unit.Inch(0.18D);
            this.Area4.KeepTogether = false;
            this.Area4.Name = "Area4";
            this.Area4.PageBreak = Telerik.Reporting.PageBreak.None;
            this.Area4.Style.BackgroundColor = System.Drawing.Color.White;
            this.Area4.Style.Visible = true;
            // 
            // Area5
            // 
            this.Area5.Height = Telerik.Reporting.Drawing.Unit.Inch(0.475D);
            this.Area5.Items.AddRange(new Telerik.Reporting.ReportItemBase[] {
            this.Box1,
            this.PageNofM1});
            this.Area5.Name = "Area5";
            this.Area5.PrintOnFirstPage = true;
            this.Area5.PrintOnLastPage = true;
            this.Area5.Style.BackgroundColor = System.Drawing.Color.White;
            this.Area5.Style.Visible = true;
            // 
            // Box1
            // 
            this.Box1.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(0.083D), Telerik.Reporting.Drawing.Unit.Inch(0.083D));
            this.Box1.Name = "Box1";
            this.Box1.ShapeType = new Telerik.Reporting.Drawing.Shapes.PolygonShape(4, 45D, 0);
            this.Box1.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(8.017D), Telerik.Reporting.Drawing.Unit.Inch(0.292D));
            this.Box1.Stretch = true;
            this.Box1.Style.BackgroundColor = System.Drawing.Color.Silver;
            this.Box1.Style.Color = System.Drawing.Color.FromArgb(((int)(((byte)(61)))), ((int)(((byte)(152)))), ((int)(((byte)(193)))));
            this.Box1.Style.LineStyle = Telerik.Reporting.Drawing.LineStyle.Solid;
            this.Box1.Style.LineWidth = Telerik.Reporting.Drawing.Unit.Point(1D);
            this.Box1.Style.Visible = true;
            // 
            // PageNofM1
            // 
            this.PageNofM1.CanGrow = false;
            this.PageNofM1.CanShrink = false;
            this.PageNofM1.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(6.333D), Telerik.Reporting.Drawing.Unit.Inch(0.167D));
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
            // sqldsServiceMonthlySummary
            // 
            this.sqldsServiceMonthlySummary.ConnectionString = "FMSEntities";
            this.sqldsServiceMonthlySummary.Name = "sqldsServiceMonthlySummary";
            this.sqldsServiceMonthlySummary.SelectCommand = " SELECT * \r\n FROM   \"ServiceMonthlySummary\" \"ServiceMonthlySummary\"\r\n\r\n\r\n";
            // 
            // ServiceMonthlySummary
            // 
            this.DataSource = this.sqldsServiceMonthlySummary;

            this.Filters.Add(new Telerik.Reporting.Filter("= IIF(Fields.CenterName is null, \"true\" ,Fields.CenterName)", Telerik.Reporting.FilterOperator.Equal, "= IIF(Parameters.paramCenter.Value is null, IsNull(Fields.CenterName,\"true\"),Paramete" +
"rs.paramCenter.Value)"));

            this.Items.AddRange(new Telerik.Reporting.ReportItemBase[] {
            this.Area2,
            this.Area3,
            this.Area4,
            this.Area5});
            this.Name = "ServiceMonthlySummary";
            this.PageSettings.ContinuousPaper = false;
            this.PageSettings.Landscape = false;
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
            this.Width = Telerik.Reporting.Drawing.Unit.Mm(210D);
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

        }
        #endregion
        private Telerik.Reporting.TextBox Text4;
        private Telerik.Reporting.TextBox PrintDate1;
        private Telerik.Reporting.TextBox Text1;
        private Telerik.Reporting.PageHeaderSection Area2;
        private Telerik.Reporting.Shape Box3;
        private Telerik.Reporting.TextBox Text16;
        private Telerik.Reporting.TextBox Text17;
        private Telerik.Reporting.TextBox Text18;
        private Telerik.Reporting.TextBox Text19;
        private Telerik.Reporting.TextBox Text20;
        private Telerik.Reporting.DetailSection Area3;
        private Telerik.Reporting.Panel Section3;
        private Telerik.Reporting.TextBox CenterName1;
        private Telerik.Reporting.TextBox NumberofScheduleService1;
        private Telerik.Reporting.TextBox CostofScheduleService1;
        private Telerik.Reporting.TextBox NumberofOtherService1;
        private Telerik.Reporting.TextBox CostofOtherService1;
        private Telerik.Reporting.ReportFooterSection Area4;
        private Telerik.Reporting.PageFooterSection Area5;
        private Telerik.Reporting.Shape Box1;
        private Telerik.Reporting.TextBox PageNofM1;
        private Telerik.Reporting.PictureBox imgLogo;
        private Telerik.Reporting.SqlDataSource sqldsServiceMonthlySummary;
    }
}