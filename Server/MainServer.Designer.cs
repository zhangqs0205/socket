namespace Server
{

        partial class MainServer
        {
            /// <summary>
            /// 必需的设计器变量。
            /// </summary>
            private System.ComponentModel.IContainer components = null;

            /// <summary>
            /// 清理所有正在使用的资源。
            /// </summary>
            /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
            protected override void Dispose(bool disposing)
            {
                this.Visible = false;
                this.notifyIcon1.BalloonTipText = serverStatus;
                this.notifyIcon1.ShowBalloonTip(0);
                //if (disposing && (components != null))
                //{
                //    components.Dispose();
                //}
                //base.Dispose(disposing);
            }

            #region Windows 窗体设计器生成的代码

            /// <summary>
            /// 设计器支持所需的方法 - 不要
            /// 使用代码编辑器修改此方法的内容。
            /// </summary>
            private void InitializeComponent()
            {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainServer));
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.cbIPAdress = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.pbServerStatus = new System.Windows.Forms.PictureBox();
            this.btStartSverver = new System.Windows.Forms.Button();
            this.btStopSverver = new System.Windows.Forms.Button();
            this.btConfigSverver = new System.Windows.Forms.Button();
            this.btClose = new System.Windows.Forms.Button();
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.cmsServer = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tsmiStartServer = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiStopServer = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiExit = new System.Windows.Forms.ToolStripMenuItem();
            this.btShowClient = new System.Windows.Forms.Button();
            this.statusStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbServerStatus)).BeginInit();
            this.cmsServer.SuspendLayout();
            this.SuspendLayout();
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1});
            this.statusStrip1.Location = new System.Drawing.Point(0, 233);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(284, 22);
            this.statusStrip1.TabIndex = 0;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(131, 17);
            this.toolStripStatusLabel1.Text = "toolStripStatusLabel1";
            // 
            // cbIPAdress
            // 
            this.cbIPAdress.FormattingEnabled = true;
            this.cbIPAdress.Location = new System.Drawing.Point(82, 13);
            this.cbIPAdress.Name = "cbIPAdress";
            this.cbIPAdress.Size = new System.Drawing.Size(151, 20);
            this.cbIPAdress.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(24, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 12);
            this.label1.TabIndex = 2;
            this.label1.Text = "服务器 ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(24, 50);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 12);
            this.label2.TabIndex = 3;
            this.label2.Text = "服  务";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(82, 47);
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(151, 21);
            this.textBox1.TabIndex = 4;
            this.textBox1.Text = "服务端";
            // 
            // pbServerStatus
            // 
            this.pbServerStatus.Location = new System.Drawing.Point(26, 95);
            this.pbServerStatus.Name = "pbServerStatus";
            this.pbServerStatus.Size = new System.Drawing.Size(77, 85);
            this.pbServerStatus.TabIndex = 5;
            this.pbServerStatus.TabStop = false;
            // 
            // btStartSverver
            // 
            this.btStartSverver.Location = new System.Drawing.Point(158, 83);
            this.btStartSverver.Name = "btStartSverver";
            this.btStartSverver.Size = new System.Drawing.Size(75, 23);
            this.btStartSverver.TabIndex = 6;
            this.btStartSverver.Text = "▶开启服务";
            this.btStartSverver.UseVisualStyleBackColor = true;
            this.btStartSverver.Click += new System.EventHandler(this.btStartSverver_Click);
            // 
            // btStopSverver
            // 
            this.btStopSverver.Enabled = false;
            this.btStopSverver.Location = new System.Drawing.Point(158, 112);
            this.btStopSverver.Name = "btStopSverver";
            this.btStopSverver.Size = new System.Drawing.Size(75, 23);
            this.btStopSverver.TabIndex = 7;
            this.btStopSverver.Text = "■停止服务";
            this.btStopSverver.UseVisualStyleBackColor = true;
            this.btStopSverver.Click += new System.EventHandler(this.btStopSverver_Click);
            // 
            // btConfigSverver
            // 
            this.btConfigSverver.Location = new System.Drawing.Point(158, 168);
            this.btConfigSverver.Name = "btConfigSverver";
            this.btConfigSverver.Size = new System.Drawing.Size(75, 23);
            this.btConfigSverver.TabIndex = 8;
            this.btConfigSverver.Text = "服务器配置";
            this.btConfigSverver.UseVisualStyleBackColor = true;
            // 
            // btClose
            // 
            this.btClose.Location = new System.Drawing.Point(158, 197);
            this.btClose.Name = "btClose";
            this.btClose.Size = new System.Drawing.Size(75, 23);
            this.btClose.TabIndex = 9;
            this.btClose.Text = "关闭服务器";
            this.btClose.UseVisualStyleBackColor = true;
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.BalloonTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.notifyIcon1.BalloonTipTitle = "服务器";
            this.notifyIcon1.ContextMenuStrip = this.cmsServer;
            this.notifyIcon1.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon1.Icon")));
            this.notifyIcon1.Text = "服务器";
            this.notifyIcon1.Visible = true;
            this.notifyIcon1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.notifyIcon1_MouseDoubleClick);
            this.notifyIcon1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.notifyIcon1_MouseMove);
            // 
            // cmsServer
            // 
            this.cmsServer.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiStartServer,
            this.tsmiStopServer,
            this.tsmiExit});
            this.cmsServer.Name = "cmsServer";
            this.cmsServer.Size = new System.Drawing.Size(153, 92);
            // 
            // tsmiStartServer
            // 
            this.tsmiStartServer.Name = "tsmiStartServer";
            this.tsmiStartServer.Size = new System.Drawing.Size(152, 22);
            this.tsmiStartServer.Text = "▶开启服务";
            this.tsmiStartServer.Click += new System.EventHandler(this.tsmiStartServer_Click);
            // 
            // tsmiStopServer
            // 
            this.tsmiStopServer.Name = "tsmiStopServer";
            this.tsmiStopServer.Size = new System.Drawing.Size(152, 22);
            this.tsmiStopServer.Text = "■停止服务";
            this.tsmiStopServer.Click += new System.EventHandler(this.tsmiStopServer_Click);
            // 
            // tsmiExit
            // 
            this.tsmiExit.Name = "tsmiExit";
            this.tsmiExit.Size = new System.Drawing.Size(152, 22);
            this.tsmiExit.Text = "退出";
            this.tsmiExit.Click += new System.EventHandler(this.tsmiExit_Click);
            // 
            // btShowClient
            // 
            this.btShowClient.Enabled = false;
            this.btShowClient.Location = new System.Drawing.Point(158, 142);
            this.btShowClient.Name = "btShowClient";
            this.btShowClient.Size = new System.Drawing.Size(75, 23);
            this.btShowClient.TabIndex = 10;
            this.btShowClient.Text = "查看客户端";
            this.btShowClient.UseVisualStyleBackColor = true;
            this.btShowClient.Click += new System.EventHandler(this.btShowClient_Click);
            // 
            // MainServer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 255);
            this.Controls.Add(this.btShowClient);
            this.Controls.Add(this.btClose);
            this.Controls.Add(this.btConfigSverver);
            this.Controls.Add(this.btStopSverver);
            this.Controls.Add(this.btStartSverver);
            this.Controls.Add(this.pbServerStatus);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cbIPAdress);
            this.Controls.Add(this.statusStrip1);
            this.MaximizeBox = false;
            this.Name = "MainServer";
            this.Text = "Server";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbServerStatus)).EndInit();
            this.cmsServer.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

            }


            #endregion

            private System.Windows.Forms.StatusStrip statusStrip1;
            private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
            private System.Windows.Forms.ComboBox cbIPAdress;
            private System.Windows.Forms.Label label1;
            private System.Windows.Forms.Label label2;
            private System.Windows.Forms.TextBox textBox1;
            private System.Windows.Forms.PictureBox pbServerStatus;
            private System.Windows.Forms.Button btStartSverver;
            private System.Windows.Forms.Button btStopSverver;
            private System.Windows.Forms.Button btConfigSverver;
            private System.Windows.Forms.Button btClose;
            private System.Windows.Forms.NotifyIcon notifyIcon1;
            private System.Windows.Forms.ContextMenuStrip cmsServer;
            private System.Windows.Forms.ToolStripMenuItem tsmiStartServer;
            private System.Windows.Forms.ToolStripMenuItem tsmiStopServer;
            private System.Windows.Forms.ToolStripMenuItem tsmiExit;
            private System.Windows.Forms.Button btShowClient;

        }
    }


