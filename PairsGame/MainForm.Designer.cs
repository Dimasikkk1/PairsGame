﻿
namespace PairsGame
{
    partial class MainForm
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.mainTableControl = new PairsGame.Controls.TableControl();
            this.SuspendLayout();
            // 
            // mainTableControl
            // 
            this.mainTableControl.BackColor = System.Drawing.SystemColors.Control;
            this.mainTableControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainTableControl.Location = new System.Drawing.Point(0, 0);
            this.mainTableControl.Name = "mainTableControl";
            this.mainTableControl.ShowingDelay = 500;
            this.mainTableControl.Size = new System.Drawing.Size(1094, 570);
            this.mainTableControl.TabIndex = 0;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1094, 570);
            this.Controls.Add(this.mainTableControl);
            this.Name = "MainForm";
            this.Text = "PairsGame";
            this.ResumeLayout(false);

        }

        #endregion

        private Controls.TableControl mainTableControl;
    }
}

