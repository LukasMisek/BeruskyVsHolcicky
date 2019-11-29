using System;
using System.Collections.Generic;
using System.Text;

namespace BeruskyOOP
{
    class Beruska : Bytost
    {
        public Beruska(PoleTravy pole)
        {
            var rnd = new Random();

            this.posX = rnd.Next(1, pole.height - 1);
            this.posY = rnd.Next(1, pole.width - 1);
            this.zdravi = 10;
            this.skore = 0;
            this.pole = pole;
            this.idBytosti = index;
            index++;
            this.nick = "B" + this.idBytosti;
            pole.data.Rows[this.posY - 1][this.posX - 1] = nick;
            this.sila = 50;
        }

    }
}
