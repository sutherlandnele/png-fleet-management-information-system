namespace FMS.Report
{
    partial class DisposedVehiclesListing
    {
        #region Component Designer generated code
        /// <summary>
        /// Required method for telerik Reporting designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DisposedVehiclesListing));
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
            Telerik.Reporting.ReportParameter reportParameter10 = new Telerik.Reporting.ReportParameter();
            Telerik.Reporting.ReportParameter reportParameter11 = new Telerik.Reporting.ReportParameter();
            Telerik.Reporting.ReportParameter reportParameter12 = new Telerik.Reporting.ReportParameter();
            this.Text12 = new Telerik.Reporting.TextBox();
            this.PrintDate1 = new Telerik.Reporting.TextBox();
            this.Text11 = new Telerik.Reporting.TextBox();
            this.Area2 = new Telerik.Reporting.PageHeaderSection();
            this.Box4 = new Telerik.Reporting.Shape();
            this.Text2 = new Telerik.Reporting.TextBox();
            this.Text3 = new Telerik.Reporting.TextBox();
            this.Text5 = new Telerik.Reporting.TextBox();
            this.Text4 = new Telerik.Reporting.TextBox();
            this.Text13 = new Telerik.Reporting.TextBox();
            this.Text7 = new Telerik.Reporting.TextBox();
            this.imgLogo = new Telerik.Reporting.PictureBox();
            this.Area3 = new Telerik.Reporting.DetailSection();
            this.RegistrationNumber1 = new Telerik.Reporting.TextBox();
            this.DisposalDate1 = new Telerik.Reporting.TextBox();
            this.DisposalReferance1 = new Telerik.Reporting.TextBox();
            this.Center1 = new Telerik.Reporting.TextBox();
            this.year1 = new Telerik.Reporting.TextBox();
            this.VehicleDescription1 = new Telerik.Reporting.TextBox();
            this.Area4 = new Telerik.Reporting.ReportFooterSection();
            this.Area5 = new Telerik.Reporting.PageFooterSection();
            this.Box1 = new Telerik.Reporting.Shape();
            this.PageNofM1 = new Telerik.Reporting.TextBox();
            this.sqldsDisposedAssets = new Telerik.Reporting.SqlDataSource();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // Text12
            // 
            this.Text12.CanGrow = false;
            this.Text12.CanShrink = false;
            this.Text12.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(2.4D), Telerik.Reporting.Drawing.Unit.Inch(0.2D));
            this.Text12.Name = "Text12";
            this.Text12.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(3.532D), Telerik.Reporting.Drawing.Unit.Inch(0.292D));
            this.Text12.Style.BackgroundColor = System.Drawing.Color.White;
            this.Text12.Style.BorderColor.Default = System.Drawing.Color.Black;
            this.Text12.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.None;
            this.Text12.Style.Color = System.Drawing.Color.Black;
            this.Text12.Style.Font.Bold = false;
            this.Text12.Style.Font.Italic = false;
            this.Text12.Style.Font.Name = "Arial";
            this.Text12.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(16D);
            this.Text12.Style.Font.Strikeout = false;
            this.Text12.Style.Font.Underline = false;
            this.Text12.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Left;
            this.Text12.Style.Visible = true;
            this.Text12.Value = "Disposed Vehicles Listing Report";
            // 
            // PrintDate1
            // 
            this.PrintDate1.CanGrow = false;
            this.PrintDate1.CanShrink = false;
            this.PrintDate1.Format = "{0:d}";
            this.PrintDate1.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(6.865D), Telerik.Reporting.Drawing.Unit.Inch(0.2D));
            this.PrintDate1.Name = "PrintDate1";
            this.PrintDate1.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(0.901D), Telerik.Reporting.Drawing.Unit.Inch(0.157D));
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
            // Text11
            // 
            this.Text11.CanGrow = false;
            this.Text11.CanShrink = false;
            this.Text11.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(6.344D), Telerik.Reporting.Drawing.Unit.Inch(0.2D));
            this.Text11.Name = "Text11";
            this.Text11.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(0.521D), Telerik.Reporting.Drawing.Unit.Inch(0.157D));
            this.Text11.Style.BackgroundColor = System.Drawing.Color.White;
            this.Text11.Style.BorderColor.Default = System.Drawing.Color.Black;
            this.Text11.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.None;
            this.Text11.Style.Color = System.Drawing.Color.Black;
            this.Text11.Style.Font.Bold = false;
            this.Text11.Style.Font.Italic = false;
            this.Text11.Style.Font.Name = "Arial";
            this.Text11.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(10D);
            this.Text11.Style.Font.Strikeout = false;
            this.Text11.Style.Font.Underline = false;
            this.Text11.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Left;
            this.Text11.Style.Visible = true;
            this.Text11.Value = "Date :";
            // 
            // Area2
            // 
            this.Area2.Height = Telerik.Reporting.Drawing.Unit.Inch(1.1D);
            this.Area2.Items.AddRange(new Telerik.Reporting.ReportItemBase[] {
            this.Box4,
            this.Text2,
            this.Text3,
            this.Text5,
            this.Text4,
            this.Text13,
            this.Text7,
            this.Text12,
            this.PrintDate1,
            this.Text11,
            this.imgLogo});
            this.Area2.Name = "Area2";
            this.Area2.PrintOnFirstPage = true;
            this.Area2.PrintOnLastPage = true;
            this.Area2.Style.BackgroundColor = System.Drawing.Color.White;
            this.Area2.Style.Visible = true;
            // 
            // Box4
            // 
            this.Box4.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(0.2D), Telerik.Reporting.Drawing.Unit.Inch(0.7D));
            this.Box4.Name = "Box4";
            this.Box4.ShapeType = new Telerik.Reporting.Drawing.Shapes.PolygonShape(4, 45D, 0);
            this.Box4.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(7.896D), Telerik.Reporting.Drawing.Unit.Inch(0.365D));
            this.Box4.Stretch = true;
            this.Box4.Style.BackgroundColor = System.Drawing.Color.Gainsboro;
            this.Box4.Style.Color = System.Drawing.Color.FromArgb(((int)(((byte)(61)))), ((int)(((byte)(152)))), ((int)(((byte)(193)))));
            this.Box4.Style.LineStyle = Telerik.Reporting.Drawing.LineStyle.Solid;
            this.Box4.Style.LineWidth = Telerik.Reporting.Drawing.Unit.Point(1D);
            this.Box4.Style.Visible = true;
            // 
            // Text2
            // 
            this.Text2.CanGrow = false;
            this.Text2.CanShrink = false;
            this.Text2.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(0.79D), Telerik.Reporting.Drawing.Unit.Inch(0.724D));
            this.Text2.Name = "Text2";
            this.Text2.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(0.67D), Telerik.Reporting.Drawing.Unit.Inch(0.333D));
            this.Text2.Style.BackgroundColor = System.Drawing.Color.Gainsboro;
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
            this.Text2.Value = "Rego\nNumber";
            // 
            // Text3
            // 
            this.Text3.CanGrow = false;
            this.Text3.CanShrink = false;
            this.Text3.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(3.745D), Telerik.Reporting.Drawing.Unit.Inch(0.724D));
            this.Text3.Name = "Text3";
            this.Text3.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(1.034D), Telerik.Reporting.Drawing.Unit.Inch(0.333D));
            this.Text3.Style.BackgroundColor = System.Drawing.Color.Gainsboro;
            this.Text3.Style.BorderColor.Default = System.Drawing.Color.Black;
            this.Text3.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.None;
            this.Text3.Style.Color = System.Drawing.Color.Black;
            this.Text3.Style.Font.Bold = true;
            this.Text3.Style.Font.Italic = false;
            this.Text3.Style.Font.Name = "Arial";
            this.Text3.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(10D);
            this.Text3.Style.Font.Strikeout = false;
            this.Text3.Style.Font.Underline = false;
            this.Text3.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Right;
            this.Text3.Style.Visible = true;
            this.Text3.Value = "Disposal Date";
            // 
            // Text5
            // 
            this.Text5.CanGrow = false;
            this.Text5.CanShrink = false;
            this.Text5.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(5.026D), Telerik.Reporting.Drawing.Unit.Inch(0.724D));
            this.Text5.Name = "Text5";
            this.Text5.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(1.885D), Telerik.Reporting.Drawing.Unit.Inch(0.158D));
            this.Text5.Style.BackgroundColor = System.Drawing.Color.Gainsboro;
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
            this.Text5.Value = "Disposal Referance";
            // 
            // Text4
            // 
            this.Text4.CanGrow = false;
            this.Text4.CanShrink = false;
            this.Text4.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(7.044D), Telerik.Reporting.Drawing.Unit.Inch(0.724D));
            this.Text4.Name = "Text4";
            this.Text4.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(0.969D), Telerik.Reporting.Drawing.Unit.Inch(0.16D));
            this.Text4.Style.BackgroundColor = System.Drawing.Color.Gainsboro;
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
            this.Text4.Value = "Center";
            // 
            // Text13
            // 
            this.Text13.CanGrow = false;
            this.Text13.CanShrink = false;
            this.Text13.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(0.262D), Telerik.Reporting.Drawing.Unit.Inch(0.724D));
            this.Text13.Name = "Text13";
            this.Text13.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(0.458D), Telerik.Reporting.Drawing.Unit.Inch(0.16D));
            this.Text13.Style.BackgroundColor = System.Drawing.Color.Gainsboro;
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
            this.Text13.Value = "Year";
            // 
            // Text7
            // 
            this.Text7.CanGrow = false;
            this.Text7.CanShrink = false;
            this.Text7.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(1.523D), Telerik.Reporting.Drawing.Unit.Inch(0.724D));
            this.Text7.Name = "Text7";
            this.Text7.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(2.09D), Telerik.Reporting.Drawing.Unit.Inch(0.16D));
            this.Text7.Style.BackgroundColor = System.Drawing.Color.Gainsboro;
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
            this.Text7.Value = "Vehicle Description";
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
            this.Area3.Height = Telerik.Reporting.Drawing.Unit.Inch(0.23D);
            this.Area3.Items.AddRange(new Telerik.Reporting.ReportItemBase[] {
            this.RegistrationNumber1,
            this.DisposalDate1,
            this.DisposalReferance1,
            this.Center1,
            this.year1,
            this.VehicleDescription1});
            this.Area3.KeepTogether = false;
            this.Area3.Name = "Area3";
            this.Area3.PageBreak = Telerik.Reporting.PageBreak.None;
            this.Area3.Style.BackgroundColor = System.Drawing.Color.White;
            this.Area3.Style.Visible = true;
            // 
            // RegistrationNumber1
            // 
            this.RegistrationNumber1.CanGrow = true;
            this.RegistrationNumber1.CanShrink = false;
            this.RegistrationNumber1.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(0.79D), Telerik.Reporting.Drawing.Unit.Inch(0.042D));
            this.RegistrationNumber1.Name = "RegistrationNumber1";
            this.RegistrationNumber1.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(0.67D), Telerik.Reporting.Drawing.Unit.Inch(0.158D));
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
            // DisposalDate1
            // 
            this.DisposalDate1.CanGrow = true;
            this.DisposalDate1.CanShrink = false;
            this.DisposalDate1.Format = "{0:d}";
            this.DisposalDate1.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(3.745D), Telerik.Reporting.Drawing.Unit.Inch(0.042D));
            this.DisposalDate1.Name = "DisposalDate1";
            this.DisposalDate1.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(0.931D), Telerik.Reporting.Drawing.Unit.Inch(0.158D));
            this.DisposalDate1.Style.BackgroundColor = System.Drawing.Color.White;
            this.DisposalDate1.Style.BorderColor.Default = System.Drawing.Color.Black;
            this.DisposalDate1.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.None;
            this.DisposalDate1.Style.Color = System.Drawing.Color.Black;
            this.DisposalDate1.Style.Font.Bold = false;
            this.DisposalDate1.Style.Font.Italic = false;
            this.DisposalDate1.Style.Font.Name = "Arial";
            this.DisposalDate1.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(10D);
            this.DisposalDate1.Style.Font.Strikeout = false;
            this.DisposalDate1.Style.Font.Underline = false;
            this.DisposalDate1.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Right;
            this.DisposalDate1.Style.Visible = true;
            this.DisposalDate1.Value = "=Fields.[Disposal Date]";
            // 
            // DisposalReferance1
            // 
            this.DisposalReferance1.CanGrow = true;
            this.DisposalReferance1.CanShrink = false;
            this.DisposalReferance1.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(5.026D), Telerik.Reporting.Drawing.Unit.Inch(0.042D));
            this.DisposalReferance1.Name = "DisposalReferance1";
            this.DisposalReferance1.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(1.885D), Telerik.Reporting.Drawing.Unit.Inch(0.158D));
            this.DisposalReferance1.Style.BackgroundColor = System.Drawing.Color.White;
            this.DisposalReferance1.Style.BorderColor.Default = System.Drawing.Color.Black;
            this.DisposalReferance1.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.None;
            this.DisposalReferance1.Style.Color = System.Drawing.Color.Black;
            this.DisposalReferance1.Style.Font.Bold = false;
            this.DisposalReferance1.Style.Font.Italic = false;
            this.DisposalReferance1.Style.Font.Name = "Arial";
            this.DisposalReferance1.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(10D);
            this.DisposalReferance1.Style.Font.Strikeout = false;
            this.DisposalReferance1.Style.Font.Underline = false;
            this.DisposalReferance1.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Left;
            this.DisposalReferance1.Style.Visible = true;
            this.DisposalReferance1.Value = "=Fields.[Disposal Referance]";
            // 
            // Center1
            // 
            this.Center1.CanGrow = true;
            this.Center1.CanShrink = false;
            this.Center1.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(7.044D), Telerik.Reporting.Drawing.Unit.Inch(0.042D));
            this.Center1.Name = "Center1";
            this.Center1.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(0.969D), Telerik.Reporting.Drawing.Unit.Inch(0.188D));
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
            // year1
            // 
            this.year1.CanGrow = true;
            this.year1.CanShrink = false;
            this.year1.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(0.262D), Telerik.Reporting.Drawing.Unit.Inch(0.042D));
            this.year1.Name = "year1";
            this.year1.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(0.458D), Telerik.Reporting.Drawing.Unit.Inch(0.16D));
            this.year1.Style.BackgroundColor = System.Drawing.Color.White;
            this.year1.Style.BorderColor.Default = System.Drawing.Color.Black;
            this.year1.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.None;
            this.year1.Style.Color = System.Drawing.Color.Black;
            this.year1.Style.Font.Bold = false;
            this.year1.Style.Font.Italic = false;
            this.year1.Style.Font.Name = "Arial";
            this.year1.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(10D);
            this.year1.Style.Font.Strikeout = false;
            this.year1.Style.Font.Underline = false;
            this.year1.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Left;
            this.year1.Style.Visible = true;
            this.year1.Value = "=Fields.[year]";
            // 
            // VehicleDescription1
            // 
            this.VehicleDescription1.CanGrow = true;
            this.VehicleDescription1.CanShrink = false;
            this.VehicleDescription1.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(1.505D), Telerik.Reporting.Drawing.Unit.Inch(0.042D));
            this.VehicleDescription1.Name = "VehicleDescription1";
            this.VehicleDescription1.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(2.09D), Telerik.Reporting.Drawing.Unit.Inch(0.16D));
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
            // Area4
            // 
            this.Area4.Height = Telerik.Reporting.Drawing.Unit.Inch(0.014D);
            this.Area4.KeepTogether = false;
            this.Area4.Name = "Area4";
            this.Area4.PageBreak = Telerik.Reporting.PageBreak.After;
            this.Area4.Style.BackgroundColor = System.Drawing.Color.White;
            this.Area4.Style.Visible = true;
            // 
            // Area5
            // 
            this.Area5.Height = Telerik.Reporting.Drawing.Unit.Inch(0.356D);
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
            this.Box1.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(0.252D), Telerik.Reporting.Drawing.Unit.Inch(0.01D));
            this.Box1.Name = "Box1";
            this.Box1.ShapeType = new Telerik.Reporting.Drawing.Shapes.PolygonShape(4, 45D, 0);
            this.Box1.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(7.844D), Telerik.Reporting.Drawing.Unit.Inch(0.25D));
            this.Box1.Stretch = true;
            this.Box1.Style.BackgroundColor = System.Drawing.Color.Gainsboro;
            this.Box1.Style.Color = System.Drawing.Color.FromArgb(((int)(((byte)(61)))), ((int)(((byte)(152)))), ((int)(((byte)(193)))));
            this.Box1.Style.LineStyle = Telerik.Reporting.Drawing.LineStyle.Solid;
            this.Box1.Style.LineWidth = Telerik.Reporting.Drawing.Unit.Point(1D);
            this.Box1.Style.Visible = true;
            // 
            // PageNofM1
            // 
            this.PageNofM1.CanGrow = false;
            this.PageNofM1.CanShrink = false;
            this.PageNofM1.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(6.979D), Telerik.Reporting.Drawing.Unit.Inch(0.046D));
            this.PageNofM1.Name = "PageNofM1";
            this.PageNofM1.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(0.966D), Telerik.Reporting.Drawing.Unit.Inch(0.16D));
            this.PageNofM1.Style.BackgroundColor = System.Drawing.Color.Gainsboro;
            this.PageNofM1.Style.BorderColor.Default = System.Drawing.Color.Black;
            this.PageNofM1.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.None;
            this.PageNofM1.Style.Color = System.Drawing.Color.Black;
            this.PageNofM1.Style.Font.Bold = false;
            this.PageNofM1.Style.Font.Italic = false;
            this.PageNofM1.Style.Font.Name = "Arial";
            this.PageNofM1.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(10D);
            this.PageNofM1.Style.Font.Strikeout = false;
            this.PageNofM1.Style.Font.Underline = false;
            this.PageNofM1.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Left;
            this.PageNofM1.Style.Visible = true;
            this.PageNofM1.Value = "=\"Page \" + PageNumber + \" of \" + PageCount";
            // 
            // sqldsDisposedAssets
            // 
            this.sqldsDisposedAssets.ConnectionString = "FMSEntities";
            this.sqldsDisposedAssets.Name = "sqldsDisposedAssets";
            this.sqldsDisposedAssets.SelectCommand = " SELECT * \r\n FROM   \"DisposedAssets\" \"Disposed_Assets\"";
            // 
            // DisposedVehiclesListing
            // 
            this.DataSource = this.sqldsDisposedAssets;
            this.Filters.Add(new Telerik.Reporting.Filter("= IIF(Fields.[Fuel Type] is null, \"true\", Fields.[Fuel Type])", Telerik.Reporting.FilterOperator.Equal, "= IIF(Parameters.paramFuelType.Value is null, IsNull(Fields.[Fuel Type],\"true\"),P" +
           "arameters.paramFuelType.Value)"));
            this.Filters.Add(new Telerik.Reporting.Filter("= IIF(Fields.[Registration Number] is null, \"true\" ,Fields.[Registration Number])" +
            "", Telerik.Reporting.FilterOperator.Equal, "= IIF( Parameters.paramRegistrationNumber.Value is null, IsNull(Fields.[Registrat" +
            "ion Number],\"true\"), Parameters.paramRegistrationNumber.Value)"));
            this.Filters.Add(new Telerik.Reporting.Filter("= IIF( Fields.BOS is null, \"true\" , Fields.BOS)", Telerik.Reporting.FilterOperator.Equal, "= IIF(Parameters.paramBOSRecommendation.Value is null, IsNull( Fields.BOS,\"true\")" +
            ",Parameters.paramBOSRecommendation.Value)"));
            this.Filters.Add(new Telerik.Reporting.Filter("= IIF(Fields.BusinessGroup is null, \"true\" ,Fields.BusinessGroup)", Telerik.Reporting.FilterOperator.Equal, "= IIF(Parameters.paramBusinessGroup.Value is null, IsNull(Fields.BusinessGroup,\"t" +
            "rue\"),Parameters.paramBusinessGroup.Value)"));
            this.Filters.Add(new Telerik.Reporting.Filter("= IIF(Fields.BusinessUnit is null, \"true\" ,Fields.BusinessUnit)", Telerik.Reporting.FilterOperator.Equal, "= IIF(Parameters.paramBusinessUnit.Value is null, IsNull(Fields.BusinessUnit,\"tru" +
            "e\"),Parameters.paramBusinessUnit.Value)"));
            this.Filters.Add(new Telerik.Reporting.Filter("= IIF(Fields.Center is null, \"true\" ,Fields.Center)", Telerik.Reporting.FilterOperator.Equal, "= IIF(Parameters.paramCenter.Value is null, IsNull(Fields.Center,\"true\"),Paramete" +
            "rs.paramCenter.Value)"));
            this.Filters.Add(new Telerik.Reporting.Filter("= IIF(Fields.Condition is null, \"true\" ,Fields.Condition)", Telerik.Reporting.FilterOperator.Equal, "= IIF(Parameters.paramVehicleCondition.Value is null, IsNull(Fields.Condition,\"tr" +
            "ue\"),Parameters.paramVehicleCondition.Value)"));
            this.Filters.Add(new Telerik.Reporting.Filter("= IIF(Fields.year is null, \"true\" ,Fields.year)", Telerik.Reporting.FilterOperator.GreaterOrEqual, "= IIF(Parameters.paramPurchaseFromYear.Value is null, IsNull(Fields.year,\"true\")," +
            "Parameters.paramPurchaseFromYear.Value)"));
            this.Filters.Add(new Telerik.Reporting.Filter("= IIF(Fields.year is null, \"true\" ,Fields.year)", Telerik.Reporting.FilterOperator.LessOrEqual, "= IIF(Parameters.paramPurchaseToYear.Value is null, IsNull(Fields.year,\"true\"),Pa" +
            "rameters.paramPurchaseToYear.Value)"));
            this.Filters.Add(new Telerik.Reporting.Filter("= IIF(Fields.Status is null, \"true\" ,Fields.Status)", Telerik.Reporting.FilterOperator.Equal, "= IIF(Parameters.paramVehicleStatus.Value is null, IsNull(Fields.Status,\"true\"),P" +
            "arameters.paramVehicleStatus.Value)"));
            this.Filters.Add(new Telerik.Reporting.Filter("= IIF(Fields.Transmission is null, \"true\" ,Fields.Transmission)", Telerik.Reporting.FilterOperator.Equal, "= IIF(Parameters.paramTransmission.Value is null, IsNull(Fields.Transmission,\"tru" +
            "e\"),Parameters.paramTransmission.Value)"));
            this.Filters.Add(new Telerik.Reporting.Filter("= IIF(Fields.Type is null, \"true\" ,Fields.Type)", Telerik.Reporting.FilterOperator.Equal, "= IIF(Parameters.paramVehicleType.Value is null, IsNull(Fields.Type,\"true\"),Param" +
            "eters.paramVehicleType.Value)"));
            this.Items.AddRange(new Telerik.Reporting.ReportItemBase[] {
            this.Area2,
            this.Area3,
            this.Area4,
            this.Area5});
            this.Name = "DisposedVehiclesListing";
            this.PageSettings.ContinuousPaper = false;
            this.PageSettings.Landscape = false;
            this.PageSettings.Margins = new Telerik.Reporting.Drawing.MarginsU(Telerik.Reporting.Drawing.Unit.Mm(0.25D), Telerik.Reporting.Drawing.Unit.Mm(0.25D), Telerik.Reporting.Drawing.Unit.Mm(0.25D), Telerik.Reporting.Drawing.Unit.Mm(0.25D));
            this.PageSettings.PaperKind = System.Drawing.Printing.PaperKind.A4;
            reportParameter1.AllowNull = true;
            reportParameter1.Name = "paramPurchaseFromYear";
            reportParameter2.AllowNull = true;
            reportParameter2.Name = "paramPurchaseToYear";
            reportParameter3.AllowNull = true;
            reportParameter3.Name = "paramRegistrationNumber";
            reportParameter4.AllowNull = true;
            reportParameter4.Name = "paramCenter";
            reportParameter5.AllowNull = true;
            reportParameter5.Name = "paramBusinessUnit";
            reportParameter6.AllowNull = true;
            reportParameter6.Name = "paramBusinessGroup";
            reportParameter7.AllowNull = true;
            reportParameter7.Name = "paramVehicleStatus";
            reportParameter8.AllowNull = true;
            reportParameter8.Name = "paramVehicleCondition";
            reportParameter9.AllowNull = true;
            reportParameter9.Name = "paramVehicleType";
            reportParameter10.AllowNull = true;
            reportParameter10.Name = "paramFuelType";
            reportParameter11.AllowNull = true;
            reportParameter11.Name = "paramTransmission";
            reportParameter12.AllowNull = true;
            reportParameter12.Name = "paramBOSRecommendation";
            reportParameter12.Type = Telerik.Reporting.ReportParameterType.Boolean;
            this.ReportParameters.Add(reportParameter1);
            this.ReportParameters.Add(reportParameter2);
            this.ReportParameters.Add(reportParameter3);
            this.ReportParameters.Add(reportParameter4);
            this.ReportParameters.Add(reportParameter5);
            this.ReportParameters.Add(reportParameter6);
            this.ReportParameters.Add(reportParameter7);
            this.ReportParameters.Add(reportParameter8);
            this.ReportParameters.Add(reportParameter9);
            this.ReportParameters.Add(reportParameter10);
            this.ReportParameters.Add(reportParameter11);
            this.ReportParameters.Add(reportParameter12);
            styleRule1.Selectors.AddRange(new Telerik.Reporting.Drawing.ISelector[] {
            new Telerik.Reporting.Drawing.TypeSelector(typeof(Telerik.Reporting.TextItemBase)),
            new Telerik.Reporting.Drawing.TypeSelector(typeof(Telerik.Reporting.HtmlTextBox))});
            styleRule1.Style.Padding.Left = Telerik.Reporting.Drawing.Unit.Point(2D);
            styleRule1.Style.Padding.Right = Telerik.Reporting.Drawing.Unit.Point(2D);
            this.StyleSheet.AddRange(new Telerik.Reporting.Drawing.StyleRule[] {
            styleRule1});
            this.Width = Telerik.Reporting.Drawing.Unit.Mm(210D);
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

        }
        #endregion
        private Telerik.Reporting.TextBox Text12;
        private Telerik.Reporting.TextBox PrintDate1;
        private Telerik.Reporting.TextBox Text11;
        private Telerik.Reporting.PageHeaderSection Area2;
        private Telerik.Reporting.Shape Box4;
        private Telerik.Reporting.TextBox Text2;
        private Telerik.Reporting.TextBox Text3;
        private Telerik.Reporting.TextBox Text5;
        private Telerik.Reporting.TextBox Text4;
        private Telerik.Reporting.TextBox Text13;
        private Telerik.Reporting.TextBox Text7;
        private Telerik.Reporting.DetailSection Area3;
        private Telerik.Reporting.TextBox RegistrationNumber1;
        private Telerik.Reporting.TextBox DisposalDate1;
        private Telerik.Reporting.TextBox DisposalReferance1;
        private Telerik.Reporting.TextBox Center1;
        private Telerik.Reporting.TextBox year1;
        private Telerik.Reporting.TextBox VehicleDescription1;
        private Telerik.Reporting.ReportFooterSection Area4;
        private Telerik.Reporting.PageFooterSection Area5;
        private Telerik.Reporting.TextBox PageNofM1;
        private Telerik.Reporting.Shape Box1;
        private Telerik.Reporting.SqlDataSource sqldsDisposedAssets;
        private Telerik.Reporting.PictureBox imgLogo;
    }
}