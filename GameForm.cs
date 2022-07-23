using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RPG
{
    public partial class GameForm : Form
    {
        public GameForm()
        {
            InitializeComponent();
            Initialize();
        }
        public bool OutputOnScreen(string text)
        {
            richTextBox1.Text += text;
            richTextBox1.Text += "\n";
            richTextBox1.SelectionStart = richTextBox1.Text.Length;
            richTextBox1.SelectionLength = 0;
            richTextBox1.ScrollToCaret();
            return true;
        }
        public void Initialize()
        {
            this.DoubleBuffered = true;
            OutputOnScreen("A RPG Game");
            richTextBox1.ReadOnly = true;
            player = new Player(50, 4, 2);
            ModUI.gameForm = this;
        }
        public void UpdateGame()
        {
            UpdatePlayer();
        }
        public void UpdatePlayer()
        {
            UpdateLevel();
            player.damage = player.baseDamage + player.weapon.damage;
            player.defense = player.baseDefense + player.armor.defense;
            level.Text = "等级 : " + player.level;
            EXP.Text = "经验 : " + player.EXP + " / " + (player.level * (player.level + 2) * 10);
            Health.Text = "血量 : " + player.health + " / " + player.maxHealth;
            Damage.Text = "攻击 : " + player.damage;
            Defense.Text = "防御 : " + player.defense;
            WeaponText.Text = "武器 : " + player.weapon.name;
            ArmorText.Text = "护甲 : " + player.armor.name; 
        }
        public void UpdateLevel()
        {
            if(player.EXP >= (player.level * (player.level + 2) * 10))
            {
                player.EXP -= (player.level * (player.level + 2) * 10);
                player.level++;
                OutputOnScreen("你升级了!");
                Point++;
            }
            if(Point > 0)
            {
                AddHealth.Show();
                AddDamage.Show();
                AddDefense.Show();
            }
            else
            {
                AddHealth.Hide();
                AddDamage.Hide();
                AddDefense.Hide();
            }
        }
        public void UpdateRecipes()
        {
            RecipeList.Items.Clear();
            foreach(var i in ItemLoader.Recipes)
            {
                if (i.Available(player.Inventory))
                {
                    availableRecipes.Add(i);
                    RecipeList.Items.Add(i.Result.Item1.name + " * " + i.Result.Item2);
                }
            }
        }
        public void UpdateInventory()
        {
            InventoryList.Items.Clear();
            foreach(var i in player.Inventory)
            {
                InventoryList.Items.Add(i.Item1.name + " * " + i.Item2);
            }
        }
        public void RemoveFromInventory(Item item, int stack)
        {
            int n = player.Inventory.FindIndex(c => c.Item1.name == item.name);
            if (n != -1)
            {
                var i = player.Inventory[n];
                i.Item2 -= stack;
                player.Inventory.RemoveAt(n);
                player.Inventory.Insert(n, i);
                UpdateInventory();
                return;
            }
        }
        public void AddItemToInventory(Item item, int stack)
        {
            int n = player.Inventory.FindIndex(c => c.Item1.name == item.name);
            if(n != -1)
            {
                var i = player.Inventory[n];
                i.Item2 += stack;
                player.Inventory.RemoveAt(n);
                player.Inventory.Insert(n, i);
                UpdateInventory();
                return;
            }
            player.Inventory.Add((item, stack));
            UpdateInventory();
            UpdateRecipes();
        }
        public void LootItem(Item item, int stack, string NPCName)
        {
            AddItemToInventory(item, stack);
            OutputOnScreen(NPCName + "掉落了" + item.name + " * " + stack);
            UpdateRecipes();
        }
        public void LootItem(int ItemType, int stack, string NPCName)
        {
            Item item = ItemLoader.ItemList[ItemType];
            AddItemToInventory(item, stack);
            OutputOnScreen(NPCName + "掉落了" + item.name + " * " + stack);
            UpdateRecipes();
        }
        public void SpawnEnemy(string name, int level, int damage, int health, int defense)
        {
            if (!IsBattle)
            {
                //OutputOnScreen("一个" + name + "向你冲过来，等级为" + level + "级");
                enemy = NPCLoader.NPCList[1].Clone();//new NPC(name, level, damage, health, defense);
                OutputOnScreen("一个" + enemy.name + "向你冲过来，等级为" + enemy.level + "级");
                IsBattle = true;
            }
            else OutputOnScreen("你现在这个都没解决你还想打新的？");
        }
        public void SpawnEnemy(int Type)
        {
            if (!IsBattle)
            {
                enemy = NPCLoader.NPCList[Type].Clone();
                OutputOnScreen("一个" + enemy.name + "向你冲过来，等级为" + enemy.level + "级");
                IsBattle = true;
            }
            else OutputOnScreen("你现在这个都没解决你还想打新的？");
        }
        public void SpawnEnemy()
        {
            if (!IsBattle)
            {
                enemy = NPCLoader.NPCList[rand.Next(1, NPCLoader.NPCList.Count + 1)].Clone();
                OutputOnScreen("一个" + enemy.name + "向你冲过来，等级为" + enemy.level + "级");
                IsBattle = true;
            }
            else OutputOnScreen("你现在这个都没解决你还想打新的？");
        }
        public void timer1_Tick(object sender, EventArgs e)
        {
            UpdateGame();
        }

        public void button1_Click(object sender, EventArgs e)
        {
            OutputOnScreen("Upgrade");
            //player.EXP += (player.level * (player.level + 2) * 10);
            AddItemToInventory(ItemLoader.ItemList[5], 1);
        }
        public Player player = new Player();

        public void InventoryList_SelectedIndexChanged(object sender, EventArgs e)
        {
            RecipeList.SelectedIndex = -1;
            if(InventoryList.SelectedIndex != -1) ItemDescription.Text = player.Inventory[InventoryList.SelectedIndex].Item1.description;
        }

        public void Battle_Click(object sender, EventArgs e)
        {
            SpawnEnemy();
        }
        public void Attack_Click(object sender, EventArgs e)
        {
            if (!IsBattle)
            {

                OutputOnScreen("你丫打谁呢");
            }
            else
            {
                if (rand.Next(100) <= player.crit)
                {
                    enemy.health -= (int)(2 * (player.damage - enemy.defense * 0.5));
                    if (enemy.health < 0) enemy.health = 0;
                    OutputOnScreen("你攻击了" + enemy.name + ",你成功暴击了," + enemy.name + "损失了 " + (int)(2 * (player.damage - enemy.defense * 0.5)) + " 点血量");
                }
                else
                {
                    enemy.health -= (int)((player.damage - enemy.defense * 0.5));
                    if (enemy.health < 0) enemy.health = 0;
                    OutputOnScreen("你攻击了" + enemy.name + "," + enemy.name + "损失了 " + (int)((player.damage - enemy.defense * 0.5)) + " 点血量");
                }
                if (enemy.checkDead())
                {
                    int Exp = Math.Max(enemy.level * 20 - player.level * 2, 1);
                    OutputOnScreen(enemy.name + "去世辣,获得" + Exp + "点经验值");
                    IsBattle = false;
                    player.EXP += Exp;
                    enemy.NPCLoot(this);
                }
                else
                {
                    OutputOnScreen(enemy.name + "还剩下" + enemy.health + "点血量");
                    player.health -= (int)((enemy.damage - player.defense * 0.5));
                    OutputOnScreen(enemy.name + "攻击了你，你损失了" + (int)((enemy.damage - player.defense * 0.5)) + " 点血量");
                }
                if (player.checkDead())
                {
                    OutputOnScreen("你去世辣");
                    if (player.level > 1)
                    {
                        OutputOnScreen("将消耗1级复活,同时全属性等级下降1级");
                        player.level -= 1;
                        if(player.HealthLevel > 0)
                        {
                            player.maxHealth -= player.HealthLevel * (player.HealthLevel + 2) / (player.HealthLevel + 1);
                            player.HealthLevel--;
                        }
                        if (player.DamageLevel > 0)
                        {
                            player.baseDamage -= 2 + player.DamageLevel / 5;
                            player.DamageLevel--;
                        }
                        IsBattle = false;
                        player.health = player.maxHealth;
                        OutputOnScreen("你复活辣");
                    }
                }
            }
        }
        public void AddHealth_Click(object sender, EventArgs e)
        {
            player.HealthLevel++;
            player.health += player.HealthLevel * (player.HealthLevel + 2) / (player.HealthLevel + 1);
            player.maxHealth += player.HealthLevel * (player.HealthLevel + 2) / (player.HealthLevel + 1);
            Point--;
        }
        public void AddDamage_Click(object sender, EventArgs e)
        {
            player.DamageLevel++;
            player.baseDamage += 2 + player.DamageLevel / 5;
            Point--;
        }
        public void AddDefense_Click(object sender, EventArgs e)
        {
            player.DefenseLevel++;
            player.baseDefense += 2 + player.DefenseLevel / 5;
            Point--;
        }
        public void Equip_Click(object sender, EventArgs e)
        {
            if (InventoryList.SelectedIndex != -1)
            {
                Item item = player.weapon;
                player.weapon = player.Inventory[InventoryList.SelectedIndex].Item1;
                player.Inventory[InventoryList.SelectedIndex] = (player.Inventory[InventoryList.SelectedIndex].Item1, player.Inventory[InventoryList.SelectedIndex].Item2 - 1);
                if (item.name != "拳头") AddItemToInventory(item, 1);
            }
            player.Inventory.RemoveAll(c => c.Item2 == 0);
            UpdateInventory();
            UpdateRecipes();
        }
        public void EquipArmor_Click(object sender, EventArgs e)
        {
            if (InventoryList.SelectedIndex != -1)
            {
                Item item = player.armor;
                player.armor = player.Inventory[InventoryList.SelectedIndex].Item1;
                player.Inventory[InventoryList.SelectedIndex] = (player.Inventory[InventoryList.SelectedIndex].Item1, player.Inventory[InventoryList.SelectedIndex].Item2 - 1);
                if (item.name != "无") AddItemToInventory(item, 1);
            }
            player.Inventory.RemoveAll(c => c.Item2 == 0);
            UpdateInventory();
            UpdateRecipes();
        }
        public void WeaponText_Click(object sender, EventArgs e)
        {
            ItemDescription.Text = player.weapon.name + "   稀有度 : " + player.weapon.rare + "\n伤害 : " + player.weapon.damage;
        }
        public void Disequip_Click(object sender, EventArgs e)
        {
            if (player.weapon.name != "拳头") AddItemToInventory(player.weapon, 1);
            else OutputOnScreen("你想给自己截肢?");
            player.weapon = new Item("拳头", 0);
            UpdateInventory();
            UpdateRecipes();
        }
        public void use_Click(object sender, EventArgs e)
        {
            if (InventoryList.SelectedIndex != -1)
            {
                if (player.Inventory[InventoryList.SelectedIndex].Item1.Use(player))
                    player.Inventory[InventoryList.SelectedIndex] = (player.Inventory[InventoryList.SelectedIndex].Item1, player.Inventory[InventoryList.SelectedIndex].Item2 - 1);
                else OutputOnScreen("甚么也没有发生");
            }
            player.Inventory.RemoveAll(c => c.Item2 == 0);
            UpdateInventory();
            UpdateRecipes();
        }
        public void RecipeList_SelectedIndexChanged(object sender, EventArgs e)
        {
            InventoryList.SelectedIndex = -1;
            if (RecipeList.SelectedIndex != -1)
            {
                ItemDescription.Text = "";
                var recipe = availableRecipes[RecipeList.SelectedIndex];
                foreach (var i in recipe.Materials)
                {
                    ItemDescription.Text += i.Item1.name + " * " + i.Item2 + "\n";
                }
            }
        }
        public void Craft_Click(object sender, EventArgs e)
        {
            if (RecipeList.SelectedIndex != -1)
            {
                var recipe = availableRecipes[RecipeList.SelectedIndex];
                foreach (var i in recipe.Materials)
                {
                    RemoveFromInventory(i.Item1, i.Item2);
                }
                AddItemToInventory(recipe.Result.Item1, recipe.Result.Item2);
                OutputOnScreen(recipe.Result.Item1.name + " * " + recipe.Result.Item2 + "制作成功");
            }
            player.Inventory.RemoveAll(c => c.Item2 == 0);
            UpdateInventory();
            UpdateRecipes();
        }
        public bool IsBattle = false;
        public NPC enemy = new NPC();
        public static Random rand = new Random();
        public List<Recipe> availableRecipes = new List<Recipe>();
        public int Point = 0;
    }
    public class NPC
    {
        public NPC() { }
        public NPC(string name, int level, int damage, int health, int defense)
        {
            this.damage = damage;
            this.defense = defense;
            this.level = level;
            this.name = name;
            this.health = health;
        }
        public virtual bool checkDead()
        {
            if (this.health <= 0) return true;
            else return false;
        }
        public NPC Clone()
        {
            NPC npc = new NPC();
            npc = this.MemberwiseClone() as NPC;
            return npc;
        }
        public virtual void SetStaticDefaults()
        {

        }
        public virtual void SetDefaults()
        {

        }
        public virtual void NPCLoot(GameForm form)
        {
            form.LootItem(new Item("额滴圣剑"), 1, this.name);
        }
        public string name;
        public int level;
        public int damage;
        public int health;
        public int defense;
        public int NPCType;
    }
    public class Player
    {
        public Player()
        {

        }
        public Player(int health, int damage, int defense)
        {
            this.health = health;
            this.maxHealth = health;
            this.baseDamage = damage;
            this.baseDefense = defense;
            this.level = 1;
            this.EXP = 0;
            this.crit = 0.04;
            this.Inventory = new List<(Item, int)>();
            this.weapon = new Item("拳头");
            this.armor = new Item("无");
        }
        public virtual bool checkDead()
        {
            if (this.health <= 0) return true;
            else return false;
        }
        public void Heal(int HealNum, string ItemName, GameForm form)
        {
            health += HealNum;
            if (health > maxHealth) health = maxHealth;
            form.OutputOnScreen("使用" + ItemName + ",恢复" + HealNum + "点血量");
        }
        public int HealthLevel = 0;
        public int DamageLevel = 0;
        public int DefenseLevel = 0;
        public int health;//生命值
        public int baseDamage = 0;
        public int damage;//伤害
        public int maxHealth;
        public int defense;
        public int baseDefense = 0;
        public int level, EXP;
        public Item weapon;
        public Item armor;
        public double crit;
        public List<(Item, int)> Inventory;
    }
    public class Item
    {
        public Item() { this.name = "none"; }
        public Item(string Name, int damage = 0, int defense = 0)
        {
            this.name = Name;
        }
        public virtual void SetStaticDefaults()
        {

        }
        public virtual void SetDefaults()
        {

        }
        public virtual bool Use(Player player)
        {
            return false;
        }
        public virtual (bool, Recipe) AddRecipe()
        {
            return (false, new Recipe());
        }
        public string name;
        public string description = "none";
        public int itemType;
        public int damage = 0;
        public int defense = 0;
        public int rare = 1;
    }
    public class Recipe
    {
        public Recipe() { }
        public void AddMaterial(Item item, int stack = 1)
        {
            int n = Materials.FindIndex(c => c.Item1.name == item.name);
            if (n != -1)
            {
                var i = Materials[n];
                i.Item2 += stack;
                Materials.RemoveAt(n);
                Materials.Insert(n, i);
                return;
            }
            Materials.Add((item, stack));
        }
        public void AddMaterial(int ItemType, int stack = 1)
        {
            Item item = ItemLoader.ItemList[ItemType];
            int n = Materials.FindIndex(c => c.Item1.name == item.name);
            if (n != -1)
            {
                var i = Materials[n];
                i.Item2 += stack;
                Materials.RemoveAt(n);
                Materials.Insert(n, i);
                return;
            }
            Materials.Add((item, stack));
        }
        public void SetResult(Item item, int stack = 1)
        {
            Result = (item, stack);
        }

        public bool Available(List<(Item, int)> Inventory)
        {
            bool ret = true;
            foreach(var i in Materials)
            {
                ret &= Inventory.FindAll(c => c.Item1.itemType == i.Item1.itemType && c.Item2 >= i.Item2).Count > 0;
            }
            return ret;
        }
        public List<(Item, int)> Materials = new List<(Item, int)>();
        public (Item, int) Result = (new Item(), 1);
    }

    public class NPCLoader
    {
        public static void Load()
        {
            Assembly assembly = Assembly.GetEntryAssembly();
            Type[] types = assembly.GetTypes().Where(t => t.FullName.Contains(".NPCs.")).ToArray();
            foreach (var i in types)
            {
                var obj = Activator.CreateInstance(i);
                (obj as NPC).SetStaticDefaults();
                (obj as NPC).SetDefaults();
                NPCList.Add((int)(i.GetField("NPCType").GetValue(obj)), obj as NPC);
            }
        }
        public static Dictionary<int, NPC> NPCList = new Dictionary<int, NPC>();

    }
    public class ItemLoader
    {
        public static void Load()
        {
            Assembly assembly = Assembly.GetEntryAssembly();
            Type[] types = assembly.GetTypes().Where(t => t.FullName.Contains(".Items.")).ToArray();
            foreach (var i in types)
            {
                var obj = Activator.CreateInstance(i) as Item;
                obj.SetStaticDefaults();
                obj.SetDefaults();
                ItemList.Add((int)(i.GetField("itemType").GetValue(obj)), obj);
                if (obj.AddRecipe().Item1) Recipes.Add(obj.AddRecipe().Item2);
            }
        }
        public static Dictionary<int, Item> ItemList = new Dictionary<int, Item>();
        public static List<Recipe> Recipes = new List<Recipe>();
    }
    public class ModLoader
    {
        public static List<Assembly> assemblies = new List<Assembly>();
        public static void Load()
        {
            LoadMods();
            Assembly a = Assembly.GetEntryAssembly();
            foreach (var assembly in assemblies)
            {
                if (assembly.GetTypes().Where(t => t.IsSubclassOf(typeof(Mod))).Count() == 0)
                {
                    MessageBox.Show("加载错误: " + assembly.GetName().Name + " 此Mod需要一个Mod类");
                    continue;
                }
                Type[] types = assembly.GetTypes().Where(t =>!t.IsAbstract).ToArray();
                foreach (var type in types)
                {
                    if (type.IsSubclassOf(typeof(Item))) LoadItem(type);
                    if (type.IsSubclassOf(typeof(NPC))) LoadNPC(type);
                    if (type.IsSubclassOf(typeof(Mod))) mods.Add(Activator.CreateInstance(type) as Mod);
                }
            }
        }
        public static T GetInstance<T>() where T : class => ContentInstance<T>.Instance;
        public static int ItemType<T>() where T : Item => GetInstance<T>()?.itemType ?? 0;
        public static int NPCType<T>() where T : NPC => GetInstance<T>()?.NPCType ?? 0;
        public static void LoadMods()
        {
            string dir = Directory.GetCurrentDirectory();
            var info = Directory.CreateDirectory(Directory.GetCurrentDirectory() + "\\Mods");
            var files = info.GetFiles("*.dll");
            foreach(var i in files)
            {
                Assembly a = Assembly.LoadFrom(i.FullName);
                assemblies.Add(a);
            }
        }
        public static void LoadNPC(Type NPCType)
        {
            var obj = Activator.CreateInstance(NPCType) as NPC;
            obj.NPCType = NPCLoader.NPCList.Count + 1;
            obj.SetDefaults();
            Type type = typeof(ContentInstance<>).MakeGenericType(NPCType);
            PropertyInfo p = type.GetProperty("Instance", BindingFlags.Static | BindingFlags.Public);
            p.SetValue(typeof(ContentInstance<>), obj);
            NPCLoader.NPCList.Add((int)(NPCType.GetField("NPCType").GetValue(obj)), obj);
        }
        public static void LoadItem(Type ItemType)
        {
            var obj = Activator.CreateInstance(ItemType) as Item;
            obj.SetDefaults();
            obj.SetStaticDefaults();
            obj.itemType = ItemLoader.ItemList.Count + 1;
            Type type = typeof(ContentInstance<>).MakeGenericType(ItemType);
            PropertyInfo p = type.GetProperty("Instance", BindingFlags.Static | BindingFlags.Public);
            p.SetValue(typeof(ContentInstance<>), obj);
            ItemLoader.ItemList.Add((int)(ItemType.GetField("itemType").GetValue(obj)), obj);
            if (obj.AddRecipe().Item1) ItemLoader.Recipes.Add(obj.AddRecipe().Item2);
        }
        public static List<Mod> mods = new List<Mod>();
    }
    public static class ContentInstance<T> where T : class
    {
        public static T Instance { get; private set; }
    }
    public class Mod
    {
        public string DisplayName = Assembly.GetEntryAssembly().GetName().Name;
    }
    public class ModUI
    { 
        public static void AppendModForm(Mod mod, ModForm modForm)
        {
            modForms.Add((modForm, ModLoader.mods.FindIndex(m => m.GetType() == mod.GetType())));
        }
        public static GameForm GetGameForm()
        {
            return gameForm;
        }
        internal static GameForm gameForm;
        public static List<(ModForm, int)> modForms = new List<(ModForm, int)>();
    }
    public class ModForm : Form
    { 
        public void AppendButton(string ButtonName, string ButtonText = "")
        {

        }
    }
}
