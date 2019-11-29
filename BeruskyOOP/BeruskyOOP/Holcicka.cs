using System;
using System.Collections.Generic;
using System.Text;

namespace BeruskyOOP
{
    class Holcicka : Bytost
    {
        public Holcicka(PoleTravy pole)
        {
            var rnd = new Random();

            this.posX = rnd.Next(1, pole.height - 1);
            this.posY = rnd.Next(1, pole.width - 1);
            this.zdravi = 100;
            this.skore = 0;
            this.pole = pole;
            this.idBytosti = index;
            index++;
            this.nick = "A" + this.idBytosti;
            pole.data.Rows[this.posY - 1][this.posX - 1] = nick;
            this.sila = 100;
        }

    }
}
