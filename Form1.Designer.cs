using SamWafIpMonitor.component;

namespace SamWafIpMonitor
{
    partial class Form1
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
            components = new System.ComponentModel.Container();
            lvLog = new ListViewBuff();
            chNo = new ColumnHeader();
            chTime = new ColumnHeader();
            chPid = new ColumnHeader();
            chTitle = new ColumnHeader();
            chSrcIp = new ColumnHeader();
            chDstIp = new ColumnHeader();
            chDstPort = new ColumnHeader();
            chPath = new ColumnHeader();
            timerFlush = new System.Windows.Forms.Timer(components);
            bgwNet = new System.ComponentModel.BackgroundWorker();
            groupBox1 = new GroupBox();
            groupBox2 = new GroupBox();
            txtFilterDstIp = new TextBox();
            label2 = new Label();
            txtFilterPid = new TextBox();
            label1 = new Label();
            cbxFilter = new CheckBox();
            cbxIsScroll = new CheckBox();
            cbxClear = new CheckBox();
            btnJumpGithub = new Button();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            SuspendLayout();
            // 
            // lvLog
            // 
            lvLog.Columns.AddRange(new ColumnHeader[] { chNo, chTime, chPid, chTitle, chSrcIp, chDstIp, chDstPort, chPath });
            lvLog.Dock = DockStyle.Fill;
            lvLog.FullRowSelect = true;
            lvLog.GridLines = true;
            lvLog.Location = new Point(3, 34);
            lvLog.Name = "lvLog";
            lvLog.Size = new Size(1579, 558);
            lvLog.TabIndex = 0;
            lvLog.UseCompatibleStateImageBehavior = false;
            lvLog.View = View.Details;
            // 
            // chNo
            // 
            chNo.Text = "序号";
            // 
            // chTime
            // 
            chTime.Text = "时间";
            chTime.Width = 220;
            // 
            // chPid
            // 
            chPid.Text = "PID";
            chPid.Width = 100;
            // 
            // chTitle
            // 
            chTitle.Text = "进程名";
            chTitle.Width = 200;
            // 
            // chSrcIp
            // 
            chSrcIp.Text = "源IP";
            chSrcIp.Width = 200;
            // 
            // chDstIp
            // 
            chDstIp.Text = "目标IP";
            chDstIp.Width = 200;
            // 
            // chDstPort
            // 
            chDstPort.Text = "目标端口";
            chDstPort.Width = 120;
            // 
            // chPath
            // 
            chPath.Text = "路径";
            chPath.Width = 500;
            // 
            // timerFlush
            // 
            timerFlush.Enabled = true;
            timerFlush.Interval = 1000;
            timerFlush.Tick += timerFlush_Tick;
            // 
            // bgwNet
            // 
            bgwNet.DoWork += bgwNet_DoWork;
            // 
            // groupBox1
            // 
            groupBox1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            groupBox1.Controls.Add(lvLog);
            groupBox1.Location = new Point(24, 197);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(1585, 595);
            groupBox1.TabIndex = 2;
            groupBox1.TabStop = false;
            groupBox1.Text = "信息";
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(txtFilterDstIp);
            groupBox2.Controls.Add(label2);
            groupBox2.Controls.Add(txtFilterPid);
            groupBox2.Controls.Add(label1);
            groupBox2.Location = new Point(30, 25);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(1203, 147);
            groupBox2.TabIndex = 3;
            groupBox2.TabStop = false;
            groupBox2.Text = "条件";
            // 
            // txtFilterDstIp
            // 
            txtFilterDstIp.Location = new Point(110, 93);
            txtFilterDstIp.Name = "txtFilterDstIp";
            txtFilterDstIp.Size = new Size(200, 38);
            txtFilterDstIp.TabIndex = 3;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(12, 86);
            label2.Name = "label2";
            label2.Size = new Size(84, 31);
            label2.TabIndex = 2;
            label2.Text = "目标IP";
            // 
            // txtFilterPid
            // 
            txtFilterPid.Location = new Point(114, 28);
            txtFilterPid.Name = "txtFilterPid";
            txtFilterPid.Size = new Size(200, 38);
            txtFilterPid.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 28);
            label1.Name = "label1";
            label1.Size = new Size(54, 31);
            label1.TabIndex = 0;
            label1.Text = "PID";
            // 
            // cbxFilter
            // 
            cbxFilter.AutoSize = true;
            cbxFilter.Location = new Point(1255, 49);
            cbxFilter.Name = "cbxFilter";
            cbxFilter.Size = new Size(94, 35);
            cbxFilter.TabIndex = 5;
            cbxFilter.Text = "过滤";
            cbxFilter.UseVisualStyleBackColor = true;
            cbxFilter.CheckedChanged += cbxFilter_CheckedChanged;
            // 
            // cbxIsScroll
            // 
            cbxIsScroll.AutoSize = true;
            cbxIsScroll.Checked = true;
            cbxIsScroll.CheckState = CheckState.Checked;
            cbxIsScroll.Location = new Point(1255, 90);
            cbxIsScroll.Name = "cbxIsScroll";
            cbxIsScroll.Size = new Size(142, 35);
            cbxIsScroll.TabIndex = 6;
            cbxIsScroll.Text = "自动滚动";
            cbxIsScroll.UseVisualStyleBackColor = true;
            cbxIsScroll.CheckedChanged += cbxIsScroll_CheckedChanged;
            // 
            // cbxClear
            // 
            cbxClear.AutoSize = true;
            cbxClear.Checked = true;
            cbxClear.CheckState = CheckState.Checked;
            cbxClear.Location = new Point(1255, 137);
            cbxClear.Name = "cbxClear";
            cbxClear.Size = new Size(242, 35);
            cbxClear.TabIndex = 7;
            cbxClear.Text = "超过10W自动清空";
            cbxClear.UseVisualStyleBackColor = true;
            cbxClear.CheckedChanged += cbxClear_CheckedChanged;
            // 
            // btnJumpGithub
            // 
            btnJumpGithub.Location = new Point(1432, 38);
            btnJumpGithub.Name = "btnJumpGithub";
            btnJumpGithub.Size = new Size(150, 46);
            btnJumpGithub.TabIndex = 8;
            btnJumpGithub.Text = "github";
            btnJumpGithub.UseVisualStyleBackColor = true;
            btnJumpGithub.Click += btnJumpGithub_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(14F, 31F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1621, 824);
            Controls.Add(btnJumpGithub);
            Controls.Add(cbxClear);
            Controls.Add(cbxIsScroll);
            Controls.Add(cbxFilter);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            groupBox1.ResumeLayout(false);
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ListViewBuff lvLog;
        private ColumnHeader chTime;
        private ColumnHeader chPid;
        private ColumnHeader chTitle;
        private ColumnHeader chPath;
        private ColumnHeader chSrcIp;
        private ColumnHeader chDstIp;
        private ColumnHeader chDstPort;
        private System.Windows.Forms.Timer timerFlush;
        private ColumnHeader chNo;
        private System.ComponentModel.BackgroundWorker bgwNet;
        private GroupBox groupBox1;
        private GroupBox groupBox2;
        private Label label1;
        private TextBox txtFilterPid;
        private CheckBox cbxFilter;
        private Label label2;
        private TextBox txtFilterDstIp;
        private CheckBox cbxIsScroll;
        private CheckBox cbxClear;
        private Button btnJumpGithub;
    }
}
