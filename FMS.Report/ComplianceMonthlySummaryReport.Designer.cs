namespace FMS.Report
{
    partial class ComplianceMonthlySummaryReport
    {
        #region Component Designer generated code
        /// <summary>
        /// Required method for telerik Reporting designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ComplianceMonthlySummaryReport));
            Telerik.Reporting.Drawing.StyleRule styleRule1 = new Telerik.Reporting.Drawing.StyleRule();



            Telerik.Reporting.ReportParameter reportParameter1 = new Telerik.Reporting.ReportParameter();
            Telerik.Reporting.ReportParameter reportParameter2 = new Telerik.Reporting.ReportParameter();
            Telerik.Reporting.ReportParameter reportParameter3 = new Telerik.Reporting.ReportParameter();
            Telerik.Reporting.ReportParameter reportParameter4 = new Telerik.Reporting.ReportParameter();
            Telerik.Reporting.ReportParameter reportParameter5 = new Telerik.Reporting.ReportParameter();

            this.PrintDate1 = new Telerik.Reporting.TextBox();
            this.Text1 = new Telerik.Reporting.TextBox();
            this.Text13 = new Telerik.Reporting.TextBox();
            this.Area2 = new Telerik.Reporting.PageHeaderSection();
            this.imgLogo = new Telerik.Reporting.PictureBox();
            this.Box3 = new Telerik.Reporting.Shape();
            this.Text2 = new Telerik.Reporting.TextBox();
            this.Text3 = new Telerik.Reporting.TextBox();
            this.Text4 = new Telerik.Reporting.TextBox();
            this.Text5 = new Telerik.Reporting.TextBox();
            this.Text6 = new Telerik.Reporting.TextBox();
            this.Text7 = new Telerik.Reporting.TextBox();
            this.Text8 = new Telerik.Reporting.TextBox();
            this.Text9 = new Telerik.Reporting.TextBox();
            this.Area3 = new Telerik.Reporting.DetailSection();
            this.Section3 = new Telerik.Reporting.Panel();
            this.Center1 = new Telerik.Reporting.TextBox();
            this.NumberofPPLPermitHolders1 = new Telerik.Reporting.TextBox();
            this.NumberofVehicleRegistration1 = new Telerik.Reporting.TextBox();
            this.CostofVehicleRegistration1 = new Telerik.Reporting.TextBox();
            this.NumberofSafetySticker1 = new Telerik.Reporting.TextBox();
            this.CostofSafetySticker1 = new Telerik.Reporting.TextBox();
            this.NumberofThirdPartyInsurance1 = new Telerik.Reporting.TextBox();
            this.CostofThirdPartyInsurance1 = new Telerik.Reporting.TextBox();
            this.Area5 = new Telerik.Reporting.PageFooterSection();
            this.Box1 = new Telerik.Reporting.Shape();
            this.PageNofM1 = new Telerik.Reporting.TextBox();
            this.sqldsComplianceMonthlySummaryReport = new Telerik.Reporting.SqlDataSource();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // PrintDate1
            // 
            this.PrintDate1.CanGrow = false;
            this.PrintDate1.CanShrink = false;
            this.PrintDate1.Format = "{0:d}";
            this.PrintDate1.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(10.5D), Telerik.Reporting.Drawing.Unit.Inch(0.125D));
            this.PrintDate1.Name = "PrintDate1";
            this.PrintDate1.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(0.967D), Telerik.Reporting.Drawing.Unit.Inch(0.157D));
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
            this.Text1.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(9.956D), Telerik.Reporting.Drawing.Unit.Inch(0.125D));
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
            // Text13
            // 
            this.Text13.CanGrow = false;
            this.Text13.CanShrink = false;
            this.Text13.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(3.7D), Telerik.Reporting.Drawing.Unit.Inch(0.125D));
            this.Text13.Name = "Text13";
            this.Text13.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(4D), Telerik.Reporting.Drawing.Unit.Inch(0.3D));
            this.Text13.Style.BackgroundColor = System.Drawing.Color.White;
            this.Text13.Style.BorderColor.Default = System.Drawing.Color.Black;
            this.Text13.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.None;
            this.Text13.Style.Color = System.Drawing.Color.Black;
            this.Text13.Style.Font.Bold = false;
            this.Text13.Style.Font.Italic = false;
            this.Text13.Style.Font.Name = "Arial";
            this.Text13.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(16D);
            this.Text13.Style.Font.Strikeout = false;
            this.Text13.Style.Font.Underline = false;
            this.Text13.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Left;
            this.Text13.Style.Visible = true;
            this.Text13.Value = "Compliance - Monthly Summary Report";
            // 
            // Area2
            // 
            this.Area2.Height = Telerik.Reporting.Drawing.Unit.Inch(1.117D);
            this.Area2.Items.AddRange(new Telerik.Reporting.ReportItemBase[] {
            this.imgLogo,
            this.Box3,
            this.Text2,
            this.Text3,
            this.Text4,
            this.Text5,
            this.Text6,
            this.Text7,
            this.Text8,
            this.Text9,
            this.PrintDate1,
            this.Text1,
            this.Text13});
            this.Area2.Name = "Area2";
            this.Area2.PrintOnFirstPage = true;
            this.Area2.PrintOnLastPage = true;
            this.Area2.Style.BackgroundColor = System.Drawing.Color.White;
            this.Area2.Style.Visible = true;
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
            // Box3
            // 
            this.Box3.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(0.083D), Telerik.Reporting.Drawing.Unit.Inch(0.533D));
            this.Box3.Name = "Box3";
            this.Box3.ShapeType = new Telerik.Reporting.Drawing.Shapes.PolygonShape(4, 45D, 0);
            this.Box3.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(11.517D), Telerik.Reporting.Drawing.Unit.Inch(0.5D));
            this.Box3.Stretch = true;
            this.Box3.Style.BackgroundColor = System.Drawing.Color.Silver;
            this.Box3.Style.Color = System.Drawing.Color.FromArgb(((int)(((byte)(61)))), ((int)(((byte)(152)))), ((int)(((byte)(193)))));
            this.Box3.Style.LineStyle = Telerik.Reporting.Drawing.LineStyle.Solid;
            this.Box3.Style.LineWidth = Telerik.Reporting.Drawing.Unit.Point(1D);
            this.Box3.Style.Visible = true;
            // 
            // Text2
            // 
            this.Text2.CanGrow = false;
            this.Text2.CanShrink = false;
            this.Text2.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(0.167D), Telerik.Reporting.Drawing.Unit.Inch(0.7D));
            this.Text2.Name = "Text2";
            this.Text2.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(1.633D), Telerik.Reporting.Drawing.Unit.Inch(0.167D));
            this.Text2.Style.BackgroundColor = System.Drawing.Color.Transparent;
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
            this.Text2.Value = "Center";
            // 
            // Text3
            // 
            this.Text3.CanGrow = false;
            this.Text3.CanShrink = false;
            this.Text3.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(2D), Telerik.Reporting.Drawing.Unit.Inch(0.617D));
            this.Text3.Name = "Text3";
            this.Text3.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(1.333D), Telerik.Reporting.Drawing.Unit.Inch(0.333D));
            this.Text3.Style.BackgroundColor = System.Drawing.Color.Transparent;
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
            this.Text3.Value = "Number of\nPPL PermitHolders";
            // 
            // Text4
            // 
            this.Text4.CanGrow = false;
            this.Text4.CanShrink = false;
            this.Text4.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(3.5D), Telerik.Reporting.Drawing.Unit.Inch(0.617D));
            this.Text4.Name = "Text4";
            this.Text4.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(1.4D), Telerik.Reporting.Drawing.Unit.Inch(0.333D));
            this.Text4.Style.BackgroundColor = System.Drawing.Color.Transparent;
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
            this.Text4.Value = "Number of VehicleRegistration";
            // 
            // Text5
            // 
            this.Text5.CanGrow = false;
            this.Text5.CanShrink = false;
            this.Text5.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(5.1D), Telerik.Reporting.Drawing.Unit.Inch(0.617D));
            this.Text5.Name = "Text5";
            this.Text5.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(1.083D), Telerik.Reporting.Drawing.Unit.Inch(0.333D));
            this.Text5.Style.BackgroundColor = System.Drawing.Color.Transparent;
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
            this.Text5.Value = "Cost of Vehicle\nRegistration";
            // 
            // Text6
            // 
            this.Text6.CanGrow = false;
            this.Text6.CanShrink = false;
            this.Text6.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(6.4D), Telerik.Reporting.Drawing.Unit.Inch(0.617D));
            this.Text6.Name = "Text6";
            this.Text6.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(1D), Telerik.Reporting.Drawing.Unit.Inch(0.333D));
            this.Text6.Style.BackgroundColor = System.Drawing.Color.Transparent;
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
            this.Text6.Value = "Number of\nSafety Sticker";
            // 
            // Text7
            // 
            this.Text7.CanGrow = false;
            this.Text7.CanShrink = false;
            this.Text7.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(7.6D), Telerik.Reporting.Drawing.Unit.Inch(0.617D));
            this.Text7.Name = "Text7";
            this.Text7.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(1.083D), Telerik.Reporting.Drawing.Unit.Inch(0.333D));
            this.Text7.Style.BackgroundColor = System.Drawing.Color.Transparent;
            this.Text7.Style.BorderColor.Default = System.Drawing.Color.Black;
            this.Text7.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.None;
            this.Text7.Style.Color = System.Drawing.Color.Black;
            this.Text7.Style.Font.Bold = true;
            this.Text7.Style.Font.Italic = false;
            this.Text7.Style.Font.Name = "Arial";
            this.Text7.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(10D);
            this.Text7.Style.Font.Strikeout = false;
            this.Text7.Style.Font.Underline = false;
            this.Text7.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Left;
            this.Text7.Style.Visible = true;
            this.Text7.Value = "Cost of\nSafety Sticker";
            // 
            // Text8
            // 
            this.Text8.CanGrow = false;
            this.Text8.CanShrink = false;
            this.Text8.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(8.9D), Telerik.Reporting.Drawing.Unit.Inch(0.617D));
            this.Text8.Name = "Text8";
            this.Text8.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(1.233D), Telerik.Reporting.Drawing.Unit.Inch(0.333D));
            this.Text8.Style.BackgroundColor = System.Drawing.Color.Transparent;
            this.Text8.Style.BorderColor.Default = System.Drawing.Color.Black;
            this.Text8.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.None;
            this.Text8.Style.Color = System.Drawing.Color.Black;
            this.Text8.Style.Font.Bold = true;
            this.Text8.Style.Font.Italic = false;
            this.Text8.Style.Font.Name = "Arial";
            this.Text8.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(10D);
            this.Text8.Style.Font.Strikeout = false;
            this.Text8.Style.Font.Underline = false;
            this.Text8.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Left;
            this.Text8.Style.Visible = true;
            this.Text8.Value = "Number of Third\n-Party Insurance";
            // 
            // Text9
            // 
            this.Text9.CanGrow = false;
            this.Text9.CanShrink = false;
            this.Text9.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(10.3D), Telerik.Reporting.Drawing.Unit.Inch(0.617D));
            this.Text9.Name = "Text9";
            this.Text9.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(1.167D), Telerik.Reporting.Drawing.Unit.Inch(0.333D));
            this.Text9.Style.BackgroundColor = System.Drawing.Color.Transparent;
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
            this.Text9.Value = "Cost of Third\n-Party Insurance";
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
            this.Center1,
            this.NumberofPPLPermitHolders1,
            this.NumberofVehicleRegistration1,
            this.CostofVehicleRegistration1,
            this.NumberofSafetySticker1,
            this.CostofSafetySticker1,
            this.NumberofThirdPartyInsurance1,
            this.CostofThirdPartyInsurance1});
            this.Section3.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(0D), Telerik.Reporting.Drawing.Unit.Inch(0D));
            this.Section3.Name = "Section3";
            this.Section3.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(11.693D), Telerik.Reporting.Drawing.Unit.Inch(0.283D));
            this.Section3.Style.BackgroundColor = System.Drawing.Color.White;
            this.Section3.Style.Visible = true;
            // 
            // Center1
            // 
            this.Center1.CanGrow = false;
            this.Center1.CanShrink = false;
            this.Center1.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(0.167D), Telerik.Reporting.Drawing.Unit.Inch(0.05D));
            this.Center1.Name = "Center1";
            this.Center1.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(1.633D), Telerik.Reporting.Drawing.Unit.Inch(0.153D));
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
            // NumberofPPLPermitHolders1
            // 
            this.NumberofPPLPermitHolders1.CanGrow = false;
            this.NumberofPPLPermitHolders1.CanShrink = false;
            this.NumberofPPLPermitHolders1.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(2D), Telerik.Reporting.Drawing.Unit.Inch(0.05D));
            this.NumberofPPLPermitHolders1.Name = "NumberofPPLPermitHolders1";
            this.NumberofPPLPermitHolders1.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(1.333D), Telerik.Reporting.Drawing.Unit.Inch(0.167D));
            this.NumberofPPLPermitHolders1.Style.BackgroundColor = System.Drawing.Color.White;
            this.NumberofPPLPermitHolders1.Style.BorderColor.Default = System.Drawing.Color.Black;
            this.NumberofPPLPermitHolders1.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.None;
            this.NumberofPPLPermitHolders1.Style.Color = System.Drawing.Color.Black;
            this.NumberofPPLPermitHolders1.Style.Font.Bold = false;
            this.NumberofPPLPermitHolders1.Style.Font.Italic = false;
            this.NumberofPPLPermitHolders1.Style.Font.Name = "Arial";
            this.NumberofPPLPermitHolders1.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(10D);
            this.NumberofPPLPermitHolders1.Style.Font.Strikeout = false;
            this.NumberofPPLPermitHolders1.Style.Font.Underline = false;
            this.NumberofPPLPermitHolders1.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Left;
            this.NumberofPPLPermitHolders1.Style.Visible = true;
            this.NumberofPPLPermitHolders1.Value = "=Fields.[NumberofPPLPermitHolders]";
            // 
            // NumberofVehicleRegistration1
            // 
            this.NumberofVehicleRegistration1.CanGrow = false;
            this.NumberofVehicleRegistration1.CanShrink = false;
            this.NumberofVehicleRegistration1.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(3.5D), Telerik.Reporting.Drawing.Unit.Inch(0.05D));
            this.NumberofVehicleRegistration1.Name = "NumberofVehicleRegistration1";
            this.NumberofVehicleRegistration1.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(1.4D), Telerik.Reporting.Drawing.Unit.Inch(0.153D));
            this.NumberofVehicleRegistration1.Style.BackgroundColor = System.Drawing.Color.White;
            this.NumberofVehicleRegistration1.Style.BorderColor.Default = System.Drawing.Color.Black;
            this.NumberofVehicleRegistration1.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.None;
            this.NumberofVehicleRegistration1.Style.Color = System.Drawing.Color.Black;
            this.NumberofVehicleRegistration1.Style.Font.Bold = false;
            this.NumberofVehicleRegistration1.Style.Font.Italic = false;
            this.NumberofVehicleRegistration1.Style.Font.Name = "Arial";
            this.NumberofVehicleRegistration1.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(10D);
            this.NumberofVehicleRegistration1.Style.Font.Strikeout = false;
            this.NumberofVehicleRegistration1.Style.Font.Underline = false;
            this.NumberofVehicleRegistration1.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Left;
            this.NumberofVehicleRegistration1.Style.Visible = true;
            this.NumberofVehicleRegistration1.Value = "=Fields.[NumberofVehicleRegistration]";
            // 
            // CostofVehicleRegistration1
            // 
            this.CostofVehicleRegistration1.CanGrow = false;
            this.CostofVehicleRegistration1.CanShrink = false;
            this.CostofVehicleRegistration1.Format = "{0:C2}";
            this.CostofVehicleRegistration1.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(5.1D), Telerik.Reporting.Drawing.Unit.Inch(0.05D));
            this.CostofVehicleRegistration1.Name = "CostofVehicleRegistration1";
            this.CostofVehicleRegistration1.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(1.083D), Telerik.Reporting.Drawing.Unit.Inch(0.153D));
            this.CostofVehicleRegistration1.Style.BackgroundColor = System.Drawing.Color.White;
            this.CostofVehicleRegistration1.Style.BorderColor.Default = System.Drawing.Color.Black;
            this.CostofVehicleRegistration1.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.None;
            this.CostofVehicleRegistration1.Style.Color = System.Drawing.Color.Black;
            this.CostofVehicleRegistration1.Style.Font.Bold = false;
            this.CostofVehicleRegistration1.Style.Font.Italic = false;
            this.CostofVehicleRegistration1.Style.Font.Name = "Arial";
            this.CostofVehicleRegistration1.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(10D);
            this.CostofVehicleRegistration1.Style.Font.Strikeout = false;
            this.CostofVehicleRegistration1.Style.Font.Underline = false;
            this.CostofVehicleRegistration1.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Left;
            this.CostofVehicleRegistration1.Style.Visible = true;
            this.CostofVehicleRegistration1.Value = "=Fields.[CostofVehicleRegistration]";
            // 
            // NumberofSafetySticker1
            // 
            this.NumberofSafetySticker1.CanGrow = false;
            this.NumberofSafetySticker1.CanShrink = false;
            this.NumberofSafetySticker1.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(6.4D), Telerik.Reporting.Drawing.Unit.Inch(0.05D));
            this.NumberofSafetySticker1.Name = "NumberofSafetySticker1";
            this.NumberofSafetySticker1.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(1D), Telerik.Reporting.Drawing.Unit.Inch(0.153D));
            this.NumberofSafetySticker1.Style.BackgroundColor = System.Drawing.Color.White;
            this.NumberofSafetySticker1.Style.BorderColor.Default = System.Drawing.Color.Black;
            this.NumberofSafetySticker1.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.None;
            this.NumberofSafetySticker1.Style.Color = System.Drawing.Color.Black;
            this.NumberofSafetySticker1.Style.Font.Bold = false;
            this.NumberofSafetySticker1.Style.Font.Italic = false;
            this.NumberofSafetySticker1.Style.Font.Name = "Arial";
            this.NumberofSafetySticker1.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(10D);
            this.NumberofSafetySticker1.Style.Font.Strikeout = false;
            this.NumberofSafetySticker1.Style.Font.Underline = false;
            this.NumberofSafetySticker1.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Left;
            this.NumberofSafetySticker1.Style.Visible = true;
            this.NumberofSafetySticker1.Value = "=Fields.[NumberofSafetySticker]";
            // 
            // CostofSafetySticker1
            // 
            this.CostofSafetySticker1.CanGrow = false;
            this.CostofSafetySticker1.CanShrink = false;
            this.CostofSafetySticker1.Format = "{0:C2}";
            this.CostofSafetySticker1.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(7.6D), Telerik.Reporting.Drawing.Unit.Inch(0.05D));
            this.CostofSafetySticker1.Name = "CostofSafetySticker1";
            this.CostofSafetySticker1.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(1.083D), Telerik.Reporting.Drawing.Unit.Inch(0.153D));
            this.CostofSafetySticker1.Style.BackgroundColor = System.Drawing.Color.White;
            this.CostofSafetySticker1.Style.BorderColor.Default = System.Drawing.Color.Black;
            this.CostofSafetySticker1.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.None;
            this.CostofSafetySticker1.Style.Color = System.Drawing.Color.Black;
            this.CostofSafetySticker1.Style.Font.Bold = false;
            this.CostofSafetySticker1.Style.Font.Italic = false;
            this.CostofSafetySticker1.Style.Font.Name = "Arial";
            this.CostofSafetySticker1.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(10D);
            this.CostofSafetySticker1.Style.Font.Strikeout = false;
            this.CostofSafetySticker1.Style.Font.Underline = false;
            this.CostofSafetySticker1.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Left;
            this.CostofSafetySticker1.Style.Visible = true;
            this.CostofSafetySticker1.Value = "=Fields.[CostofSafetySticker]";
            // 
            // NumberofThirdPartyInsurance1
            // 
            this.NumberofThirdPartyInsurance1.CanGrow = false;
            this.NumberofThirdPartyInsurance1.CanShrink = false;
            this.NumberofThirdPartyInsurance1.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(8.9D), Telerik.Reporting.Drawing.Unit.Inch(0.05D));
            this.NumberofThirdPartyInsurance1.Name = "NumberofThirdPartyInsurance1";
            this.NumberofThirdPartyInsurance1.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(1.233D), Telerik.Reporting.Drawing.Unit.Inch(0.153D));
            this.NumberofThirdPartyInsurance1.Style.BackgroundColor = System.Drawing.Color.White;
            this.NumberofThirdPartyInsurance1.Style.BorderColor.Default = System.Drawing.Color.Black;
            this.NumberofThirdPartyInsurance1.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.None;
            this.NumberofThirdPartyInsurance1.Style.Color = System.Drawing.Color.Black;
            this.NumberofThirdPartyInsurance1.Style.Font.Bold = false;
            this.NumberofThirdPartyInsurance1.Style.Font.Italic = false;
            this.NumberofThirdPartyInsurance1.Style.Font.Name = "Arial";
            this.NumberofThirdPartyInsurance1.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(10D);
            this.NumberofThirdPartyInsurance1.Style.Font.Strikeout = false;
            this.NumberofThirdPartyInsurance1.Style.Font.Underline = false;
            this.NumberofThirdPartyInsurance1.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Left;
            this.NumberofThirdPartyInsurance1.Style.Visible = true;
            this.NumberofThirdPartyInsurance1.Value = "=Fields.[NumberofThirdPartyInsurance]";
            // 
            // CostofThirdPartyInsurance1
            // 
            this.CostofThirdPartyInsurance1.CanGrow = false;
            this.CostofThirdPartyInsurance1.CanShrink = false;
            this.CostofThirdPartyInsurance1.Format = "{0:C2}";
            this.CostofThirdPartyInsurance1.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(10.3D), Telerik.Reporting.Drawing.Unit.Inch(0.05D));
            this.CostofThirdPartyInsurance1.Name = "CostofThirdPartyInsurance1";
            this.CostofThirdPartyInsurance1.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(1.3D), Telerik.Reporting.Drawing.Unit.Inch(0.153D));
            this.CostofThirdPartyInsurance1.Style.BackgroundColor = System.Drawing.Color.White;
            this.CostofThirdPartyInsurance1.Style.BorderColor.Default = System.Drawing.Color.Black;
            this.CostofThirdPartyInsurance1.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.None;
            this.CostofThirdPartyInsurance1.Style.Color = System.Drawing.Color.Black;
            this.CostofThirdPartyInsurance1.Style.Font.Bold = false;
            this.CostofThirdPartyInsurance1.Style.Font.Italic = false;
            this.CostofThirdPartyInsurance1.Style.Font.Name = "Arial";
            this.CostofThirdPartyInsurance1.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(10D);
            this.CostofThirdPartyInsurance1.Style.Font.Strikeout = false;
            this.CostofThirdPartyInsurance1.Style.Font.Underline = false;
            this.CostofThirdPartyInsurance1.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Left;
            this.CostofThirdPartyInsurance1.Style.Visible = true;
            this.CostofThirdPartyInsurance1.Value = "=Fields.[CostofThirdPartyInsurance]";
            // 
            // Area5
            // 
            this.Area5.Height = Telerik.Reporting.Drawing.Unit.Inch(0.625D);
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
            this.Box1.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(0.083D), Telerik.Reporting.Drawing.Unit.Inch(0.1D));
            this.Box1.Name = "Box1";
            this.Box1.ShapeType = new Telerik.Reporting.Drawing.Shapes.PolygonShape(4, 45D, 0);
            this.Box1.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(11.517D), Telerik.Reporting.Drawing.Unit.Inch(0.417D));
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
            this.PageNofM1.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(10.082D), Telerik.Reporting.Drawing.Unit.Inch(0.222D));
            this.PageNofM1.Name = "PageNofM1";
            this.PageNofM1.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(1.385D), Telerik.Reporting.Drawing.Unit.Inch(0.16D));
            this.PageNofM1.Style.BackgroundColor = System.Drawing.Color.Transparent;
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
            // sqldsComplianceMonthlySummaryReport
            // 
            this.sqldsComplianceMonthlySummaryReport.ConnectionString = "FMSEntities";
            this.sqldsComplianceMonthlySummaryReport.Name = "sqldsComplianceMonthlySummaryReport";
            this.sqldsComplianceMonthlySummaryReport.SelectCommand = " SELECT * \r\n FROM   \"ComplianceMonthlySummaryReport\" \"ComplianceMonthlySummaryRep" +
    "ort\"";
            // 
            // ComplianceMonthlySummaryReport
            // 
            this.DataSource = this.sqldsComplianceMonthlySummaryReport;
            this.Filters.Add(new Telerik.Reporting.Filter("= IIF(Fields.Center is null, \"true\" ,Fields.Center)", Telerik.Reporting.FilterOperator.Equal, "= IIF(Parameters.paramCenter.Value is null, IsNull(Fields.Center,\"true\"),Paramete" +
"rs.paramCenter.Value)"));
            this.Items.AddRange(new Telerik.Reporting.ReportItemBase[] {
            this.Area2,
            this.Area3,
            this.Area5});
            this.Name = "ComplianceMonthlySummaryReport";
            this.PageSettings.ContinuousPaper = false;
            this.PageSettings.Landscape = true;
            this.PageSettings.Margins = new Telerik.Reporting.Drawing.MarginsU(Telerik.Reporting.Drawing.Unit.Mm(0.25D), Telerik.Reporting.Drawing.Unit.Mm(0.25D), Telerik.Reporting.Drawing.Unit.Mm(0.25D), Telerik.Reporting.Drawing.Unit.Mm(0.25D));
            this.PageSettings.PaperKind = System.Drawing.Printing.PaperKind.A4;

            reportParameter1.AllowNull = true;
            reportParameter1.Name = "paramExpiryDateFrom";
            reportParameter1.Type = Telerik.Reporting.ReportParameterType.DateTime;
            reportParameter2.AllowNull = true;
            reportParameter2.Name = "paramExpiryDateTo";
            reportParameter2.Type = Telerik.Reporting.ReportParameterType.DateTime;
            reportParameter3.AllowNull = true;
            reportParameter3.Name = "paramBusinessUnit";
            reportParameter4.AllowNull = true;
            reportParameter4.Name = "paramBusinessGroup";
            reportParameter5.AllowNull = true;
            reportParameter5.Name = "paramCenter";

            this.ReportParameters.Add(reportParameter1);
            this.ReportParameters.Add(reportParameter2);
            this.ReportParameters.Add(reportParameter3);
            this.ReportParameters.Add(reportParameter4);
            this.ReportParameters.Add(reportParameter5);


            styleRule1.Selectors.AddRange(new Telerik.Reporting.Drawing.ISelector[] {
            new Telerik.Reporting.Drawing.TypeSelector(typeof(Telerik.Reporting.TextItemBase)),
            new Telerik.Reporting.Drawing.TypeSelector(typeof(Telerik.Reporting.HtmlTextBox))});
            styleRule1.Style.Padding.Left = Telerik.Reporting.Drawing.Unit.Point(2D);
            styleRule1.Style.Padding.Right = Telerik.Reporting.Drawing.Unit.Point(2D);
            this.StyleSheet.AddRange(new Telerik.Reporting.Drawing.StyleRule[] {
            styleRule1});
            this.Width = Telerik.Reporting.Drawing.Unit.Mm(297D);
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

        }
        #endregion
        private Telerik.Reporting.TextBox PrintDate1;
        private Telerik.Reporting.TextBox Text1;
        private Telerik.Reporting.TextBox Text13;
        private Telerik.Reporting.PageHeaderSection Area2;
        private Telerik.Reporting.Shape Box3;
        private Telerik.Reporting.TextBox Text2;
        private Telerik.Reporting.TextBox Text3;
        private Telerik.Reporting.TextBox Text4;
        private Telerik.Reporting.TextBox Text5;
        private Telerik.Reporting.TextBox Text6;
        private Telerik.Reporting.TextBox Text7;
        private Telerik.Reporting.TextBox Text8;
        private Telerik.Reporting.TextBox Text9;
        private Telerik.Reporting.DetailSection Area3;
        private Telerik.Reporting.Panel Section3;
        private Telerik.Reporting.TextBox Center1;
        private Telerik.Reporting.TextBox NumberofPPLPermitHolders1;
        private Telerik.Reporting.TextBox NumberofVehicleRegistration1;
        private Telerik.Reporting.TextBox CostofVehicleRegistration1;
        private Telerik.Reporting.TextBox NumberofSafetySticker1;
        private Telerik.Reporting.TextBox CostofSafetySticker1;
        private Telerik.Reporting.TextBox NumberofThirdPartyInsurance1;
        private Telerik.Reporting.TextBox CostofThirdPartyInsurance1;
        private Telerik.Reporting.PageFooterSection Area5;
        private Telerik.Reporting.Shape Box1;
        private Telerik.Reporting.TextBox PageNofM1;
        private Telerik.Reporting.PictureBox imgLogo;
        private Telerik.Reporting.SqlDataSource sqldsComplianceMonthlySummaryReport;
    }
}