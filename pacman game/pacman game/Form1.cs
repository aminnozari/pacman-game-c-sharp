namespace pacman_game
{
    public partial class pacman : Form
    {
        bool goup, godown, goleft, goright, isgameover;
        int score, playerspeed, redghostspeed, yellowghostspeed, pinkghostY, pinkghostX;
        public pacman()
        {
            InitializeComponent();
            ResetGame();
        }
        private void keyisdown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up)
            {
                goup = true;
            }
            if(e.KeyCode == Keys.Down)
            {
                godown = true;
            }
            if(e.KeyCode == Keys.Left)
            {
                goleft = true;
            }
            if (e.KeyCode == Keys.Right)
            {
                goright = true;
            }
        }
        private void keyisup(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up)
            {
                goup = false;
            }
            if (e.KeyCode == Keys.Down)
            {
                godown = false;
            }
            if (e.KeyCode == Keys.Left)
            {
                goleft = false;
            }
            if (e.KeyCode == Keys.Right)
            {
                goright = false;
            }
        }
        private void maingametimer(object sender, EventArgs e)
        {
            txtscore.Text = "Score " + score;
            if(goleft == true)
            {
                PacmanPic.Left -= playerspeed;
                PacmanPic.Image = Properties.Resources.c_users_admin_desktop_images_pac_man_images_mooic_3;
            }
            if(goright == true)
            {
                PacmanPic.Left += playerspeed;
                PacmanPic.Image = Properties.Resources.c_users_admin_desktop_images_pac_man_images_mooic_2;
            }
            if(godown == true)
            {
                PacmanPic.Top += playerspeed;
                PacmanPic.Image = Properties.Resources.c_users_admin_desktop_images_pac_man_images_mooic_1;
            }
            if(goup == true)
            {
                PacmanPic.Top -= playerspeed;
                PacmanPic.Image = Properties.Resources.c_users_admin_desktop_images_pac_man_images_mooic;
            }
            if(PacmanPic.Left < -10)
            {
                PacmanPic.Left = 680;
            }
            if (PacmanPic.Left > 680)
            {
                PacmanPic.Left = -10;
            }
            if ( PacmanPic.Top < -10)
            {
                PacmanPic.Top = 550;
            }
            if (PacmanPic.Top > 550)
            {
                PacmanPic.Top = 0;
            }
            foreach(Control x in this.Controls)
            {
                if (x is PictureBox)
                {
                    if((string)x.Tag == "coin" && x.Visible == true)
                    {
                        if(PacmanPic.Bounds.IntersectsWith(x.Bounds))
                        {
                            score += 1;
                            x.Visible=false;
                        }
                    }
                    if((string)x.Tag == "wall")
                    {
                        if(PacmanPic.Bounds.IntersectsWith(x.Bounds))
                        {
                            //lose
                        }
                    }
                    if ((string)x.Tag == "ghost")
                    {
                        if(PacmanPic.Bounds.IntersectsWith(x.Bounds))
                        {
                            //lose
                        }
                    }
                }
            }
            RedGhost.Left += redghostspeed;
            if(RedGhost.Bounds.IntersectsWith(pictureBox1.Bounds) 
                || RedGhost.Bounds.IntersectsWith(pictureBox2.Bounds))
            {
                redghostspeed = -redghostspeed;
            }
            /*
            YellowGhost.Left -= yellowghostspeed;
            if (YellowGhost.Bounds.IntersectsWith(pictureBox3.Bounds) 
                ||YellowGhost.Bounds.IntersectsWith(pictureBox4.Bounds)
                )
            {
                redghostspeed =  -redghostspeed;
            }
            */

            if(score == 64 )
            {
                //MessageBox.Show("You Win");
                

            }
        }
        private void ResetGame()
        {
            playerspeed = 8;
            txtscore.Text = "Score:0";
            score = 0;  
            redghostspeed = 5;
            yellowghostspeed = 5;
            pinkghostX = 5;
            pinkghostY = 5;
            isgameover = false;
            PacmanPic.Left = 42;
            PacmanPic.Top = 50;
            RedGhost.Left = 322;
            RedGhost.Top = 64;
            pinkGhost.Left = 625;
            pinkGhost.Top = 27;
            YellowGhost.Left = 417;
            YellowGhost.Top = 427;
            gameTimer.Start();
            foreach(Control x in this.Controls)
            {
                if(x is PictureBox)
                {
                    x.Visible = true;
                }
            }

        }
        private void GameOver(string message)
        {

        }
    }
}