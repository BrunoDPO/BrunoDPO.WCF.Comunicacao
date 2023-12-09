namespace BrunoDPO.WCF.Cliente
{
    partial class FormPrincipal
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.mainMenuStrip = new System.Windows.Forms.MenuStrip();
            this.arquivoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sairToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.txtDestino = new System.Windows.Forms.TextBox();
            this.lblDestino = new System.Windows.Forms.Label();
            this.txtOrigem = new System.Windows.Forms.TextBox();
            this.lblOrigem = new System.Windows.Forms.Label();
            this.txtFilaEnvio = new System.Windows.Forms.TextBox();
            this.lblFila = new System.Windows.Forms.Label();
            this.txtMensagemEnvio = new System.Windows.Forms.TextBox();
            this.lblMensagemEnvio = new System.Windows.Forms.Label();
            this.gbxEnvioMensagens = new System.Windows.Forms.GroupBox();
            this.btnEnviar = new System.Windows.Forms.Button();
            this.btnPing = new System.Windows.Forms.Button();
            this.gbxRecebimentoMensagens = new System.Windows.Forms.GroupBox();
            this.txtMensagemRecebimento = new System.Windows.Forms.TextBox();
            this.btnConectarCliente = new System.Windows.Forms.Button();
            this.lblMensagemRecebimento = new System.Windows.Forms.Label();
            this.txtFilaRecebimento = new System.Windows.Forms.TextBox();
            this.txtSistema = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lblSistema = new System.Windows.Forms.Label();
            this.mainMenuStrip.SuspendLayout();
            this.gbxEnvioMensagens.SuspendLayout();
            this.gbxRecebimentoMensagens.SuspendLayout();
            this.SuspendLayout();
            // 
            // mainMenuStrip
            // 
            this.mainMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.arquivoToolStripMenuItem});
            this.mainMenuStrip.Location = new System.Drawing.Point(0, 0);
            this.mainMenuStrip.Name = "mainMenuStrip";
            this.mainMenuStrip.Size = new System.Drawing.Size(472, 24);
            this.mainMenuStrip.TabIndex = 0;
            this.mainMenuStrip.Text = "menuStrip1";
            // 
            // arquivoToolStripMenuItem
            // 
            this.arquivoToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.sairToolStripMenuItem});
            this.arquivoToolStripMenuItem.Name = "arquivoToolStripMenuItem";
            this.arquivoToolStripMenuItem.Size = new System.Drawing.Size(61, 20);
            this.arquivoToolStripMenuItem.Text = "&Arquivo";
            // 
            // sairToolStripMenuItem
            // 
            this.sairToolStripMenuItem.Name = "sairToolStripMenuItem";
            this.sairToolStripMenuItem.Size = new System.Drawing.Size(93, 22);
            this.sairToolStripMenuItem.Text = "Sai&r";
            this.sairToolStripMenuItem.Click += new System.EventHandler(this.sairToolStripMenuItem_Click);
            // 
            // txtDestino
            // 
            this.txtDestino.Location = new System.Drawing.Point(207, 19);
            this.txtDestino.Name = "txtDestino";
            this.txtDestino.Size = new System.Drawing.Size(100, 20);
            this.txtDestino.TabIndex = 7;
            this.txtDestino.Text = "A1";
            // 
            // lblDestino
            // 
            this.lblDestino.AutoSize = true;
            this.lblDestino.Location = new System.Drawing.Point(158, 22);
            this.lblDestino.Name = "lblDestino";
            this.lblDestino.Size = new System.Drawing.Size(43, 13);
            this.lblDestino.TabIndex = 6;
            this.lblDestino.Text = "Destino";
            // 
            // txtOrigem
            // 
            this.txtOrigem.Location = new System.Drawing.Point(52, 19);
            this.txtOrigem.Name = "txtOrigem";
            this.txtOrigem.Size = new System.Drawing.Size(100, 20);
            this.txtOrigem.TabIndex = 5;
            this.txtOrigem.Text = "A1";
            // 
            // lblOrigem
            // 
            this.lblOrigem.AutoSize = true;
            this.lblOrigem.Location = new System.Drawing.Point(6, 22);
            this.lblOrigem.Name = "lblOrigem";
            this.lblOrigem.Size = new System.Drawing.Size(40, 13);
            this.lblOrigem.TabIndex = 4;
            this.lblOrigem.Text = "Origem";
            // 
            // txtFilaEnvio
            // 
            this.txtFilaEnvio.Location = new System.Drawing.Point(342, 19);
            this.txtFilaEnvio.Name = "txtFilaEnvio";
            this.txtFilaEnvio.Size = new System.Drawing.Size(100, 20);
            this.txtFilaEnvio.TabIndex = 9;
            this.txtFilaEnvio.Text = "ECHO";
            // 
            // lblFila
            // 
            this.lblFila.AutoSize = true;
            this.lblFila.Location = new System.Drawing.Point(313, 22);
            this.lblFila.Name = "lblFila";
            this.lblFila.Size = new System.Drawing.Size(23, 13);
            this.lblFila.TabIndex = 8;
            this.lblFila.Text = "Fila";
            // 
            // txtMensagemEnvio
            // 
            this.txtMensagemEnvio.Location = new System.Drawing.Point(9, 58);
            this.txtMensagemEnvio.Multiline = true;
            this.txtMensagemEnvio.Name = "txtMensagemEnvio";
            this.txtMensagemEnvio.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtMensagemEnvio.Size = new System.Drawing.Size(433, 100);
            this.txtMensagemEnvio.TabIndex = 11;
            this.txtMensagemEnvio.Text = "Eco";
            // 
            // lblMensagemEnvio
            // 
            this.lblMensagemEnvio.AutoSize = true;
            this.lblMensagemEnvio.Location = new System.Drawing.Point(6, 42);
            this.lblMensagemEnvio.Name = "lblMensagemEnvio";
            this.lblMensagemEnvio.Size = new System.Drawing.Size(59, 13);
            this.lblMensagemEnvio.TabIndex = 10;
            this.lblMensagemEnvio.Text = "Mensagem";
            // 
            // gbxEnvioMensagens
            // 
            this.gbxEnvioMensagens.Controls.Add(this.btnEnviar);
            this.gbxEnvioMensagens.Controls.Add(this.btnPing);
            this.gbxEnvioMensagens.Controls.Add(this.txtOrigem);
            this.gbxEnvioMensagens.Controls.Add(this.lblOrigem);
            this.gbxEnvioMensagens.Controls.Add(this.txtMensagemEnvio);
            this.gbxEnvioMensagens.Controls.Add(this.lblDestino);
            this.gbxEnvioMensagens.Controls.Add(this.lblMensagemEnvio);
            this.gbxEnvioMensagens.Controls.Add(this.txtDestino);
            this.gbxEnvioMensagens.Controls.Add(this.txtFilaEnvio);
            this.gbxEnvioMensagens.Controls.Add(this.lblFila);
            this.gbxEnvioMensagens.Location = new System.Drawing.Point(12, 27);
            this.gbxEnvioMensagens.Name = "gbxEnvioMensagens";
            this.gbxEnvioMensagens.Size = new System.Drawing.Size(450, 195);
            this.gbxEnvioMensagens.TabIndex = 12;
            this.gbxEnvioMensagens.TabStop = false;
            this.gbxEnvioMensagens.Text = "Envio de mensagens";
            // 
            // btnEnviar
            // 
            this.btnEnviar.Location = new System.Drawing.Point(367, 164);
            this.btnEnviar.Name = "btnEnviar";
            this.btnEnviar.Size = new System.Drawing.Size(75, 23);
            this.btnEnviar.TabIndex = 13;
            this.btnEnviar.Text = "Enviar";
            this.btnEnviar.UseVisualStyleBackColor = true;
            this.btnEnviar.Click += new System.EventHandler(this.btnEnviar_Click);
            // 
            // btnPing
            // 
            this.btnPing.Location = new System.Drawing.Point(9, 164);
            this.btnPing.Name = "btnPing";
            this.btnPing.Size = new System.Drawing.Size(75, 23);
            this.btnPing.TabIndex = 12;
            this.btnPing.Text = "Ping";
            this.btnPing.UseVisualStyleBackColor = true;
            this.btnPing.Click += new System.EventHandler(this.btnPing_Click);
            // 
            // gbxRecebimentoMensagens
            // 
            this.gbxRecebimentoMensagens.Controls.Add(this.txtMensagemRecebimento);
            this.gbxRecebimentoMensagens.Controls.Add(this.btnConectarCliente);
            this.gbxRecebimentoMensagens.Controls.Add(this.lblMensagemRecebimento);
            this.gbxRecebimentoMensagens.Controls.Add(this.txtFilaRecebimento);
            this.gbxRecebimentoMensagens.Controls.Add(this.txtSistema);
            this.gbxRecebimentoMensagens.Controls.Add(this.label1);
            this.gbxRecebimentoMensagens.Controls.Add(this.lblSistema);
            this.gbxRecebimentoMensagens.Location = new System.Drawing.Point(12, 228);
            this.gbxRecebimentoMensagens.Name = "gbxRecebimentoMensagens";
            this.gbxRecebimentoMensagens.Size = new System.Drawing.Size(450, 166);
            this.gbxRecebimentoMensagens.TabIndex = 13;
            this.gbxRecebimentoMensagens.TabStop = false;
            this.gbxRecebimentoMensagens.Text = "Recebimento de mensagens";
            // 
            // txtMensagemRecebimento
            // 
            this.txtMensagemRecebimento.Location = new System.Drawing.Point(9, 58);
            this.txtMensagemRecebimento.Multiline = true;
            this.txtMensagemRecebimento.Name = "txtMensagemRecebimento";
            this.txtMensagemRecebimento.ReadOnly = true;
            this.txtMensagemRecebimento.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtMensagemRecebimento.Size = new System.Drawing.Size(433, 100);
            this.txtMensagemRecebimento.TabIndex = 13;
            // 
            // btnConectarCliente
            // 
            this.btnConectarCliente.Location = new System.Drawing.Point(367, 17);
            this.btnConectarCliente.Name = "btnConectarCliente";
            this.btnConectarCliente.Size = new System.Drawing.Size(75, 23);
            this.btnConectarCliente.TabIndex = 14;
            this.btnConectarCliente.Text = "Conectar";
            this.btnConectarCliente.UseVisualStyleBackColor = true;
            this.btnConectarCliente.Click += new System.EventHandler(this.btnConectarCliente_Click);
            // 
            // lblMensagemRecebimento
            // 
            this.lblMensagemRecebimento.AutoSize = true;
            this.lblMensagemRecebimento.Location = new System.Drawing.Point(6, 42);
            this.lblMensagemRecebimento.Name = "lblMensagemRecebimento";
            this.lblMensagemRecebimento.Size = new System.Drawing.Size(59, 13);
            this.lblMensagemRecebimento.TabIndex = 12;
            this.lblMensagemRecebimento.Text = "Mensagem";
            // 
            // txtFilaRecebimento
            // 
            this.txtFilaRecebimento.Location = new System.Drawing.Point(187, 19);
            this.txtFilaRecebimento.Name = "txtFilaRecebimento";
            this.txtFilaRecebimento.Size = new System.Drawing.Size(100, 20);
            this.txtFilaRecebimento.TabIndex = 13;
            this.txtFilaRecebimento.Text = "ECHO";
            // 
            // txtSistema
            // 
            this.txtSistema.Location = new System.Drawing.Point(52, 19);
            this.txtSistema.Name = "txtSistema";
            this.txtSistema.Size = new System.Drawing.Size(100, 20);
            this.txtSistema.TabIndex = 7;
            this.txtSistema.Text = "A1";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(158, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(23, 13);
            this.label1.TabIndex = 12;
            this.label1.Text = "Fila";
            // 
            // lblSistema
            // 
            this.lblSistema.AutoSize = true;
            this.lblSistema.Location = new System.Drawing.Point(6, 22);
            this.lblSistema.Name = "lblSistema";
            this.lblSistema.Size = new System.Drawing.Size(44, 13);
            this.lblSistema.TabIndex = 6;
            this.lblSistema.Text = "Sistema";
            // 
            // FormPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(472, 404);
            this.Controls.Add(this.gbxRecebimentoMensagens);
            this.Controls.Add(this.gbxEnvioMensagens);
            this.Controls.Add(this.mainMenuStrip);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MainMenuStrip = this.mainMenuStrip;
            this.MaximizeBox = false;
            this.Name = "FormPrincipal";
            this.Text = "Simulador do Cliente";
            this.mainMenuStrip.ResumeLayout(false);
            this.mainMenuStrip.PerformLayout();
            this.gbxEnvioMensagens.ResumeLayout(false);
            this.gbxEnvioMensagens.PerformLayout();
            this.gbxRecebimentoMensagens.ResumeLayout(false);
            this.gbxRecebimentoMensagens.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip mainMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem arquivoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sairToolStripMenuItem;
        private System.Windows.Forms.TextBox txtDestino;
        private System.Windows.Forms.Label lblDestino;
        private System.Windows.Forms.TextBox txtOrigem;
        private System.Windows.Forms.Label lblOrigem;
        private System.Windows.Forms.TextBox txtFilaEnvio;
        private System.Windows.Forms.Label lblFila;
        private System.Windows.Forms.TextBox txtMensagemEnvio;
        private System.Windows.Forms.Label lblMensagemEnvio;
        private System.Windows.Forms.GroupBox gbxEnvioMensagens;
        private System.Windows.Forms.GroupBox gbxRecebimentoMensagens;
        private System.Windows.Forms.TextBox txtFilaRecebimento;
        private System.Windows.Forms.TextBox txtSistema;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblSistema;
        private System.Windows.Forms.TextBox txtMensagemRecebimento;
        private System.Windows.Forms.Button btnConectarCliente;
        private System.Windows.Forms.Label lblMensagemRecebimento;
        private System.Windows.Forms.Button btnEnviar;
        private System.Windows.Forms.Button btnPing;
    }
}

