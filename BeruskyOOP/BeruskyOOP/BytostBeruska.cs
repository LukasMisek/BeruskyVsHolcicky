using System;
using System.Collections.Generic;
using System.Text;

namespace BeruskyOOP
{
    class BytostBeruska : Bytost
    {
        public int zdravi;

        public BytostBeruska(int posX, int posY, int zdravi)
        {
            this.posX = posX;
            this.posY = posY;
            this.zdravi = zdravi;
        }
    }
}
