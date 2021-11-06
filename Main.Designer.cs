
namespace nw_fish
{
    partial class frmMain
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.displayTimer = new System.Windows.Forms.Timer(this.components);
            this.displayCombo = new System.Windows.Forms.ComboBox();
            this.displayBox = new System.Windows.Forms.PictureBox();
            this.targetAreaEditButton = new System.Windows.Forms.Button();
            this.displayAreaGroup = new System.Windows.Forms.GroupBox();
            this.equpBaitAreaCheckbox = new System.Windows.Forms.CheckBox();
            this.equipBaitAreaEditButton = new System.Windows.Forms.Button();
            this.baitAreaCheckbox = new System.Windows.Forms.CheckBox();
            this.baitAreaEditButton = new System.Windows.Forms.Button();
            this.encumberedAreaCheckbox = new System.Windows.Forms.CheckBox();
            this.encumberedAreaEditButton = new System.Windows.Forms.Button();
            this.repairAreaCheckbox = new System.Windows.Forms.CheckBox();
            this.repairAreaEditButton = new System.Windows.Forms.Button();
            this.displayAreaGroupVisibilityLabel = new System.Windows.Forms.Label();
            this.targetAreaCheckbox = new System.Windows.Forms.CheckBox();
            this.startButton = new System.Windows.Forms.Button();
            this.fishStartBox = new Emgu.CV.UI.ImageBox();
            this.fishStartLabel = new System.Windows.Forms.Label();
            this.fishCastLabel = new System.Windows.Forms.Label();
            this.fishCastBox = new Emgu.CV.UI.ImageBox();
            this.fishHookLabel = new System.Windows.Forms.Label();
            this.fishHookBox = new Emgu.CV.UI.ImageBox();
            this.fishHookToleranceLabel = new System.Windows.Forms.Label();
            this.fishHookToleranceNum = new System.Windows.Forms.NumericUpDown();
            this.fishCastToleranceNum = new System.Windows.Forms.NumericUpDown();
            this.fishCastToleranceLabel = new System.Windows.Forms.Label();
            this.fishStartToleranceNum = new System.Windows.Forms.NumericUpDown();
            this.fishStartToleranceLabel = new System.Windows.Forms.Label();
            this.templateImageGroup = new System.Windows.Forms.GroupBox();
            this.fishEncumberedToleranceNum = new System.Windows.Forms.NumericUpDown();
            this.fishEncumberedToleranceLabel = new System.Windows.Forms.Label();
            this.fishEncumberedLabel = new System.Windows.Forms.Label();
            this.fishEncumberedBox = new System.Windows.Forms.PictureBox();
            this.fishEncumberedPicker = new Cyotek.Windows.Forms.ScreenColorPicker();
            this.fishReelBox = new Emgu.CV.UI.ImageBox();
            this.fishReelToleranceNum = new System.Windows.Forms.NumericUpDown();
            this.fishReelLabel = new System.Windows.Forms.Label();
            this.fishReelToleranceLabel = new System.Windows.Forms.Label();
            this.fishReelWaitToleranceNum = new System.Windows.Forms.NumericUpDown();
            this.fishReelStopToleranceNum = new System.Windows.Forms.NumericUpDown();
            this.fishReelWaitToleranceLabel = new System.Windows.Forms.Label();
            this.fishReelStopToleranceLabel = new System.Windows.Forms.Label();
            this.fishReelStopLabel = new System.Windows.Forms.Label();
            this.fishReelStopBox = new System.Windows.Forms.PictureBox();
            this.fishReelStopPicker = new Cyotek.Windows.Forms.ScreenColorPicker();
            this.fishReelStartBox = new System.Windows.Forms.PictureBox();
            this.fishReelWaitBox = new System.Windows.Forms.PictureBox();
            this.fishReelStartLabel = new System.Windows.Forms.Label();
            this.fishReelWaitLabel = new System.Windows.Forms.Label();
            this.fishReelWaitPicker = new Cyotek.Windows.Forms.ScreenColorPicker();
            this.fishReelStartPicker = new Cyotek.Windows.Forms.ScreenColorPicker();
            this.fishReelStartToleranceLabel = new System.Windows.Forms.Label();
            this.fishReelStartToleranceNum = new System.Windows.Forms.NumericUpDown();
            this.fishRunCountLabel = new System.Windows.Forms.Label();
            this.presetsLoadButton = new System.Windows.Forms.Button();
            this.presetsSaveButton = new System.Windows.Forms.Button();
            this.presetsCombo = new System.Windows.Forms.ComboBox();
            this.presetsGroup = new System.Windows.Forms.GroupBox();
            this.generalOptionsGroup = new System.Windows.Forms.GroupBox();
            this.fishBaitCheckbox = new System.Windows.Forms.CheckBox();
            this.fishInventoryKeybindCombo = new System.Windows.Forms.ComboBox();
            this.fishEncumberedCheckbox = new System.Windows.Forms.CheckBox();
            this.fishInventoryKeybindLabel = new System.Windows.Forms.Label();
            this.fishFreeLookKeybindCombo = new System.Windows.Forms.ComboBox();
            this.fishFreeLookKeybindCheckbox = new System.Windows.Forms.CheckBox();
            this.fishFreeLookKeybindLabel = new System.Windows.Forms.Label();
            this.fishRepairSlider = new System.Windows.Forms.TrackBar();
            this.fishRepairLabel = new System.Windows.Forms.Label();
            this.fishAfkTimeCheckbox = new System.Windows.Forms.CheckBox();
            this.fishAfkTimeSlider = new System.Windows.Forms.TrackBar();
            this.fishAfkTimeLabel = new System.Windows.Forms.Label();
            this.fishCastPowerPercentage = new System.Windows.Forms.Label();
            this.fishCastPowerLabel = new System.Windows.Forms.Label();
            this.fishCastPowerSlider = new System.Windows.Forms.TrackBar();
            this.consoleGroup = new System.Windows.Forms.GroupBox();
            this.fishConsoleOutput = new nw_fish.ConsoleBox();
            ((System.ComponentModel.ISupportInitialize)(this.displayBox)).BeginInit();
            this.displayAreaGroup.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fishStartBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fishCastBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fishHookBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fishHookToleranceNum)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fishCastToleranceNum)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fishStartToleranceNum)).BeginInit();
            this.templateImageGroup.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fishEncumberedToleranceNum)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fishEncumberedBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fishReelBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fishReelToleranceNum)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fishReelWaitToleranceNum)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fishReelStopToleranceNum)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fishReelStopBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fishReelStartBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fishReelWaitBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fishReelStartToleranceNum)).BeginInit();
            this.presetsGroup.SuspendLayout();
            this.generalOptionsGroup.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fishRepairSlider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fishAfkTimeSlider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fishCastPowerSlider)).BeginInit();
            this.consoleGroup.SuspendLayout();
            this.SuspendLayout();
            // 
            // displayTimer
            // 
            this.displayTimer.Enabled = true;
            this.displayTimer.Interval = 60;
            this.displayTimer.Tick += new System.EventHandler(this.displayTimer_Tick);
            // 
            // displayCombo
            // 
            this.displayCombo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.displayCombo.FormattingEnabled = true;
            this.displayCombo.Location = new System.Drawing.Point(623, 12);
            this.displayCombo.Name = "displayCombo";
            this.displayCombo.Size = new System.Drawing.Size(200, 23);
            this.displayCombo.TabIndex = 0;
            this.displayCombo.SelectedIndexChanged += new System.EventHandler(this.displayCombo_SelectedIndexChanged);
            // 
            // displayBox
            // 
            this.displayBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.displayBox.Location = new System.Drawing.Point(12, 12);
            this.displayBox.Name = "displayBox";
            this.displayBox.Size = new System.Drawing.Size(605, 383);
            this.displayBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.displayBox.TabIndex = 1;
            this.displayBox.TabStop = false;
            this.displayBox.MouseDown += new System.Windows.Forms.MouseEventHandler(this.displayBox_MouseDown);
            this.displayBox.MouseEnter += new System.EventHandler(this.displayBox_MouseEnter);
            this.displayBox.MouseLeave += new System.EventHandler(this.displayBox_MouseLeave);
            this.displayBox.MouseMove += new System.Windows.Forms.MouseEventHandler(this.displayBox_MouseMove);
            this.displayBox.MouseUp += new System.Windows.Forms.MouseEventHandler(this.displayBox_MouseUp);
            // 
            // targetAreaEditButton
            // 
            this.targetAreaEditButton.Location = new System.Drawing.Point(123, 37);
            this.targetAreaEditButton.Name = "targetAreaEditButton";
            this.targetAreaEditButton.Size = new System.Drawing.Size(70, 23);
            this.targetAreaEditButton.TabIndex = 3;
            this.targetAreaEditButton.Text = "Edit";
            this.targetAreaEditButton.UseVisualStyleBackColor = true;
            this.targetAreaEditButton.Click += new System.EventHandler(this.targetAreaEditButton_Click);
            // 
            // displayAreaGroup
            // 
            this.displayAreaGroup.Controls.Add(this.equpBaitAreaCheckbox);
            this.displayAreaGroup.Controls.Add(this.equipBaitAreaEditButton);
            this.displayAreaGroup.Controls.Add(this.baitAreaCheckbox);
            this.displayAreaGroup.Controls.Add(this.baitAreaEditButton);
            this.displayAreaGroup.Controls.Add(this.encumberedAreaCheckbox);
            this.displayAreaGroup.Controls.Add(this.encumberedAreaEditButton);
            this.displayAreaGroup.Controls.Add(this.repairAreaCheckbox);
            this.displayAreaGroup.Controls.Add(this.repairAreaEditButton);
            this.displayAreaGroup.Controls.Add(this.displayAreaGroupVisibilityLabel);
            this.displayAreaGroup.Controls.Add(this.targetAreaCheckbox);
            this.displayAreaGroup.Controls.Add(this.targetAreaEditButton);
            this.displayAreaGroup.Location = new System.Drawing.Point(624, 41);
            this.displayAreaGroup.Name = "displayAreaGroup";
            this.displayAreaGroup.Size = new System.Drawing.Size(199, 189);
            this.displayAreaGroup.TabIndex = 4;
            this.displayAreaGroup.TabStop = false;
            this.displayAreaGroup.Text = "Areas";
            // 
            // equpBaitAreaCheckbox
            // 
            this.equpBaitAreaCheckbox.AutoSize = true;
            this.equpBaitAreaCheckbox.Checked = true;
            this.equpBaitAreaCheckbox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.equpBaitAreaCheckbox.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.equpBaitAreaCheckbox.Location = new System.Drawing.Point(18, 156);
            this.equpBaitAreaCheckbox.Name = "equpBaitAreaCheckbox";
            this.equpBaitAreaCheckbox.Size = new System.Drawing.Size(106, 19);
            this.equpBaitAreaCheckbox.TabIndex = 13;
            this.equpBaitAreaCheckbox.Text = "Equip Bait Area";
            this.equpBaitAreaCheckbox.UseVisualStyleBackColor = true;
            // 
            // equipBaitAreaEditButton
            // 
            this.equipBaitAreaEditButton.Location = new System.Drawing.Point(123, 153);
            this.equipBaitAreaEditButton.Name = "equipBaitAreaEditButton";
            this.equipBaitAreaEditButton.Size = new System.Drawing.Size(70, 23);
            this.equipBaitAreaEditButton.TabIndex = 12;
            this.equipBaitAreaEditButton.Text = "Edit";
            this.equipBaitAreaEditButton.UseVisualStyleBackColor = true;
            this.equipBaitAreaEditButton.Click += new System.EventHandler(this.equipBaitAreaEditButton_Click);
            // 
            // baitAreaCheckbox
            // 
            this.baitAreaCheckbox.AutoSize = true;
            this.baitAreaCheckbox.Checked = true;
            this.baitAreaCheckbox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.baitAreaCheckbox.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.baitAreaCheckbox.Location = new System.Drawing.Point(18, 127);
            this.baitAreaCheckbox.Name = "baitAreaCheckbox";
            this.baitAreaCheckbox.Size = new System.Drawing.Size(73, 19);
            this.baitAreaCheckbox.TabIndex = 11;
            this.baitAreaCheckbox.Text = "Bait Area";
            this.baitAreaCheckbox.UseVisualStyleBackColor = true;
            // 
            // baitAreaEditButton
            // 
            this.baitAreaEditButton.Location = new System.Drawing.Point(123, 124);
            this.baitAreaEditButton.Name = "baitAreaEditButton";
            this.baitAreaEditButton.Size = new System.Drawing.Size(70, 23);
            this.baitAreaEditButton.TabIndex = 10;
            this.baitAreaEditButton.Text = "Edit";
            this.baitAreaEditButton.UseVisualStyleBackColor = true;
            this.baitAreaEditButton.Click += new System.EventHandler(this.baitAreaEditButton_Click);
            // 
            // encumberedAreaCheckbox
            // 
            this.encumberedAreaCheckbox.AutoSize = true;
            this.encumberedAreaCheckbox.Checked = true;
            this.encumberedAreaCheckbox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.encumberedAreaCheckbox.Font = new System.Drawing.Font("Segoe UI", 7.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.encumberedAreaCheckbox.Location = new System.Drawing.Point(18, 98);
            this.encumberedAreaCheckbox.Name = "encumberedAreaCheckbox";
            this.encumberedAreaCheckbox.Size = new System.Drawing.Size(102, 16);
            this.encumberedAreaCheckbox.TabIndex = 9;
            this.encumberedAreaCheckbox.Text = "Encumbered Area";
            this.encumberedAreaCheckbox.UseVisualStyleBackColor = true;
            // 
            // encumberedAreaEditButton
            // 
            this.encumberedAreaEditButton.Location = new System.Drawing.Point(123, 95);
            this.encumberedAreaEditButton.Name = "encumberedAreaEditButton";
            this.encumberedAreaEditButton.Size = new System.Drawing.Size(70, 23);
            this.encumberedAreaEditButton.TabIndex = 8;
            this.encumberedAreaEditButton.Text = "Edit";
            this.encumberedAreaEditButton.UseVisualStyleBackColor = true;
            this.encumberedAreaEditButton.Click += new System.EventHandler(this.encumberedAreaEditButton_Click);
            // 
            // repairAreaCheckbox
            // 
            this.repairAreaCheckbox.AutoSize = true;
            this.repairAreaCheckbox.Checked = true;
            this.repairAreaCheckbox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.repairAreaCheckbox.Location = new System.Drawing.Point(18, 69);
            this.repairAreaCheckbox.Name = "repairAreaCheckbox";
            this.repairAreaCheckbox.Size = new System.Drawing.Size(86, 19);
            this.repairAreaCheckbox.TabIndex = 7;
            this.repairAreaCheckbox.Text = "Repair Area";
            this.repairAreaCheckbox.UseVisualStyleBackColor = true;
            // 
            // repairAreaEditButton
            // 
            this.repairAreaEditButton.Location = new System.Drawing.Point(123, 66);
            this.repairAreaEditButton.Name = "repairAreaEditButton";
            this.repairAreaEditButton.Size = new System.Drawing.Size(70, 23);
            this.repairAreaEditButton.TabIndex = 6;
            this.repairAreaEditButton.Text = "Edit";
            this.repairAreaEditButton.UseVisualStyleBackColor = true;
            this.repairAreaEditButton.Click += new System.EventHandler(this.repairAreaEditButton_Click);
            // 
            // displayAreaGroupVisibilityLabel
            // 
            this.displayAreaGroupVisibilityLabel.AutoSize = true;
            this.displayAreaGroupVisibilityLabel.Location = new System.Drawing.Point(6, 19);
            this.displayAreaGroupVisibilityLabel.Name = "displayAreaGroupVisibilityLabel";
            this.displayAreaGroupVisibilityLabel.Size = new System.Drawing.Size(41, 15);
            this.displayAreaGroupVisibilityLabel.TabIndex = 5;
            this.displayAreaGroupVisibilityLabel.Text = "Visible";
            // 
            // targetAreaCheckbox
            // 
            this.targetAreaCheckbox.AutoSize = true;
            this.targetAreaCheckbox.Checked = true;
            this.targetAreaCheckbox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.targetAreaCheckbox.Location = new System.Drawing.Point(18, 40);
            this.targetAreaCheckbox.Name = "targetAreaCheckbox";
            this.targetAreaCheckbox.Size = new System.Drawing.Size(85, 19);
            this.targetAreaCheckbox.TabIndex = 4;
            this.targetAreaCheckbox.Text = "Target Area";
            this.targetAreaCheckbox.UseVisualStyleBackColor = true;
            // 
            // startButton
            // 
            this.startButton.Location = new System.Drawing.Point(623, 703);
            this.startButton.Name = "startButton";
            this.startButton.Size = new System.Drawing.Size(200, 59);
            this.startButton.TabIndex = 5;
            this.startButton.Text = "Start";
            this.startButton.UseVisualStyleBackColor = true;
            this.startButton.Click += new System.EventHandler(this.startButton_Click);
            // 
            // fishStartBox
            // 
            this.fishStartBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.fishStartBox.FunctionalMode = Emgu.CV.UI.ImageBox.FunctionalModeOption.Minimum;
            this.fishStartBox.Location = new System.Drawing.Point(6, 40);
            this.fishStartBox.Name = "fishStartBox";
            this.fishStartBox.Size = new System.Drawing.Size(111, 118);
            this.fishStartBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.fishStartBox.TabIndex = 2;
            this.fishStartBox.TabStop = false;
            this.fishStartBox.Tag = "start";
            // 
            // fishStartLabel
            // 
            this.fishStartLabel.AutoSize = true;
            this.fishStartLabel.Location = new System.Drawing.Point(6, 22);
            this.fishStartLabel.Name = "fishStartLabel";
            this.fishStartLabel.Size = new System.Drawing.Size(31, 15);
            this.fishStartLabel.TabIndex = 6;
            this.fishStartLabel.Text = "Start";
            // 
            // fishCastLabel
            // 
            this.fishCastLabel.AutoSize = true;
            this.fishCastLabel.Location = new System.Drawing.Point(123, 22);
            this.fishCastLabel.Name = "fishCastLabel";
            this.fishCastLabel.Size = new System.Drawing.Size(30, 15);
            this.fishCastLabel.TabIndex = 8;
            this.fishCastLabel.Text = "Cast";
            // 
            // fishCastBox
            // 
            this.fishCastBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.fishCastBox.FunctionalMode = Emgu.CV.UI.ImageBox.FunctionalModeOption.Minimum;
            this.fishCastBox.Location = new System.Drawing.Point(123, 40);
            this.fishCastBox.Name = "fishCastBox";
            this.fishCastBox.Size = new System.Drawing.Size(111, 118);
            this.fishCastBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.fishCastBox.TabIndex = 7;
            this.fishCastBox.TabStop = false;
            this.fishCastBox.Tag = "cast";
            // 
            // fishHookLabel
            // 
            this.fishHookLabel.AutoSize = true;
            this.fishHookLabel.Location = new System.Drawing.Point(240, 22);
            this.fishHookLabel.Name = "fishHookLabel";
            this.fishHookLabel.Size = new System.Drawing.Size(36, 15);
            this.fishHookLabel.TabIndex = 10;
            this.fishHookLabel.Text = "Hook";
            // 
            // fishHookBox
            // 
            this.fishHookBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.fishHookBox.FunctionalMode = Emgu.CV.UI.ImageBox.FunctionalModeOption.Minimum;
            this.fishHookBox.Location = new System.Drawing.Point(240, 40);
            this.fishHookBox.Name = "fishHookBox";
            this.fishHookBox.Size = new System.Drawing.Size(111, 118);
            this.fishHookBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.fishHookBox.TabIndex = 9;
            this.fishHookBox.TabStop = false;
            this.fishHookBox.Tag = "hook";
            // 
            // fishHookToleranceLabel
            // 
            this.fishHookToleranceLabel.AutoSize = true;
            this.fishHookToleranceLabel.Location = new System.Drawing.Point(240, 166);
            this.fishHookToleranceLabel.Name = "fishHookToleranceLabel";
            this.fishHookToleranceLabel.Size = new System.Drawing.Size(57, 15);
            this.fishHookToleranceLabel.TabIndex = 11;
            this.fishHookToleranceLabel.Text = "Tolerance";
            // 
            // fishHookToleranceNum
            // 
            this.fishHookToleranceNum.DecimalPlaces = 2;
            this.fishHookToleranceNum.Increment = new decimal(new int[] {
            5,
            0,
            0,
            131072});
            this.fishHookToleranceNum.Location = new System.Drawing.Point(303, 164);
            this.fishHookToleranceNum.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            65536});
            this.fishHookToleranceNum.Name = "fishHookToleranceNum";
            this.fishHookToleranceNum.Size = new System.Drawing.Size(48, 23);
            this.fishHookToleranceNum.TabIndex = 12;
            this.fishHookToleranceNum.Tag = "hook";
            this.fishHookToleranceNum.Value = new decimal(new int[] {
            75,
            0,
            0,
            131072});
            this.fishHookToleranceNum.ValueChanged += new System.EventHandler(this.templateImageTolerance_ValueChanged);
            // 
            // fishCastToleranceNum
            // 
            this.fishCastToleranceNum.DecimalPlaces = 2;
            this.fishCastToleranceNum.Increment = new decimal(new int[] {
            5,
            0,
            0,
            131072});
            this.fishCastToleranceNum.Location = new System.Drawing.Point(186, 164);
            this.fishCastToleranceNum.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            65536});
            this.fishCastToleranceNum.Name = "fishCastToleranceNum";
            this.fishCastToleranceNum.Size = new System.Drawing.Size(48, 23);
            this.fishCastToleranceNum.TabIndex = 14;
            this.fishCastToleranceNum.Tag = "cast";
            this.fishCastToleranceNum.Value = new decimal(new int[] {
            75,
            0,
            0,
            131072});
            this.fishCastToleranceNum.ValueChanged += new System.EventHandler(this.templateImageTolerance_ValueChanged);
            // 
            // fishCastToleranceLabel
            // 
            this.fishCastToleranceLabel.AutoSize = true;
            this.fishCastToleranceLabel.Location = new System.Drawing.Point(123, 166);
            this.fishCastToleranceLabel.Name = "fishCastToleranceLabel";
            this.fishCastToleranceLabel.Size = new System.Drawing.Size(57, 15);
            this.fishCastToleranceLabel.TabIndex = 13;
            this.fishCastToleranceLabel.Text = "Tolerance";
            // 
            // fishStartToleranceNum
            // 
            this.fishStartToleranceNum.DecimalPlaces = 2;
            this.fishStartToleranceNum.Increment = new decimal(new int[] {
            5,
            0,
            0,
            131072});
            this.fishStartToleranceNum.Location = new System.Drawing.Point(69, 164);
            this.fishStartToleranceNum.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            65536});
            this.fishStartToleranceNum.Name = "fishStartToleranceNum";
            this.fishStartToleranceNum.Size = new System.Drawing.Size(48, 23);
            this.fishStartToleranceNum.TabIndex = 16;
            this.fishStartToleranceNum.Tag = "start";
            this.fishStartToleranceNum.Value = new decimal(new int[] {
            75,
            0,
            0,
            131072});
            this.fishStartToleranceNum.ValueChanged += new System.EventHandler(this.templateImageTolerance_ValueChanged);
            // 
            // fishStartToleranceLabel
            // 
            this.fishStartToleranceLabel.AutoSize = true;
            this.fishStartToleranceLabel.Location = new System.Drawing.Point(6, 166);
            this.fishStartToleranceLabel.Name = "fishStartToleranceLabel";
            this.fishStartToleranceLabel.Size = new System.Drawing.Size(57, 15);
            this.fishStartToleranceLabel.TabIndex = 15;
            this.fishStartToleranceLabel.Text = "Tolerance";
            // 
            // templateImageGroup
            // 
            this.templateImageGroup.Controls.Add(this.fishEncumberedToleranceNum);
            this.templateImageGroup.Controls.Add(this.fishEncumberedToleranceLabel);
            this.templateImageGroup.Controls.Add(this.fishEncumberedLabel);
            this.templateImageGroup.Controls.Add(this.fishEncumberedBox);
            this.templateImageGroup.Controls.Add(this.fishEncumberedPicker);
            this.templateImageGroup.Controls.Add(this.fishReelBox);
            this.templateImageGroup.Controls.Add(this.fishReelToleranceNum);
            this.templateImageGroup.Controls.Add(this.fishReelLabel);
            this.templateImageGroup.Controls.Add(this.fishReelToleranceLabel);
            this.templateImageGroup.Controls.Add(this.fishReelWaitToleranceNum);
            this.templateImageGroup.Controls.Add(this.fishCastBox);
            this.templateImageGroup.Controls.Add(this.fishStartToleranceNum);
            this.templateImageGroup.Controls.Add(this.fishStartBox);
            this.templateImageGroup.Controls.Add(this.fishStartToleranceLabel);
            this.templateImageGroup.Controls.Add(this.fishReelStopToleranceNum);
            this.templateImageGroup.Controls.Add(this.fishReelWaitToleranceLabel);
            this.templateImageGroup.Controls.Add(this.fishReelStopToleranceLabel);
            this.templateImageGroup.Controls.Add(this.fishStartLabel);
            this.templateImageGroup.Controls.Add(this.fishReelStopLabel);
            this.templateImageGroup.Controls.Add(this.fishCastToleranceNum);
            this.templateImageGroup.Controls.Add(this.fishReelStopBox);
            this.templateImageGroup.Controls.Add(this.fishReelStopPicker);
            this.templateImageGroup.Controls.Add(this.fishCastLabel);
            this.templateImageGroup.Controls.Add(this.fishCastToleranceLabel);
            this.templateImageGroup.Controls.Add(this.fishReelStartBox);
            this.templateImageGroup.Controls.Add(this.fishReelWaitBox);
            this.templateImageGroup.Controls.Add(this.fishReelStartLabel);
            this.templateImageGroup.Controls.Add(this.fishReelWaitLabel);
            this.templateImageGroup.Controls.Add(this.fishHookBox);
            this.templateImageGroup.Controls.Add(this.fishHookToleranceNum);
            this.templateImageGroup.Controls.Add(this.fishReelWaitPicker);
            this.templateImageGroup.Controls.Add(this.fishReelStartPicker);
            this.templateImageGroup.Controls.Add(this.fishHookLabel);
            this.templateImageGroup.Controls.Add(this.fishHookToleranceLabel);
            this.templateImageGroup.Controls.Add(this.fishReelStartToleranceLabel);
            this.templateImageGroup.Controls.Add(this.fishReelStartToleranceNum);
            this.templateImageGroup.Location = new System.Drawing.Point(12, 401);
            this.templateImageGroup.Name = "templateImageGroup";
            this.templateImageGroup.Size = new System.Drawing.Size(362, 361);
            this.templateImageGroup.TabIndex = 17;
            this.templateImageGroup.TabStop = false;
            this.templateImageGroup.Text = "Templates";
            // 
            // fishEncumberedToleranceNum
            // 
            this.fishEncumberedToleranceNum.DecimalPlaces = 2;
            this.fishEncumberedToleranceNum.Increment = new decimal(new int[] {
            5,
            0,
            0,
            131072});
            this.fishEncumberedToleranceNum.Location = new System.Drawing.Point(306, 332);
            this.fishEncumberedToleranceNum.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            65536});
            this.fishEncumberedToleranceNum.Name = "fishEncumberedToleranceNum";
            this.fishEncumberedToleranceNum.Size = new System.Drawing.Size(48, 23);
            this.fishEncumberedToleranceNum.TabIndex = 38;
            this.fishEncumberedToleranceNum.Tag = "encumbered";
            this.fishEncumberedToleranceNum.Value = new decimal(new int[] {
            95,
            0,
            0,
            131072});
            this.fishEncumberedToleranceNum.ValueChanged += new System.EventHandler(this.templateColorTolerance_ValueChanged);
            // 
            // fishEncumberedToleranceLabel
            // 
            this.fishEncumberedToleranceLabel.AutoSize = true;
            this.fishEncumberedToleranceLabel.Location = new System.Drawing.Point(239, 334);
            this.fishEncumberedToleranceLabel.Name = "fishEncumberedToleranceLabel";
            this.fishEncumberedToleranceLabel.Size = new System.Drawing.Size(57, 15);
            this.fishEncumberedToleranceLabel.TabIndex = 37;
            this.fishEncumberedToleranceLabel.Text = "Tolerance";
            // 
            // fishEncumberedLabel
            // 
            this.fishEncumberedLabel.AutoSize = true;
            this.fishEncumberedLabel.Location = new System.Drawing.Point(240, 275);
            this.fishEncumberedLabel.Name = "fishEncumberedLabel";
            this.fishEncumberedLabel.Size = new System.Drawing.Size(74, 15);
            this.fishEncumberedLabel.TabIndex = 35;
            this.fishEncumberedLabel.Text = "Encumbered";
            // 
            // fishEncumberedBox
            // 
            this.fishEncumberedBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.fishEncumberedBox.Location = new System.Drawing.Point(240, 293);
            this.fishEncumberedBox.Name = "fishEncumberedBox";
            this.fishEncumberedBox.Size = new System.Drawing.Size(56, 33);
            this.fishEncumberedBox.TabIndex = 36;
            this.fishEncumberedBox.TabStop = false;
            this.fishEncumberedBox.Tag = "encumbered";
            // 
            // fishEncumberedPicker
            // 
            this.fishEncumberedPicker.Color = System.Drawing.Color.Empty;
            this.fishEncumberedPicker.Location = new System.Drawing.Point(298, 293);
            this.fishEncumberedPicker.Name = "fishEncumberedPicker";
            this.fishEncumberedPicker.Size = new System.Drawing.Size(56, 33);
            this.fishEncumberedPicker.Text = "Select Colour";
            this.fishEncumberedPicker.ColorChanged += new System.EventHandler(this.fishEncumberedPicker_ColorChanged);
            // 
            // fishReelBox
            // 
            this.fishReelBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.fishReelBox.FunctionalMode = Emgu.CV.UI.ImageBox.FunctionalModeOption.Minimum;
            this.fishReelBox.Location = new System.Drawing.Point(6, 208);
            this.fishReelBox.Name = "fishReelBox";
            this.fishReelBox.Size = new System.Drawing.Size(111, 118);
            this.fishReelBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.fishReelBox.TabIndex = 30;
            this.fishReelBox.TabStop = false;
            this.fishReelBox.Tag = "reel";
            // 
            // fishReelToleranceNum
            // 
            this.fishReelToleranceNum.DecimalPlaces = 2;
            this.fishReelToleranceNum.Increment = new decimal(new int[] {
            5,
            0,
            0,
            131072});
            this.fishReelToleranceNum.Location = new System.Drawing.Point(69, 332);
            this.fishReelToleranceNum.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            65536});
            this.fishReelToleranceNum.Name = "fishReelToleranceNum";
            this.fishReelToleranceNum.Size = new System.Drawing.Size(48, 23);
            this.fishReelToleranceNum.TabIndex = 33;
            this.fishReelToleranceNum.Tag = "reel";
            this.fishReelToleranceNum.Value = new decimal(new int[] {
            65,
            0,
            0,
            131072});
            this.fishReelToleranceNum.ValueChanged += new System.EventHandler(this.templateImageTolerance_ValueChanged);
            // 
            // fishReelLabel
            // 
            this.fishReelLabel.AutoSize = true;
            this.fishReelLabel.Location = new System.Drawing.Point(6, 190);
            this.fishReelLabel.Name = "fishReelLabel";
            this.fishReelLabel.Size = new System.Drawing.Size(29, 15);
            this.fishReelLabel.TabIndex = 31;
            this.fishReelLabel.Text = "Reel";
            // 
            // fishReelToleranceLabel
            // 
            this.fishReelToleranceLabel.AutoSize = true;
            this.fishReelToleranceLabel.Location = new System.Drawing.Point(6, 334);
            this.fishReelToleranceLabel.Name = "fishReelToleranceLabel";
            this.fishReelToleranceLabel.Size = new System.Drawing.Size(57, 15);
            this.fishReelToleranceLabel.TabIndex = 32;
            this.fishReelToleranceLabel.Text = "Tolerance";
            // 
            // fishReelWaitToleranceNum
            // 
            this.fishReelWaitToleranceNum.DecimalPlaces = 2;
            this.fishReelWaitToleranceNum.Increment = new decimal(new int[] {
            5,
            0,
            0,
            131072});
            this.fishReelWaitToleranceNum.Location = new System.Drawing.Point(188, 332);
            this.fishReelWaitToleranceNum.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            65536});
            this.fishReelWaitToleranceNum.Name = "fishReelWaitToleranceNum";
            this.fishReelWaitToleranceNum.Size = new System.Drawing.Size(48, 23);
            this.fishReelWaitToleranceNum.TabIndex = 29;
            this.fishReelWaitToleranceNum.Tag = "reel_stop";
            this.fishReelWaitToleranceNum.Value = new decimal(new int[] {
            95,
            0,
            0,
            131072});
            this.fishReelWaitToleranceNum.ValueChanged += new System.EventHandler(this.templateColorTolerance_ValueChanged);
            // 
            // fishReelStopToleranceNum
            // 
            this.fishReelStopToleranceNum.DecimalPlaces = 2;
            this.fishReelStopToleranceNum.Increment = new decimal(new int[] {
            5,
            0,
            0,
            131072});
            this.fishReelStopToleranceNum.Location = new System.Drawing.Point(306, 247);
            this.fishReelStopToleranceNum.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            65536});
            this.fishReelStopToleranceNum.Name = "fishReelStopToleranceNum";
            this.fishReelStopToleranceNum.Size = new System.Drawing.Size(48, 23);
            this.fishReelStopToleranceNum.TabIndex = 22;
            this.fishReelStopToleranceNum.Tag = "reel_stop";
            this.fishReelStopToleranceNum.Value = new decimal(new int[] {
            95,
            0,
            0,
            131072});
            this.fishReelStopToleranceNum.ValueChanged += new System.EventHandler(this.templateColorTolerance_ValueChanged);
            // 
            // fishReelWaitToleranceLabel
            // 
            this.fishReelWaitToleranceLabel.AutoSize = true;
            this.fishReelWaitToleranceLabel.Location = new System.Drawing.Point(121, 334);
            this.fishReelWaitToleranceLabel.Name = "fishReelWaitToleranceLabel";
            this.fishReelWaitToleranceLabel.Size = new System.Drawing.Size(57, 15);
            this.fishReelWaitToleranceLabel.TabIndex = 28;
            this.fishReelWaitToleranceLabel.Text = "Tolerance";
            // 
            // fishReelStopToleranceLabel
            // 
            this.fishReelStopToleranceLabel.AutoSize = true;
            this.fishReelStopToleranceLabel.Location = new System.Drawing.Point(239, 249);
            this.fishReelStopToleranceLabel.Name = "fishReelStopToleranceLabel";
            this.fishReelStopToleranceLabel.Size = new System.Drawing.Size(57, 15);
            this.fishReelStopToleranceLabel.TabIndex = 21;
            this.fishReelStopToleranceLabel.Text = "Tolerance";
            // 
            // fishReelStopLabel
            // 
            this.fishReelStopLabel.AutoSize = true;
            this.fishReelStopLabel.Location = new System.Drawing.Point(240, 190);
            this.fishReelStopLabel.Name = "fishReelStopLabel";
            this.fishReelStopLabel.Size = new System.Drawing.Size(56, 15);
            this.fishReelStopLabel.TabIndex = 18;
            this.fishReelStopLabel.Text = "Reel Stop";
            // 
            // fishReelStopBox
            // 
            this.fishReelStopBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.fishReelStopBox.Location = new System.Drawing.Point(240, 208);
            this.fishReelStopBox.Name = "fishReelStopBox";
            this.fishReelStopBox.Size = new System.Drawing.Size(56, 33);
            this.fishReelStopBox.TabIndex = 20;
            this.fishReelStopBox.TabStop = false;
            this.fishReelStopBox.Tag = "reel_stop";
            // 
            // fishReelStopPicker
            // 
            this.fishReelStopPicker.Color = System.Drawing.Color.Empty;
            this.fishReelStopPicker.Location = new System.Drawing.Point(298, 208);
            this.fishReelStopPicker.Name = "fishReelStopPicker";
            this.fishReelStopPicker.Size = new System.Drawing.Size(56, 33);
            this.fishReelStopPicker.Text = "Select Colour";
            this.fishReelStopPicker.ColorChanged += new System.EventHandler(this.fishReelStopPicker_ColorChanged);
            // 
            // fishReelStartBox
            // 
            this.fishReelStartBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.fishReelStartBox.Location = new System.Drawing.Point(123, 208);
            this.fishReelStartBox.Name = "fishReelStartBox";
            this.fishReelStartBox.Size = new System.Drawing.Size(56, 33);
            this.fishReelStartBox.TabIndex = 18;
            this.fishReelStartBox.TabStop = false;
            this.fishReelStartBox.Tag = "reel_start";
            // 
            // fishReelWaitBox
            // 
            this.fishReelWaitBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.fishReelWaitBox.Location = new System.Drawing.Point(122, 293);
            this.fishReelWaitBox.Name = "fishReelWaitBox";
            this.fishReelWaitBox.Size = new System.Drawing.Size(56, 33);
            this.fishReelWaitBox.TabIndex = 27;
            this.fishReelWaitBox.TabStop = false;
            this.fishReelWaitBox.Tag = "reel_wait";
            // 
            // fishReelStartLabel
            // 
            this.fishReelStartLabel.AutoSize = true;
            this.fishReelStartLabel.Location = new System.Drawing.Point(123, 190);
            this.fishReelStartLabel.Name = "fishReelStartLabel";
            this.fishReelStartLabel.Size = new System.Drawing.Size(56, 15);
            this.fishReelStartLabel.TabIndex = 17;
            this.fishReelStartLabel.Text = "Reel Start";
            // 
            // fishReelWaitLabel
            // 
            this.fishReelWaitLabel.AutoSize = true;
            this.fishReelWaitLabel.Location = new System.Drawing.Point(122, 275);
            this.fishReelWaitLabel.Name = "fishReelWaitLabel";
            this.fishReelWaitLabel.Size = new System.Drawing.Size(56, 15);
            this.fishReelWaitLabel.TabIndex = 26;
            this.fishReelWaitLabel.Text = "Reel Wait";
            // 
            // fishReelWaitPicker
            // 
            this.fishReelWaitPicker.Color = System.Drawing.Color.Empty;
            this.fishReelWaitPicker.Location = new System.Drawing.Point(180, 293);
            this.fishReelWaitPicker.Name = "fishReelWaitPicker";
            this.fishReelWaitPicker.Size = new System.Drawing.Size(56, 33);
            this.fishReelWaitPicker.Text = "Select Colour";
            this.fishReelWaitPicker.ColorChanged += new System.EventHandler(this.fishReelWaitPicker_ColorChanged);
            // 
            // fishReelStartPicker
            // 
            this.fishReelStartPicker.Color = System.Drawing.Color.Empty;
            this.fishReelStartPicker.Location = new System.Drawing.Point(181, 208);
            this.fishReelStartPicker.Name = "fishReelStartPicker";
            this.fishReelStartPicker.Size = new System.Drawing.Size(56, 33);
            this.fishReelStartPicker.Text = "Select Colour";
            this.fishReelStartPicker.ColorChanged += new System.EventHandler(this.fishReelStartPicker_ColorChanged);
            // 
            // fishReelStartToleranceLabel
            // 
            this.fishReelStartToleranceLabel.AutoSize = true;
            this.fishReelStartToleranceLabel.Location = new System.Drawing.Point(122, 249);
            this.fishReelStartToleranceLabel.Name = "fishReelStartToleranceLabel";
            this.fishReelStartToleranceLabel.Size = new System.Drawing.Size(57, 15);
            this.fishReelStartToleranceLabel.TabIndex = 23;
            this.fishReelStartToleranceLabel.Text = "Tolerance";
            // 
            // fishReelStartToleranceNum
            // 
            this.fishReelStartToleranceNum.DecimalPlaces = 2;
            this.fishReelStartToleranceNum.Increment = new decimal(new int[] {
            5,
            0,
            0,
            131072});
            this.fishReelStartToleranceNum.Location = new System.Drawing.Point(189, 247);
            this.fishReelStartToleranceNum.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            65536});
            this.fishReelStartToleranceNum.Name = "fishReelStartToleranceNum";
            this.fishReelStartToleranceNum.Size = new System.Drawing.Size(48, 23);
            this.fishReelStartToleranceNum.TabIndex = 24;
            this.fishReelStartToleranceNum.Tag = "reel_start";
            this.fishReelStartToleranceNum.Value = new decimal(new int[] {
            95,
            0,
            0,
            131072});
            this.fishReelStartToleranceNum.ValueChanged += new System.EventHandler(this.templateColorTolerance_ValueChanged);
            // 
            // fishRunCountLabel
            // 
            this.fishRunCountLabel.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.fishRunCountLabel.Location = new System.Drawing.Point(623, 662);
            this.fishRunCountLabel.Name = "fishRunCountLabel";
            this.fishRunCountLabel.Size = new System.Drawing.Size(200, 32);
            this.fishRunCountLabel.TabIndex = 20;
            this.fishRunCountLabel.Text = "Runs: X";
            this.fishRunCountLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // presetsLoadButton
            // 
            this.presetsLoadButton.Location = new System.Drawing.Point(6, 51);
            this.presetsLoadButton.Name = "presetsLoadButton";
            this.presetsLoadButton.Size = new System.Drawing.Size(75, 23);
            this.presetsLoadButton.TabIndex = 26;
            this.presetsLoadButton.Text = "Load";
            this.presetsLoadButton.UseVisualStyleBackColor = true;
            this.presetsLoadButton.Click += new System.EventHandler(this.presetsLoadButton_Click);
            // 
            // presetsSaveButton
            // 
            this.presetsSaveButton.Location = new System.Drawing.Point(118, 51);
            this.presetsSaveButton.Name = "presetsSaveButton";
            this.presetsSaveButton.Size = new System.Drawing.Size(75, 23);
            this.presetsSaveButton.TabIndex = 27;
            this.presetsSaveButton.Text = "Save";
            this.presetsSaveButton.UseVisualStyleBackColor = true;
            this.presetsSaveButton.Click += new System.EventHandler(this.presetsSaveButton_Click);
            // 
            // presetsCombo
            // 
            this.presetsCombo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.presetsCombo.FormattingEnabled = true;
            this.presetsCombo.Location = new System.Drawing.Point(6, 22);
            this.presetsCombo.Name = "presetsCombo";
            this.presetsCombo.Size = new System.Drawing.Size(187, 23);
            this.presetsCombo.TabIndex = 28;
            this.presetsCombo.SelectedIndexChanged += new System.EventHandler(this.presetsCombo_SelectedIndexChanged);
            // 
            // presetsGroup
            // 
            this.presetsGroup.Controls.Add(this.presetsCombo);
            this.presetsGroup.Controls.Add(this.presetsLoadButton);
            this.presetsGroup.Controls.Add(this.presetsSaveButton);
            this.presetsGroup.Location = new System.Drawing.Point(623, 565);
            this.presetsGroup.Name = "presetsGroup";
            this.presetsGroup.Size = new System.Drawing.Size(199, 83);
            this.presetsGroup.TabIndex = 32;
            this.presetsGroup.TabStop = false;
            this.presetsGroup.Text = "Presets";
            // 
            // generalOptionsGroup
            // 
            this.generalOptionsGroup.Controls.Add(this.fishBaitCheckbox);
            this.generalOptionsGroup.Controls.Add(this.fishInventoryKeybindCombo);
            this.generalOptionsGroup.Controls.Add(this.fishEncumberedCheckbox);
            this.generalOptionsGroup.Controls.Add(this.fishInventoryKeybindLabel);
            this.generalOptionsGroup.Controls.Add(this.fishFreeLookKeybindCombo);
            this.generalOptionsGroup.Controls.Add(this.fishFreeLookKeybindCheckbox);
            this.generalOptionsGroup.Controls.Add(this.fishFreeLookKeybindLabel);
            this.generalOptionsGroup.Controls.Add(this.fishRepairSlider);
            this.generalOptionsGroup.Controls.Add(this.fishRepairLabel);
            this.generalOptionsGroup.Controls.Add(this.fishAfkTimeCheckbox);
            this.generalOptionsGroup.Controls.Add(this.fishAfkTimeSlider);
            this.generalOptionsGroup.Controls.Add(this.fishAfkTimeLabel);
            this.generalOptionsGroup.Controls.Add(this.fishCastPowerPercentage);
            this.generalOptionsGroup.Controls.Add(this.fishCastPowerLabel);
            this.generalOptionsGroup.Controls.Add(this.fishCastPowerSlider);
            this.generalOptionsGroup.Location = new System.Drawing.Point(623, 236);
            this.generalOptionsGroup.Name = "generalOptionsGroup";
            this.generalOptionsGroup.Size = new System.Drawing.Size(200, 325);
            this.generalOptionsGroup.TabIndex = 32;
            this.generalOptionsGroup.TabStop = false;
            this.generalOptionsGroup.Text = "Options";
            // 
            // fishBaitCheckbox
            // 
            this.fishBaitCheckbox.AutoSize = true;
            this.fishBaitCheckbox.Location = new System.Drawing.Point(6, 297);
            this.fishBaitCheckbox.Name = "fishBaitCheckbox";
            this.fishBaitCheckbox.Size = new System.Drawing.Size(79, 19);
            this.fishBaitCheckbox.TabIndex = 32;
            this.fishBaitCheckbox.Text = "Equip Bait";
            this.fishBaitCheckbox.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.fishBaitCheckbox.UseVisualStyleBackColor = true;
            this.fishBaitCheckbox.CheckedChanged += new System.EventHandler(this.fishBaitCheckbox_CheckedChanged);
            // 
            // fishInventoryKeybindCombo
            // 
            this.fishInventoryKeybindCombo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.fishInventoryKeybindCombo.FormattingEnabled = true;
            this.fishInventoryKeybindCombo.Location = new System.Drawing.Point(6, 243);
            this.fishInventoryKeybindCombo.Name = "fishInventoryKeybindCombo";
            this.fishInventoryKeybindCombo.Size = new System.Drawing.Size(187, 23);
            this.fishInventoryKeybindCombo.TabIndex = 30;
            this.fishInventoryKeybindCombo.SelectedIndexChanged += new System.EventHandler(this.fishInventoryKeybindCombo_SelectedIndexChanged);
            // 
            // fishEncumberedCheckbox
            // 
            this.fishEncumberedCheckbox.AutoSize = true;
            this.fishEncumberedCheckbox.Location = new System.Drawing.Point(6, 272);
            this.fishEncumberedCheckbox.Name = "fishEncumberedCheckbox";
            this.fishEncumberedCheckbox.Size = new System.Drawing.Size(149, 19);
            this.fishEncumberedCheckbox.TabIndex = 31;
            this.fishEncumberedCheckbox.Text = "Stop once encumbered";
            this.fishEncumberedCheckbox.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.fishEncumberedCheckbox.UseVisualStyleBackColor = true;
            this.fishEncumberedCheckbox.CheckedChanged += new System.EventHandler(this.fishEncumberedCheckbox_CheckedChanged);
            // 
            // fishInventoryKeybindLabel
            // 
            this.fishInventoryKeybindLabel.AutoSize = true;
            this.fishInventoryKeybindLabel.Location = new System.Drawing.Point(3, 226);
            this.fishInventoryKeybindLabel.Name = "fishInventoryKeybindLabel";
            this.fishInventoryKeybindLabel.Size = new System.Drawing.Size(103, 15);
            this.fishInventoryKeybindLabel.TabIndex = 29;
            this.fishInventoryKeybindLabel.Text = "Inventory Keybind";
            // 
            // fishFreeLookKeybindCombo
            // 
            this.fishFreeLookKeybindCombo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.fishFreeLookKeybindCombo.FormattingEnabled = true;
            this.fishFreeLookKeybindCombo.Location = new System.Drawing.Point(6, 194);
            this.fishFreeLookKeybindCombo.Name = "fishFreeLookKeybindCombo";
            this.fishFreeLookKeybindCombo.Size = new System.Drawing.Size(188, 23);
            this.fishFreeLookKeybindCombo.TabIndex = 28;
            this.fishFreeLookKeybindCombo.SelectedIndexChanged += new System.EventHandler(this.fishFreeLookKeybindCombo_SelectedIndexChanged);
            // 
            // fishFreeLookKeybindCheckbox
            // 
            this.fishFreeLookKeybindCheckbox.AutoSize = true;
            this.fishFreeLookKeybindCheckbox.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.fishFreeLookKeybindCheckbox.Location = new System.Drawing.Point(126, 177);
            this.fishFreeLookKeybindCheckbox.Name = "fishFreeLookKeybindCheckbox";
            this.fishFreeLookKeybindCheckbox.Size = new System.Drawing.Size(68, 19);
            this.fishFreeLookKeybindCheckbox.TabIndex = 27;
            this.fishFreeLookKeybindCheckbox.Text = "Enabled";
            this.fishFreeLookKeybindCheckbox.UseVisualStyleBackColor = true;
            this.fishFreeLookKeybindCheckbox.CheckedChanged += new System.EventHandler(this.fishFreeLookKeybindCheckbox_CheckedChanged);
            // 
            // fishFreeLookKeybindLabel
            // 
            this.fishFreeLookKeybindLabel.AutoSize = true;
            this.fishFreeLookKeybindLabel.Location = new System.Drawing.Point(3, 177);
            this.fishFreeLookKeybindLabel.Name = "fishFreeLookKeybindLabel";
            this.fishFreeLookKeybindLabel.Size = new System.Drawing.Size(104, 15);
            this.fishFreeLookKeybindLabel.TabIndex = 26;
            this.fishFreeLookKeybindLabel.Text = "Free Look Keybind";
            // 
            // fishRepairSlider
            // 
            this.fishRepairSlider.AutoSize = false;
            this.fishRepairSlider.Location = new System.Drawing.Point(6, 139);
            this.fishRepairSlider.Minimum = 1;
            this.fishRepairSlider.Name = "fishRepairSlider";
            this.fishRepairSlider.Size = new System.Drawing.Size(188, 30);
            this.fishRepairSlider.TabIndex = 25;
            this.fishRepairSlider.Value = 1;
            this.fishRepairSlider.ValueChanged += new System.EventHandler(this.fishRepairSlider_ValueChanged);
            // 
            // fishRepairLabel
            // 
            this.fishRepairLabel.AutoSize = true;
            this.fishRepairLabel.Location = new System.Drawing.Point(3, 121);
            this.fishRepairLabel.Name = "fishRepairLabel";
            this.fishRepairLabel.Size = new System.Drawing.Size(103, 15);
            this.fishRepairLabel.TabIndex = 24;
            this.fishRepairLabel.Text = "Repair after X runs";
            // 
            // fishAfkTimeCheckbox
            // 
            this.fishAfkTimeCheckbox.AutoSize = true;
            this.fishAfkTimeCheckbox.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.fishAfkTimeCheckbox.Location = new System.Drawing.Point(119, 72);
            this.fishAfkTimeCheckbox.Name = "fishAfkTimeCheckbox";
            this.fishAfkTimeCheckbox.Size = new System.Drawing.Size(74, 19);
            this.fishAfkTimeCheckbox.TabIndex = 23;
            this.fishAfkTimeCheckbox.Text = "Anti-AFK";
            this.fishAfkTimeCheckbox.UseVisualStyleBackColor = true;
            // 
            // fishAfkTimeSlider
            // 
            this.fishAfkTimeSlider.AutoSize = false;
            this.fishAfkTimeSlider.LargeChange = 2;
            this.fishAfkTimeSlider.Location = new System.Drawing.Point(6, 91);
            this.fishAfkTimeSlider.Maximum = 9;
            this.fishAfkTimeSlider.Minimum = 1;
            this.fishAfkTimeSlider.Name = "fishAfkTimeSlider";
            this.fishAfkTimeSlider.Size = new System.Drawing.Size(188, 30);
            this.fishAfkTimeSlider.TabIndex = 22;
            this.fishAfkTimeSlider.Value = 1;
            this.fishAfkTimeSlider.ValueChanged += new System.EventHandler(this.fishAfkTimeSlider_ValueChanged);
            // 
            // fishAfkTimeLabel
            // 
            this.fishAfkTimeLabel.AutoSize = true;
            this.fishAfkTimeLabel.Location = new System.Drawing.Point(3, 73);
            this.fishAfkTimeLabel.Name = "fishAfkTimeLabel";
            this.fishAfkTimeLabel.Size = new System.Drawing.Size(103, 15);
            this.fishAfkTimeLabel.TabIndex = 21;
            this.fishAfkTimeLabel.Text = "Move after X mins";
            // 
            // fishCastPowerPercentage
            // 
            this.fishCastPowerPercentage.AutoSize = true;
            this.fishCastPowerPercentage.Dock = System.Windows.Forms.DockStyle.Right;
            this.fishCastPowerPercentage.Location = new System.Drawing.Point(173, 19);
            this.fishCastPowerPercentage.Name = "fishCastPowerPercentage";
            this.fishCastPowerPercentage.Size = new System.Drawing.Size(24, 15);
            this.fishCastPowerPercentage.TabIndex = 20;
            this.fishCastPowerPercentage.Text = "X%";
            // 
            // fishCastPowerLabel
            // 
            this.fishCastPowerLabel.AutoSize = true;
            this.fishCastPowerLabel.Dock = System.Windows.Forms.DockStyle.Left;
            this.fishCastPowerLabel.Location = new System.Drawing.Point(3, 19);
            this.fishCastPowerLabel.Name = "fishCastPowerLabel";
            this.fishCastPowerLabel.Size = new System.Drawing.Size(66, 15);
            this.fishCastPowerLabel.TabIndex = 19;
            this.fishCastPowerLabel.Text = "Cast Power";
            // 
            // fishCastPowerSlider
            // 
            this.fishCastPowerSlider.AutoSize = false;
            this.fishCastPowerSlider.LargeChange = 2;
            this.fishCastPowerSlider.Location = new System.Drawing.Point(6, 40);
            this.fishCastPowerSlider.Maximum = 20;
            this.fishCastPowerSlider.Minimum = 1;
            this.fishCastPowerSlider.Name = "fishCastPowerSlider";
            this.fishCastPowerSlider.Size = new System.Drawing.Size(188, 30);
            this.fishCastPowerSlider.TabIndex = 18;
            this.fishCastPowerSlider.Value = 20;
            this.fishCastPowerSlider.ValueChanged += new System.EventHandler(this.fishCastPowerSlider_ValueChanged);
            // 
            // consoleGroup
            // 
            this.consoleGroup.Controls.Add(this.fishConsoleOutput);
            this.consoleGroup.Location = new System.Drawing.Point(375, 401);
            this.consoleGroup.Name = "consoleGroup";
            this.consoleGroup.Size = new System.Drawing.Size(242, 361);
            this.consoleGroup.TabIndex = 33;
            this.consoleGroup.TabStop = false;
            this.consoleGroup.Text = "Console";
            // 
            // fishConsoleOutput
            // 
            this.fishConsoleOutput.BackColor = System.Drawing.SystemColors.Control;
            this.fishConsoleOutput.Cursor = System.Windows.Forms.Cursors.Default;
            this.fishConsoleOutput.Location = new System.Drawing.Point(6, 22);
            this.fishConsoleOutput.Multiline = true;
            this.fishConsoleOutput.Name = "fishConsoleOutput";
            this.fishConsoleOutput.ReadOnly = true;
            this.fishConsoleOutput.SelectionHighlightEnabled = false;
            this.fishConsoleOutput.Size = new System.Drawing.Size(230, 327);
            this.fishConsoleOutput.TabIndex = 1;
            this.fishConsoleOutput.TabStop = false;
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(829, 768);
            this.Controls.Add(this.consoleGroup);
            this.Controls.Add(this.generalOptionsGroup);
            this.Controls.Add(this.presetsGroup);
            this.Controls.Add(this.fishRunCountLabel);
            this.Controls.Add(this.templateImageGroup);
            this.Controls.Add(this.startButton);
            this.Controls.Add(this.displayAreaGroup);
            this.Controls.Add(this.displayBox);
            this.Controls.Add(this.displayCombo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "frmMain";
            this.Text = "Reeling Ronald";
            this.Load += new System.EventHandler(this.frmMain_Load);
            ((System.ComponentModel.ISupportInitialize)(this.displayBox)).EndInit();
            this.displayAreaGroup.ResumeLayout(false);
            this.displayAreaGroup.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fishStartBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fishCastBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fishHookBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fishHookToleranceNum)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fishCastToleranceNum)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fishStartToleranceNum)).EndInit();
            this.templateImageGroup.ResumeLayout(false);
            this.templateImageGroup.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fishEncumberedToleranceNum)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fishEncumberedBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fishReelBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fishReelToleranceNum)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fishReelWaitToleranceNum)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fishReelStopToleranceNum)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fishReelStopBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fishReelStartBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fishReelWaitBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fishReelStartToleranceNum)).EndInit();
            this.presetsGroup.ResumeLayout(false);
            this.generalOptionsGroup.ResumeLayout(false);
            this.generalOptionsGroup.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fishRepairSlider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fishAfkTimeSlider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fishCastPowerSlider)).EndInit();
            this.consoleGroup.ResumeLayout(false);
            this.consoleGroup.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Timer displayTimer;
        private System.Windows.Forms.ComboBox displayCombo;
        private System.Windows.Forms.PictureBox displayBox;
        private System.Windows.Forms.Button targetAreaEditButton;
        private System.Windows.Forms.GroupBox displayAreaGroup;
        private System.Windows.Forms.CheckBox targetAreaCheckbox;
        private System.Windows.Forms.Label displayAreaGroupVisibilityLabel;
        private System.Windows.Forms.Button startButton;
        private Emgu.CV.UI.ImageBox fishStartBox;
        private System.Windows.Forms.Label fishStartLabel;
        private System.Windows.Forms.Label fishCastLabel;
        private Emgu.CV.UI.ImageBox fishCastBox;
        private System.Windows.Forms.Label fishHookLabel;
        private Emgu.CV.UI.ImageBox fishHookBox;
        private System.Windows.Forms.Label fishHookToleranceLabel;
        private System.Windows.Forms.NumericUpDown fishHookToleranceNum;
        private System.Windows.Forms.NumericUpDown fishCastToleranceNum;
        private System.Windows.Forms.Label fishCastToleranceLabel;
        private System.Windows.Forms.NumericUpDown fishStartToleranceNum;
        private System.Windows.Forms.Label fishStartToleranceLabel;
        private System.Windows.Forms.GroupBox templateImageGroup;
        private Cyotek.Windows.Forms.ScreenColorPicker fishReelStartPicker;
        private System.Windows.Forms.Label fishReelStopLabel;
        private System.Windows.Forms.Label fishReelStartLabel;
        private System.Windows.Forms.PictureBox fishReelStopBox;
        private Cyotek.Windows.Forms.ScreenColorPicker fishReelStopPicker;
        private System.Windows.Forms.PictureBox fishReelStartBox;
        private System.Windows.Forms.NumericUpDown fishReelStartToleranceNum;
        private System.Windows.Forms.Label fishReelStartToleranceLabel;
        private System.Windows.Forms.NumericUpDown fishReelStopToleranceNum;
        private System.Windows.Forms.Label fishReelStopToleranceLabel;
        private System.Windows.Forms.NumericUpDown fishReelWaitToleranceNum;
        private System.Windows.Forms.Label fishReelWaitToleranceLabel;
        private System.Windows.Forms.PictureBox fishReelWaitBox;
        private Cyotek.Windows.Forms.ScreenColorPicker fishReelWaitPicker;
        private System.Windows.Forms.Label fishReelWaitLabel;
        private System.Windows.Forms.CheckBox repairAreaCheckbox;
        private System.Windows.Forms.Button repairAreaEditButton;
        private System.Windows.Forms.Label fishRunCountLabel;
        private System.Windows.Forms.Button presetsLoadButton;
        private System.Windows.Forms.Button presetsSaveButton;
        private System.Windows.Forms.ComboBox presetsCombo;
        private System.Windows.Forms.CheckBox encumberedAreaCheckbox;
        private System.Windows.Forms.Button encumberedAreaEditButton;
        private System.Windows.Forms.GroupBox presetsGroup;
        private System.Windows.Forms.CheckBox equpBaitAreaCheckbox;
        private System.Windows.Forms.Button equipBaitAreaEditButton;
        private System.Windows.Forms.CheckBox baitAreaCheckbox;
        private System.Windows.Forms.Button baitAreaEditButton;
        private System.Windows.Forms.GroupBox generalOptionsGroup;
        private System.Windows.Forms.CheckBox fishBaitCheckbox;
        private System.Windows.Forms.ComboBox fishInventoryKeybindCombo;
        private System.Windows.Forms.CheckBox fishEncumberedCheckbox;
        private System.Windows.Forms.Label fishInventoryKeybindLabel;
        private System.Windows.Forms.ComboBox fishFreeLookKeybindCombo;
        private System.Windows.Forms.CheckBox fishFreeLookKeybindCheckbox;
        private System.Windows.Forms.Label fishFreeLookKeybindLabel;
        private System.Windows.Forms.TrackBar fishRepairSlider;
        private System.Windows.Forms.Label fishRepairLabel;
        private System.Windows.Forms.CheckBox fishAfkTimeCheckbox;
        private System.Windows.Forms.TrackBar fishAfkTimeSlider;
        private System.Windows.Forms.Label fishAfkTimeLabel;
        private System.Windows.Forms.Label fishCastPowerPercentage;
        private System.Windows.Forms.Label fishCastPowerLabel;
        private System.Windows.Forms.TrackBar fishCastPowerSlider;
        private System.Windows.Forms.GroupBox consoleGroup;
        private ConsoleBox fishConsoleOutput;
        private System.Windows.Forms.NumericUpDown fishEncumberedToleranceNum;
        private System.Windows.Forms.Label fishEncumberedToleranceLabel;
        private System.Windows.Forms.Label fishEncumberedLabel;
        private System.Windows.Forms.PictureBox fishEncumberedBox;
        private Cyotek.Windows.Forms.ScreenColorPicker fishEncumberedPicker;
        private Emgu.CV.UI.ImageBox fishReelBox;
        private System.Windows.Forms.NumericUpDown fishReelToleranceNum;
        private System.Windows.Forms.Label fishReelLabel;
        private System.Windows.Forms.Label fishReelToleranceLabel;
    }
}

