namespace ELMS.Forms
{
    partial class StatusTrackingDialog
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.lblHeader = new System.Windows.Forms.Label();
            this.pnlScroll = new System.Windows.Forms.Panel();
            this.lblSummary = new System.Windows.Forms.Label();
            this.grpQuota = new System.Windows.Forms.GroupBox();
            this.lblQuotaText = new System.Windows.Forms.Label();
            this.lblQuotaAlert = new System.Windows.Forms.Label();
            this.grpStepper = new System.Windows.Forms.GroupBox();
            this.lblStep1 = new System.Windows.Forms.Label();
            this.lblStep2 = new System.Windows.Forms.Label();
            this.grpAction = new System.Windows.Forms.GroupBox();
            this.txtReviewComments = new System.Windows.Forms.TextBox();
            this.btnApprove = new System.Windows.Forms.Button();
            this.btnReject = new System.Windows.Forms.Button();
            this.grpClearance = new System.Windows.Forms.GroupBox();
            this.pnlClearanceItems = new System.Windows.Forms.FlowLayoutPanel();
            this.btnClose = new System.Windows.Forms.Button();
            this.pnlScroll.SuspendLayout();
            this.grpQuota.SuspendLayout();
            this.grpStepper.SuspendLayout();
            this.grpAction.SuspendLayout();
            this.grpClearance.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblHeader
            // 
            this.lblHeader.BackColor = System.Drawing.Color.FromArgb(248, 250, 252);
            this.lblHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblHeader.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblHeader.ForeColor = System.Drawing.Color.FromArgb(15, 23, 42);
            this.lblHeader.Location = new System.Drawing.Point(0, 0);
            this.lblHeader.Name = "lblHeader";
            this.lblHeader.Padding = new System.Windows.Forms.Padding(16, 0, 0, 0);
            this.lblHeader.Size = new System.Drawing.Size(520, 50);
            this.lblHeader.TabIndex = 0;
            this.lblHeader.Text = "Request Tracking & Approvals";
            this.lblHeader.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pnlScroll
            // 
            this.pnlScroll.AutoScroll = true;
            this.pnlScroll.Controls.Add(this.grpClearance);
            this.pnlScroll.Controls.Add(this.grpAction);
            this.pnlScroll.Controls.Add(this.grpStepper);
            this.pnlScroll.Controls.Add(this.grpQuota);
            this.pnlScroll.Controls.Add(this.lblSummary);
            this.pnlScroll.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlScroll.Location = new System.Drawing.Point(0, 50);
            this.pnlScroll.Name = "pnlScroll";
            this.pnlScroll.Padding = new System.Windows.Forms.Padding(16);
            this.pnlScroll.Size = new System.Drawing.Size(520, 550);
            this.pnlScroll.TabIndex = 1;
            // 
            // lblSummary
            // 
            this.lblSummary.BackColor = System.Drawing.Color.FromArgb(248, 250, 252);
            this.lblSummary.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblSummary.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblSummary.Location = new System.Drawing.Point(16, 12);
            this.lblSummary.Name = "lblSummary";
            this.lblSummary.Padding = new System.Windows.Forms.Padding(10);
            this.lblSummary.Size = new System.Drawing.Size(465, 80);
            this.lblSummary.TabIndex = 0;
            this.lblSummary.Text = "Request info...";
            // 
            // grpQuota
            // 
            this.grpQuota.Controls.Add(this.lblQuotaAlert);
            this.grpQuota.Controls.Add(this.lblQuotaText);
            this.grpQuota.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.grpQuota.Location = new System.Drawing.Point(16, 102);
            this.grpQuota.Name = "grpQuota";
            this.grpQuota.Size = new System.Drawing.Size(465, 95);
            this.grpQuota.TabIndex = 1;
            this.grpQuota.TabStop = false;
            this.grpQuota.Text = "Quota Balance Summary (Fiscal Year)";
            // 
            // lblQuotaText
            // 
            this.lblQuotaText.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblQuotaText.Location = new System.Drawing.Point(12, 24);
            this.lblQuotaText.Name = "lblQuotaText";
            this.lblQuotaText.Size = new System.Drawing.Size(440, 38);
            this.lblQuotaText.TabIndex = 0;
            this.lblQuotaText.Text = "Allocated: 0 | Carried: 0 | Taken: 0 | Available: 0 | After Req: 0";
            // 
            // lblQuotaAlert
            // 
            this.lblQuotaAlert.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            this.lblQuotaAlert.ForeColor = System.Drawing.Color.FromArgb(220, 38, 38);
            this.lblQuotaAlert.Location = new System.Drawing.Point(12, 65);
            this.lblQuotaAlert.Name = "lblQuotaAlert";
            this.lblQuotaAlert.Size = new System.Drawing.Size(440, 22);
            this.lblQuotaAlert.TabIndex = 1;
            this.lblQuotaAlert.Text = "⚠️ Warning: Requested days exceed remaining quota balance!";
            this.lblQuotaAlert.Visible = false;
            // 
            // grpStepper
            // 
            this.grpStepper.Controls.Add(this.lblStep2);
            this.grpStepper.Controls.Add(this.lblStep1);
            this.grpStepper.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.grpStepper.Location = new System.Drawing.Point(16, 207);
            this.grpStepper.Name = "grpStepper";
            this.grpStepper.Size = new System.Drawing.Size(465, 140);
            this.grpStepper.TabIndex = 2;
            this.grpStepper.TabStop = false;
            this.grpStepper.Text = "Sequential Approval Workflow";
            // 
            // lblStep1
            // 
            this.lblStep1.BackColor = System.Drawing.Color.FromArgb(248, 250, 252);
            this.lblStep1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblStep1.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.lblStep1.Location = new System.Drawing.Point(12, 26);
            this.lblStep1.Name = "lblStep1";
            this.lblStep1.Padding = new System.Windows.Forms.Padding(8);
            this.lblStep1.Size = new System.Drawing.Size(440, 48);
            this.lblStep1.TabIndex = 0;
            this.lblStep1.Text = "Step 1: Department Head Review";
            // 
            // lblStep2
            // 
            this.lblStep2.BackColor = System.Drawing.Color.FromArgb(248, 250, 252);
            this.lblStep2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblStep2.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.lblStep2.Location = new System.Drawing.Point(12, 80);
            this.lblStep2.Name = "lblStep2";
            this.lblStep2.Padding = new System.Windows.Forms.Padding(8);
            this.lblStep2.Size = new System.Drawing.Size(440, 48);
            this.lblStep2.TabIndex = 1;
            this.lblStep2.Text = "Step 2: HR Director Authorization (Gated)";
            // 
            // grpAction
            // 
            this.grpAction.Controls.Add(this.btnReject);
            this.grpAction.Controls.Add(this.btnApprove);
            this.grpAction.Controls.Add(this.txtReviewComments);
            this.grpAction.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.grpAction.Location = new System.Drawing.Point(16, 355);
            this.grpAction.Name = "grpAction";
            this.grpAction.Size = new System.Drawing.Size(465, 115);
            this.grpAction.TabIndex = 3;
            this.grpAction.TabStop = false;
            this.grpAction.Text = "Reviewer Action Decision";
            // 
            // txtReviewComments
            // 
            this.txtReviewComments.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtReviewComments.Location = new System.Drawing.Point(12, 26);
            this.txtReviewComments.Multiline = true;
            this.txtReviewComments.Name = "txtReviewComments";
            this.txtReviewComments.PlaceholderText = "Enter reviewer remarks...";
            this.txtReviewComments.Size = new System.Drawing.Size(440, 42);
            this.txtReviewComments.TabIndex = 0;
            // 
            // btnApprove
            // 
            this.btnApprove.BackColor = System.Drawing.Color.FromArgb(22, 163, 74);
            this.btnApprove.FlatAppearance.BorderSize = 0;
            this.btnApprove.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnApprove.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnApprove.ForeColor = System.Drawing.Color.White;
            this.btnApprove.Location = new System.Drawing.Point(12, 74);
            this.btnApprove.Name = "btnApprove";
            this.btnApprove.Size = new System.Drawing.Size(140, 32);
            this.btnApprove.TabIndex = 1;
            this.btnApprove.Text = "✓ Approve Step";
            this.btnApprove.UseVisualStyleBackColor = false;
            this.btnApprove.Click += new System.EventHandler(this.btnApprove_Click);
            // 
            // btnReject
            // 
            this.btnReject.BackColor = System.Drawing.Color.FromArgb(220, 38, 38);
            this.btnReject.FlatAppearance.BorderSize = 0;
            this.btnReject.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReject.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnReject.ForeColor = System.Drawing.Color.White;
            this.btnReject.Location = new System.Drawing.Point(160, 74);
            this.btnReject.Name = "btnReject";
            this.btnReject.Size = new System.Drawing.Size(130, 32);
            this.btnReject.TabIndex = 2;
            this.btnReject.Text = "✗ Reject Step";
            this.btnReject.UseVisualStyleBackColor = false;
            this.btnReject.Click += new System.EventHandler(this.btnReject_Click);
            // 
            // grpClearance
            // 
            this.grpClearance.Controls.Add(this.pnlClearanceItems);
            this.grpClearance.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.grpClearance.Location = new System.Drawing.Point(16, 478);
            this.grpClearance.Name = "grpClearance";
            this.grpClearance.Size = new System.Drawing.Size(465, 120);
            this.grpClearance.TabIndex = 4;
            this.grpClearance.TabStop = false;
            this.grpClearance.Text = "Study Leave Clearance Checklist";
            // 
            // pnlClearanceItems
            // 
            this.pnlClearanceItems.AutoScroll = true;
            this.pnlClearanceItems.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlClearanceItems.Location = new System.Drawing.Point(3, 23);
            this.pnlClearanceItems.Name = "pnlClearanceItems";
            this.pnlClearanceItems.Size = new System.Drawing.Size(459, 94);
            this.pnlClearanceItems.TabIndex = 0;
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.FromArgb(241, 245, 249);
            this.btnClose.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.btnClose.Location = new System.Drawing.Point(0, 600);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(520, 38);
            this.btnClose.TabIndex = 2;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // StatusTrackingDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 23F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(520, 638);
            this.Controls.Add(this.pnlScroll);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.lblHeader);
            this.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "StatusTrackingDialog";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Leave Request Tracking";
            this.pnlScroll.ResumeLayout(false);
            this.grpQuota.ResumeLayout(false);
            this.grpStepper.ResumeLayout(false);
            this.grpAction.ResumeLayout(false);
            this.grpAction.PerformLayout();
            this.grpClearance.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblHeader;
        private System.Windows.Forms.Panel pnlScroll;
        private System.Windows.Forms.Label lblSummary;
        private System.Windows.Forms.GroupBox grpQuota;
        private System.Windows.Forms.Label lblQuotaText;
        private System.Windows.Forms.Label lblQuotaAlert;
        private System.Windows.Forms.GroupBox grpStepper;
        private System.Windows.Forms.Label lblStep1;
        private System.Windows.Forms.Label lblStep2;
        private System.Windows.Forms.GroupBox grpAction;
        private System.Windows.Forms.TextBox txtReviewComments;
        private System.Windows.Forms.Button btnApprove;
        private System.Windows.Forms.Button btnReject;
        private System.Windows.Forms.GroupBox grpClearance;
        private System.Windows.Forms.FlowLayoutPanel pnlClearanceItems;
        private System.Windows.Forms.Button btnClose;
    }
}
