﻿
namespace RPG
{
    partial class GameForm
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
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.Craft = new System.Windows.Forms.Button();
            this.EquipArmor = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.AddDefense = new System.Windows.Forms.Button();
            this.Defense = new System.Windows.Forms.Label();
            this.AddDamage = new System.Windows.Forms.Button();
            this.Damage = new System.Windows.Forms.Label();
            this.AddHealth = new System.Windows.Forms.Button();
            this.Equip = new System.Windows.Forms.Button();
            this.use = new System.Windows.Forms.Button();
            this.ItemDescription = new System.Windows.Forms.RichTextBox();
            this.Inv = new System.Windows.Forms.Label();
            this.InventoryList = new System.Windows.Forms.ListBox();
            this.EXP = new System.Windows.Forms.Label();
            this.level = new System.Windows.Forms.Label();
            this.Health = new System.Windows.Forms.Label();
            this.Battle = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.WeaponText = new System.Windows.Forms.Label();
            this.ArmorText = new System.Windows.Forms.Label();
            this.Disequip = new System.Windows.Forms.Button();
            this.AccessoryText = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.RecipeList = new System.Windows.Forms.ListBox();
            this.button4 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 40;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(10, 11);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(527, 304);
            this.richTextBox1.TabIndex = 0;
            this.richTextBox1.Text = "";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(6, 130);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(78, 37);
            this.button1.TabIndex = 2;
            this.button1.Text = "测试";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.Craft);
            this.groupBox1.Controls.Add(this.EquipArmor);
            this.groupBox1.Controls.Add(this.button6);
            this.groupBox1.Controls.Add(this.AddDefense);
            this.groupBox1.Controls.Add(this.Defense);
            this.groupBox1.Controls.Add(this.AddDamage);
            this.groupBox1.Controls.Add(this.Damage);
            this.groupBox1.Controls.Add(this.AddHealth);
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.Equip);
            this.groupBox1.Controls.Add(this.use);
            this.groupBox1.Controls.Add(this.ItemDescription);
            this.groupBox1.Controls.Add(this.Inv);
            this.groupBox1.Controls.Add(this.InventoryList);
            this.groupBox1.Controls.Add(this.EXP);
            this.groupBox1.Controls.Add(this.level);
            this.groupBox1.Controls.Add(this.Health);
            this.groupBox1.Location = new System.Drawing.Point(543, 13);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(250, 425);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "人物属性";
            // 
            // Craft
            // 
            this.Craft.Location = new System.Drawing.Point(6, 331);
            this.Craft.Name = "Craft";
            this.Craft.Size = new System.Drawing.Size(107, 34);
            this.Craft.TabIndex = 16;
            this.Craft.Text = "合成";
            this.Craft.UseVisualStyleBackColor = true;
            this.Craft.Click += new System.EventHandler(this.Craft_Click);
            // 
            // EquipArmor
            // 
            this.EquipArmor.Location = new System.Drawing.Point(6, 211);
            this.EquipArmor.Name = "EquipArmor";
            this.EquipArmor.Size = new System.Drawing.Size(107, 34);
            this.EquipArmor.TabIndex = 15;
            this.EquipArmor.Text = "装备为护甲";
            this.EquipArmor.UseVisualStyleBackColor = true;
            this.EquipArmor.Click += new System.EventHandler(this.EquipArmor_Click);
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(6, 251);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(107, 34);
            this.button6.TabIndex = 14;
            this.button6.Text = "装备为饰品";
            this.button6.UseVisualStyleBackColor = true;
            // 
            // AddDefense
            // 
            this.AddDefense.Location = new System.Drawing.Point(6, 101);
            this.AddDefense.Name = "AddDefense";
            this.AddDefense.Size = new System.Drawing.Size(23, 23);
            this.AddDefense.TabIndex = 13;
            this.AddDefense.Text = "+";
            this.AddDefense.UseVisualStyleBackColor = true;
            this.AddDefense.Click += new System.EventHandler(this.AddDefense_Click);
            // 
            // Defense
            // 
            this.Defense.AutoSize = true;
            this.Defense.Location = new System.Drawing.Point(30, 105);
            this.Defense.Name = "Defense";
            this.Defense.Size = new System.Drawing.Size(37, 15);
            this.Defense.TabIndex = 12;
            this.Defense.Text = "防御";
            // 
            // AddDamage
            // 
            this.AddDamage.Location = new System.Drawing.Point(6, 76);
            this.AddDamage.Name = "AddDamage";
            this.AddDamage.Size = new System.Drawing.Size(23, 23);
            this.AddDamage.TabIndex = 11;
            this.AddDamage.Text = "+";
            this.AddDamage.UseVisualStyleBackColor = true;
            this.AddDamage.Click += new System.EventHandler(this.AddDamage_Click);
            // 
            // Damage
            // 
            this.Damage.AutoSize = true;
            this.Damage.Location = new System.Drawing.Point(30, 80);
            this.Damage.Name = "Damage";
            this.Damage.Size = new System.Drawing.Size(37, 15);
            this.Damage.TabIndex = 10;
            this.Damage.Text = "攻击";
            // 
            // AddHealth
            // 
            this.AddHealth.Location = new System.Drawing.Point(6, 52);
            this.AddHealth.Name = "AddHealth";
            this.AddHealth.Size = new System.Drawing.Size(23, 23);
            this.AddHealth.TabIndex = 9;
            this.AddHealth.Text = "+";
            this.AddHealth.UseVisualStyleBackColor = true;
            this.AddHealth.Click += new System.EventHandler(this.AddHealth_Click);
            // 
            // Equip
            // 
            this.Equip.Location = new System.Drawing.Point(6, 170);
            this.Equip.Name = "Equip";
            this.Equip.Size = new System.Drawing.Size(107, 35);
            this.Equip.TabIndex = 8;
            this.Equip.Text = "装备为武器";
            this.Equip.UseVisualStyleBackColor = true;
            this.Equip.Click += new System.EventHandler(this.Equip_Click);
            // 
            // use
            // 
            this.use.Location = new System.Drawing.Point(6, 291);
            this.use.Name = "use";
            this.use.Size = new System.Drawing.Size(107, 34);
            this.use.TabIndex = 7;
            this.use.Text = "使用";
            this.use.UseVisualStyleBackColor = true;
            this.use.Click += new System.EventHandler(this.use_Click);
            // 
            // ItemDescription
            // 
            this.ItemDescription.BackColor = System.Drawing.Color.White;
            this.ItemDescription.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ItemDescription.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.ItemDescription.Location = new System.Drawing.Point(6, 368);
            this.ItemDescription.Name = "ItemDescription";
            this.ItemDescription.ReadOnly = true;
            this.ItemDescription.Size = new System.Drawing.Size(238, 47);
            this.ItemDescription.TabIndex = 6;
            this.ItemDescription.Text = "";
            // 
            // Inv
            // 
            this.Inv.AutoSize = true;
            this.Inv.Location = new System.Drawing.Point(165, 145);
            this.Inv.Name = "Inv";
            this.Inv.Size = new System.Drawing.Size(37, 15);
            this.Inv.TabIndex = 5;
            this.Inv.Text = "背包";
            // 
            // InventoryList
            // 
            this.InventoryList.FormattingEnabled = true;
            this.InventoryList.ItemHeight = 15;
            this.InventoryList.Location = new System.Drawing.Point(119, 163);
            this.InventoryList.Name = "InventoryList";
            this.InventoryList.Size = new System.Drawing.Size(126, 199);
            this.InventoryList.TabIndex = 4;
            this.InventoryList.SelectedIndexChanged += new System.EventHandler(this.InventoryList_SelectedIndexChanged);
            // 
            // EXP
            // 
            this.EXP.AutoSize = true;
            this.EXP.Location = new System.Drawing.Point(111, 31);
            this.EXP.Name = "EXP";
            this.EXP.Size = new System.Drawing.Size(37, 15);
            this.EXP.TabIndex = 2;
            this.EXP.Text = "经验";
            // 
            // level
            // 
            this.level.AutoSize = true;
            this.level.Location = new System.Drawing.Point(30, 31);
            this.level.Name = "level";
            this.level.Size = new System.Drawing.Size(37, 15);
            this.level.TabIndex = 1;
            this.level.Text = "等级";
            // 
            // Health
            // 
            this.Health.AutoSize = true;
            this.Health.Location = new System.Drawing.Point(30, 56);
            this.Health.Name = "Health";
            this.Health.Size = new System.Drawing.Size(37, 15);
            this.Health.TabIndex = 0;
            this.Health.Text = "血量";
            // 
            // Battle
            // 
            this.Battle.Location = new System.Drawing.Point(12, 321);
            this.Battle.Name = "Battle";
            this.Battle.Size = new System.Drawing.Size(96, 32);
            this.Battle.TabIndex = 3;
            this.Battle.Text = "开始战斗";
            this.Battle.UseVisualStyleBackColor = true;
            this.Battle.Click += new System.EventHandler(this.Battle_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(12, 359);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(96, 32);
            this.button2.TabIndex = 4;
            this.button2.Text = "攻击";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.Attack_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(12, 396);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(96, 32);
            this.button3.TabIndex = 5;
            this.button3.Text = "靠近";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // WeaponText
            // 
            this.WeaponText.AutoSize = true;
            this.WeaponText.Location = new System.Drawing.Point(144, 330);
            this.WeaponText.Name = "WeaponText";
            this.WeaponText.Size = new System.Drawing.Size(37, 15);
            this.WeaponText.TabIndex = 13;
            this.WeaponText.Text = "武器";
            this.WeaponText.Click += new System.EventHandler(this.WeaponText_Click);
            // 
            // ArmorText
            // 
            this.ArmorText.AutoSize = true;
            this.ArmorText.Location = new System.Drawing.Point(144, 368);
            this.ArmorText.Name = "ArmorText";
            this.ArmorText.Size = new System.Drawing.Size(37, 15);
            this.ArmorText.TabIndex = 14;
            this.ArmorText.Text = "护甲";
            // 
            // Disequip
            // 
            this.Disequip.Location = new System.Drawing.Point(289, 321);
            this.Disequip.Name = "Disequip";
            this.Disequip.Size = new System.Drawing.Size(56, 32);
            this.Disequip.TabIndex = 15;
            this.Disequip.Text = "卸下";
            this.Disequip.UseVisualStyleBackColor = true;
            this.Disequip.Click += new System.EventHandler(this.Disequip_Click);
            // 
            // AccessoryText
            // 
            this.AccessoryText.AutoSize = true;
            this.AccessoryText.Location = new System.Drawing.Point(144, 405);
            this.AccessoryText.Name = "AccessoryText";
            this.AccessoryText.Size = new System.Drawing.Size(37, 15);
            this.AccessoryText.TabIndex = 16;
            this.AccessoryText.Text = "饰品";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.RecipeList);
            this.groupBox2.Location = new System.Drawing.Point(353, 320);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(183, 117);
            this.groupBox2.TabIndex = 18;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "可合成物品";
            // 
            // RecipeList
            // 
            this.RecipeList.FormattingEnabled = true;
            this.RecipeList.ItemHeight = 15;
            this.RecipeList.Location = new System.Drawing.Point(6, 19);
            this.RecipeList.Name = "RecipeList";
            this.RecipeList.Size = new System.Drawing.Size(171, 94);
            this.RecipeList.TabIndex = 18;
            this.RecipeList.SelectedIndexChanged += new System.EventHandler(this.RecipeList_SelectedIndexChanged);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(289, 359);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(56, 32);
            this.button4.TabIndex = 19;
            this.button4.Text = "卸下";
            this.button4.UseVisualStyleBackColor = true;
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(289, 397);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(56, 32);
            this.button5.TabIndex = 20;
            this.button5.Text = "卸下";
            this.button5.UseVisualStyleBackColor = true;
            // 
            // GameForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(796, 450);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.AccessoryText);
            this.Controls.Add(this.Disequip);
            this.Controls.Add(this.ArmorText);
            this.Controls.Add(this.WeaponText);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.Battle);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.groupBox2);
            this.Name = "GameForm";
            this.Text = "GameForm";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label Health;
        private System.Windows.Forms.Label level;
        private System.Windows.Forms.Label EXP;
        private System.Windows.Forms.ListBox InventoryList;
        private System.Windows.Forms.Button Battle;
        private System.Windows.Forms.Label Inv;
        private System.Windows.Forms.RichTextBox ItemDescription;
        private System.Windows.Forms.Button Equip;
        private System.Windows.Forms.Button use;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button AddHealth;
        private System.Windows.Forms.Label WeaponText;
        private System.Windows.Forms.Label ArmorText;
        private System.Windows.Forms.Button Disequip;
        private System.Windows.Forms.Label AccessoryText;
        private System.Windows.Forms.Button AddDefense;
        private System.Windows.Forms.Label Defense;
        private System.Windows.Forms.Button AddDamage;
        private System.Windows.Forms.Label Damage;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ListBox RecipeList;
        private System.Windows.Forms.Button Craft;
        private System.Windows.Forms.Button EquipArmor;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button5;
    }
}

