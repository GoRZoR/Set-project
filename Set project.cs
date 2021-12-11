#include <U8glib.h>
U8GLIB_ST7920_128X64_1X u8g(6, 5, 4 , 7); //Enable, RW, RS, RESET
int rst = A3;
int ent = A2;
int A = A1;
int B = A0;
int C = 2;
int Acom = 3;
int Bcom = 8;
int Ccom = 9;
int in = 10;
int U = 11;
int sub = 12;
int buzzer = 13;
String dat;
char buff[20];
int en = 0;
void setup() {
  Serial.begin(9600);
  pinMode(rst, INPUT_PULLUP);
  pinMode(ent, INPUT_PULLUP);
  pinMode(A, INPUT_PULLUP);
  pinMode(B, INPUT_PULLUP);
  pinMode(C, INPUT_PULLUP);
  pinMode(Acom, INPUT_PULLUP);
  pinMode(Bcom, INPUT_PULLUP);
  pinMode(Ccom, INPUT_PULLUP);
  pinMode(in, INPUT_PULLUP);
  pinMode(U, INPUT_PULLUP);
  pinMode(sub, INPUT_PULLUP);
  pinMode(buzzer, OUTPUT);
}
void loop() {
  if (en == 0 || en == 1) {
    buzz();
    A_count();
    B_count();
    C_count();
    Acom_count();
    Bcom_count();
    Ccom_count();
    in_count();
    U_count();
    sub_count();
    ent_count();
  }
  rst_count();
  dat.toCharArray(buff, 20);
  u8g.firstPage();
  do {
    if (en == 0 || en == 1) {
      home_state();
    }
    else if ((dat == "A" || dat == "AinA" || dat == "AUA" || dat == "AinBUA" || dat == "BinAUA"
              || dat == "AinCUA" || dat == "CinAUA") && en == 2) {
      Anormal();
    }
    else if ((dat == "B" || dat == "BinB" || dat == "BUB" || dat == "BinAUB" || dat == "AinBUB"
              || dat == "BinCUB" || dat == "CinBUB") && en == 2) {
      Bnormal();
    }
    else if ((dat == "C" || dat == "CinC" || dat == "CUC" || dat == "CinAUC" || dat == "AinCUC"
              || dat == "CinBUC" || dat == "BinCUC") && en == 2) {
      Cnormal();
    }
    else if ((dat == "AinB" || dat == "BinA") && en == 2) {
      A_in_B();
    }
    else if ((dat == "AinC" || dat == "CinA") && en == 2) {
      A_in_C();
    }
    else if ((dat == "BinC" || dat == "CinB") && en == 2) {
      B_in_C();
    }
    else if ((dat == "AinBinC" || dat == "AinCinB" || dat == "BinCinA" || dat == "BinAinC"
              || dat == "CinAinB" || dat == "CinBinA") && en == 2) {
      A_in_B_in_C();
    }
    else if ((dat == "AUB" || dat == "BUA") && en == 2) {
      A_U_B();
    }
    else if ((dat == "AUC" || dat == "CUA") && en == 2) {
      A_U_C();
    }
    else if ((dat == "BUC" || dat == "CUB") && en == 2) {
      B_U_C();
    }
    else if ((dat == "AUBUC" || dat == "AUCUB" || dat == "BUCUA" || dat == "BUAUC"
              || dat == "CUAUB" || dat == "CUBUA") && en == 2) {
      A_U_B_U_C();
    }
    else if ((dat == "A-B") && en == 2) {
      A_sub_B();
    }
    else if ((dat == "B-A") && en == 2) {
      B_sub_A();
    }
    else if ((dat == "A-C") && en == 2) {
      A_sub_C();
    }
    else if ((dat == "C-A") && en == 2) {
      C_sub_A();
    }
    else if ((dat == "B-C") && en == 2) {
      B_sub_C();
    }
    else if ((dat == "C-B") && en == 2) {
      C_sub_B();
    }
    else if ((dat == "A-B-C" || dat == "A-C-B") && en == 2) {
      A_sub_B_sub_C();
    }
    else if ((dat == "B-A-C" || dat == "B-C-A") && en == 2) {
      B_sub_A_sub_C();
    }
    else if ((dat == "C-A-B" || dat == "C-B-A") && en == 2) {
      C_sub_A_sub_B();
    }
    else if ((dat == "Acom" || dat == "AcominAcom" || dat == "AcomUAcom") && en == 2) {
      A_com();
    }
    else if ((dat == "Bcom" || dat == "BcominBcom" || dat == "BcomUBcom") && en == 2) {
      B_com();
    }
    else if ((dat == "Ccom" || dat == "CcominCcom" || dat == "CcomUCcom") && en == 2) {
      C_com();
    }
    else if ((dat == "AcominB" || dat == "BinAcom") && en == 2) {
      A_com_in_B();
    }
    else if ((dat == "AcominC" || dat == "CinAcom") && en == 2) {
      A_com_in_C();
    }
    else if ((dat == "BcominA" || dat == "AinBcom") && en == 2) {
      B_com_in_A();
    }
    else if ((dat == "BcominC" || dat == "CinBcom") && en == 2) {
      B_com_in_C();
    }
    else if ((dat == "CcominA" || dat == "AinCcom") && en == 2) {
      C_com_in_A();
    }
    else if ((dat == "CcominB" || dat == "BinCcom") && en == 2) {
      C_com_in_B();
    }
    else if ((dat == "AcominBcom" || dat == "BcominAcom"
              ||dat == "Acom-B" || dat == "Bcom-A") && en == 2) {
      A_com_in_B_com();
    }
    else if ((dat == "AcominCcom" || dat == "CcominAcom"
              ||dat == "Acom-C" || dat == "Ccom-A") && en == 2) {
      A_com_in_C_com();
    }
    else if ((dat == "BcominCcom" || dat == "CcominBcom"
              ||dat == "Bcom-C" || dat == "Ccom-B") && en == 2) {
      B_com_in_C_com();
    }
    else if ((dat == "AcominBinC" || dat == "AcominCinB" || dat == "BinCinAcom" || dat == "CinBinAcom"
              || dat == "BinAcominC" || dat == "CinAcominB") && en == 2) {
      A_com_in_B_in_C();
    }
    else if ((dat == "BcominAinC" || dat == "BcominCinA" || dat == "AinCinBcom" || dat == "CinAinBcom"
              || dat == "AinBcominC" || dat == "CinBcominA") && en == 2) {
      B_com_in_A_in_C();
    }
    else if ((dat == "CcominAinB" || dat == "CcominBinA" || dat == "AinBinCcom" || dat == "BinAinCcom"
              || dat == "AinCcominB" || dat == "CinAcominB") && en == 2) {
      C_com_in_A_in_B();
    }
    else if ((dat == "AcominBcominC" || dat == "AcominCinBcom" || dat == "BcominAcominC"
              || dat == "BcominCinAcom" || dat == "CinAcominBcom" || dat == "CinBcominAcom") && en == 2) {
      A_com_in_B_com_in_C();
    }
    else if ((dat == "AcominBinCcom" || dat == "AcominCcominB" || dat == "BinAcominCcom"
              || dat == "BinCcominAcom" || dat == "CcominAcominB" || dat == "CcominBinAcom") && en == 2) {
      A_com_in_B_in_C_com();
    }
    else if ((dat == "AcominBcominCcom" || dat == "AcominCcominBcom" || dat == "BcominAcominCcom"
              || dat == "BcominCcominAcom" || dat == "CcominAcominBcom" || dat == "CcominBcominAcom") && en == 2) {
      A_com_in_B_com_in_C_com();
    }
    else if ((dat == "AcomUB" || dat == "BUAcom") && en == 2) {
      A_com_U_B();
    }
    else if ((dat == "AcomUC" || dat == "CUAcom") && en == 2) {
      A_com_U_C();
    }
    else if ((dat == "BcomUA" || dat == "AUBcom") && en == 2) {
      B_com_U_A();
    }
    else if ((dat == "BcomUC" || dat == "CUBcom") && en == 2) {
      B_com_U_C();
    }
    else if ((dat == "CcomUA" || dat == "AUCcom") && en == 2) {
      C_com_U_A();
    }
    else if ((dat == "CcomUB" || dat == "BUCcom") && en == 2) {
      C_com_U_B();
    }
    else if ((dat == "AcomUBcom" || dat == "AcomUCcom" || dat == "BcomUAcom" || dat == "BcomUCcom" || dat == "CcomUAcom" || dat == "CcomUBcom"
              || dat == "AcomUBcomUA" || dat == "AcomUCcomUA" || dat == "BcomUAcomUA" || dat == "BcomUCcomUA" || dat == "CcomUAcomUA" || dat == "CcomUBcomUA"
              || dat == "AcomUBcomUB" || dat == "AcomUCcomUB" || dat == "BcomUAcomUB" || dat == "BcomUCcomUB" || dat == "CcomUAcomUB" || dat == "CcomUBcomUB"
              || dat == "AcomUBcomUC" || dat == "AcomUCcomUC" || dat == "BcomUAcomUC" || dat == "BcomUCcomUC" || dat == "CcomUAcomUC" || dat == "CcomUBcomUC"
              || dat == "AcomUBcomUCcom" || dat == "AcomUCcomUBcom"
              || dat == "BcomUAcomUCcom" || dat == "BcomUCcomUAcom"
              || dat == "CcomUAcomUBcom" || dat == "CcomUBcomUAcom")
             && en == 2) {
      B_S();
    }
    else if ((dat == "AcomUBUC" || dat == "AcomUCUB" || dat == "BUCUAcom" || dat == "CUBUAcom"
              || dat == "BUAcomUC" || dat == "CUAcomUB") && en == 2) {
      A_com_U_B_U_C();
    }
    else if ((dat == "BcomUAUC" || dat == "BcomUCUA" || dat == "AUCUBcom" || dat == "CUAUBcom"
              || dat == "AUBcomUC" || dat == "CUBcomUA") && en == 2) {
      B_com_U_A_U_C();
    }
    else if ((dat == "CcomUAUB" || dat == "CcomUBUA" || dat == "AUBUCcom" || dat == "BUAUCcom"
              || dat == "AUCcomUB" || dat == "CUAcomUB") && en == 2) {
      C_com_U_A_U_B();
    }
    else if ((dat == "C-Bcom") && en == 2) {
      C_sub_B_com();
    }
    else if ((dat == "C-Acom") && en == 2) {
      C_sub_A_com();
    }
    else if ((dat == "Acom-Bcom" || dat == "Bcom-Acom" || dat == "Acom-Ccom" || dat == "Ccom-Acom"
              || dat == "Bcom-Ccom" || dat == "Ccom-Bcom" || dat == "Acom-Bcom-C" || dat == "Acom-C-Bcom"
              || dat == "Bcom-Acom-C" || dat == "Bcom-C-Acom" || dat == "C-Acom-Bcom" || dat == "C-Bcom-Acom"
              || dat == "Acom-B-Ccom" || dat == "Acom-Ccom-B" || dat == "B-Acom-Ccom" || dat == "B-Ccom-Acom"
              || dat == "Ccom-Acom-B" || dat == "Ccom-B-Acom" || dat == "A-Bcom-Ccom" || dat == "A-Ccom-Bcom"
              || dat == "Bcom-A-Ccom" || dat == "Bcom-Ccom-A" || dat == "Ccom-A-Bcom" || dat == "Ccom-Bcom-A"
              || dat == "Acom-Bcom-Ccom" || dat == "Acom-Ccom-Bcom" || dat == "Bcom-Acom-Ccom" || dat == "Bcom-Ccom-Acom"
              || dat == "Ccom-Acom-Bcom" || dat == "Ccom-Bcom-Acom" || dat == "AinAcom" || dat == "BinBcom"
              || dat == "CinCcom" || dat == "AcominA" || dat == "BcominB" || dat == "CcominC" || dat == "A-Acom"
              || dat == "B-Bcom" || dat == "C-Ccom" || dat == "Acom-A" || dat == "Bcom-B" || dat == "Ccom-C"
              || dat == "AinBinAcom" || dat == "AinAcominB" || dat == "BinAinAcom" || dat == "BinAcominA"
              || dat == "AcominAinB" || dat == "AcominBinA" || dat == "AinBinBcom" || dat == "AinBcominB"
              || dat == "BinAinBcom" || dat == "BinBcominA" || dat == "BcominAinB" || dat == "BcominBinA"
              || dat == "AinCinAcom" || dat == "AinAcominC" || dat == "CinAinAcom" || dat == "CinAcominA"
              || dat == "AcominAinC" || dat == "AcominCinA" || dat == "AinCinCcom" || dat == "AinCcominC"
              || dat == "CinAinCcom" || dat == "CinCcominA" || dat == "CcominAinC" || dat == "CcominCinA"
              || dat == "BinCinCcom" || dat == "BinCcominC" || dat == "CinBinCcom" || dat == "CinCcominB"
              || dat == "CcominBinC" || dat == "CcominCinB" || dat == "BinCinBcom" || dat == "BinBcominC"
              || dat == "CinBinBcom" || dat == "CinBcominB" || dat == "BcominBinC" || dat == "BcominCinB") && en == 2) {
      A_com_sub_B_com();
    }
    else if ((dat == "Acom-B-C" || dat == "Acom-C-B" || dat == "Bcom-A-C" || dat == "Bcom-C-A"
              || dat == "Ccom-A-B" || dat == "Ccom-B-A") && en == 2) {
      A_com_sub_B_sub_C();
    }
    else if ((dat == "AUAcom" || dat == "BUBcom" || dat == "CUCcom" || dat == "AcomUA" || dat == "BcomUB"
              || dat == "CcomUC" || dat == "AUBUAcom" || dat == "AUAcomUB" || dat == "BUAUAcom" || dat == "BUAcomUA"
              || dat == "AcomUAUB" || dat == "AcomUBUA" || dat == "AUBUBcom" || dat == "AUBcomUB" || dat == "BUAUBcom"
              || dat == "BUBcomUA" || dat == "BcomUAUB" || dat == "BcomUBUA" || dat == "AUCUAcom" || dat == "AUAcomUC"
              || dat == "CUAUAcom" || dat == "CUAcomUA" || dat == "AcomUAUC" || dat == "AcomUCUA" || dat == "AUCUCcom"
              || dat == "AUCcomUC" || dat == "CUAUCcom" || dat == "CUCcomUA" || dat == "CcomUAUC" || dat == "CcomUCUA"
              || dat == "BUCUCcom" || dat == "BUCcomUC" || dat == "CUBUCcom" || dat == "CUCcomUB" || dat == "CcomUBUC"
              || dat == "CcomUCUB" || dat == "BUCUBcom" || dat == "BUBcomUC" || dat == "CUBUBcom" || dat == "CUBcomUB"
              || dat == "BcomUBUC" || dat == "BcomUCUB") && en == 2) {
      A_U_A_com();
    }
    else if ((dat == "AinBUC" || dat == "BinAUC") && en == 2) {
      A_in_B_U_C();
    }
    else if ((dat == "AinCUB" || dat == "CinAUB") && en == 2) {
      A_in_C_U_B();
    }
    else if ((dat == "BinCUA" || dat == "CinBUA") && en == 2) {
      B_in_C_U_A();
    }
    else if ((dat == "AinBUCcom" || dat == "BinAUCcom") && en == 2) {
      A_in_B_U_C_com();
    }
    else if ((dat == "AinCUBcom" || dat == "CinAUBcom") && en == 2) {
      A_in_C_U_B_com();
    }
    else if ((dat == "BinCUAcom" || dat == "CinBUAcom") && en == 2) {
      B_in_C_U_A_com();
    }
    else if ((dat == "AcominBUC" || dat == "BinAcomUC") && en == 2) {
      A_com_in_B_U_C();
    }
    else if ((dat == "BcominCUA" || dat == "CinBcomUA") && en == 2) {
      B_com_in_C_U_A();
    }
    else if ((dat == "AcominBcomUC" || dat == "BcominAcomUC") && en == 2) {
      A_com_in_B_U_C();
    }
    else if ((dat == "AcominCcomUB" || dat == "CcominAcomUB") && en == 2) {
      A_com_in_C_com_U_B();
    }
    else if ((dat == "BcominCcomUA" || dat == "CcominBcomUA") && en == 2) {
      B_com_in_C_com_U_A();
    }
    else if ((dat == "AcominBUCcom" || dat == "BinAcomUCcom") && en == 2) {
      A_com_in_B_U_C_com();
    }
    else if ((dat == "AcominCUBcom" || dat == "CinAcomUBcom") && en == 2) {
      A_com_in_C_U_B_com();
    }
    else if ((dat == "BcominCUAcom" || dat == "CinBcomUAcom") && en == 2) {
      B_com_in_C_U_A_com();
    }
    else if (dat == "AA" && en == 2) {
      AA();
    }
    else if (dat == "AUCinB" && en ==2)
    {
    
    else {
      no_data();
    }
  }
  while ( u8g.nextPage() );
  Serial.print(dat); Serial.print(" ");
  Serial.print(en); Serial.print(" ");
  Serial.println();
}
void buzz() {
  if (digitalRead(rst) == 0 || digitalRead(ent) == 0 || digitalRead(A) == 0 || digitalRead(B) == 0 || digitalRead(C) == 0
      || digitalRead(Acom) == 0 || digitalRead(Bcom) == 0 || digitalRead(Ccom) == 0 || digitalRead(in) == 0
      || digitalRead(U) == 0 || digitalRead(sub) == 0) {
    digitalWrite(buzzer, HIGH);
  }
  if (digitalRead(rst) == 1 && digitalRead(ent) == 1 && digitalRead(A) == 1 && digitalRead(B) == 1 && digitalRead(C) == 1
      && digitalRead(Acom) == 1 && digitalRead(Bcom) == 1 && digitalRead(Ccom) == 1 && digitalRead(in) == 1
      && digitalRead(U) == 1 && digitalRead(sub) == 1) {
    digitalWrite(buzzer, LOW);
  }
}
bool A_state = 0;
void A_count() {
  if (digitalRead(A) == 0) {
    A_state = 1;
  }
  if (A_state == 1 && digitalRead(A) == 1) {
    dat = dat + "A";
    en = 1;
    A_state = 0;
  }
}
bool B_state = 0;
void B_count() {
  if (digitalRead(B) == 0) {
    B_state = 1;
  }
  if (B_state == 1 && digitalRead(B) == 1) {
    dat = dat + "B";
    en = 1;
    B_state = 0;
  }
}
bool C_state = 0;
void C_count() {
  if (digitalRead(C) == 0) {
    C_state = 1;
  }
  if (C_state == 1 && digitalRead(C) == 1) {
    dat = dat + "C";
    en = 1;
    C_state = 0;
  }
}
bool Acom_state = 0;
void Acom_count() {
  if (digitalRead(Acom) == 0) {
    Acom_state = 1;
  }
  if (Acom_state == 1 && digitalRead(Acom) == 1) {
    dat = dat + "Acom";
    en = 1;
    Acom_state = 0;
  }
}
bool Bcom_state = 0;
void Bcom_count() {
  if (digitalRead(Bcom) == 0) {
    Bcom_state = 1;
  }
  if (Bcom_state == 1 && digitalRead(Bcom) == 1) {
    dat = dat + "Bcom";
    en = 1;
    Bcom_state = 0;
  }
}
bool Ccom_state = 0;
void Ccom_count() {
  if (digitalRead(Ccom) == 0) {
    Ccom_state = 1;
  }
  if (Ccom_state == 1 && digitalRead(Ccom) == 1) {
    dat = dat + "Ccom";
    en = 1;
    Ccom_state = 0;
  }
}
bool in_state = 0;
void in_count() {
  if (digitalRead(in) == 0) {
    in_state = 1;
  }
  if (in_state == 1 && digitalRead(in) == 1) {
    dat = dat + "in";
    en = 1;
    in_state = 0;
  }
}
bool U_state = 0;
void U_count() {
  if (digitalRead(U) == 0) {
    U_state = 1;
  }
  if (U_state == 1 && digitalRead(U) == 1) {
    dat = dat + "U";
    en = 1;
    U_state = 0;
  }
}
bool sub_state = 0;
void sub_count() {
  if (digitalRead(sub) == 0) {
    sub_state = 1;
  }
  if (sub_state == 1 && digitalRead(sub) == 1) {
    dat = dat + "-";
    en = 1;
    sub_state = 0;
  }
}
bool ent_state = 0;
void ent_count() {
  if (digitalRead(ent) == 0) {
    ent_state = 1;
  }
  if (ent_state == 1 && digitalRead(ent) == 1) {
    en = 2;
    ent_state = 0;
  }
}
bool rst_state = 0;
void rst_count() {
  if (digitalRead(rst) == 0) {
    rst_state = 1;
  }
  if (rst_state == 1 && digitalRead(rst) == 1) {
    dat = "";
    en = 0;
    rst_state = 0;
  }
}
void home_state() {
  u8g.setFont(u8g_font_6x10);
  u8g.drawStr( 1, 15, buff);

  u8g.drawFrame(43, 0, 84, 63);

  u8g.setFont(u8g_font_6x10);
  u8g.drawStr( 55, 10, "A");
  u8g.drawStr( 110, 10, "B");
  u8g.drawStr( 82, 62, "C");

  u8g.drawCircle(75, 20, 15);
  u8g.drawCircle(95, 20, 15);
  u8g.drawCircle(85, 38, 15);

  u8g.setFont(u8g_font_10x20);
  u8g.drawStr( 115, 60, "U");
}
void area1(){
    u8g.drawLine(70, 6, 80, 6);
  u8g.drawLine(69, 7, 81, 7);
  u8g.drawLine(67, 8, 83, 8);
  u8g.drawLine(66, 9, 84, 9);
  u8g.drawLine(65, 10, 83, 10);
  u8g.drawLine(64, 11, 82, 11);
  u8g.drawLine(63, 12, 81, 12);
  u8g.drawLine(63, 13, 81, 13);
  u8g.drawLine(62, 14, 80, 14);
  u8g.drawLine(62, 15, 80, 15);
  u8g.drawLine(61, 16, 80, 16);
  u8g.drawLine(61, 17, 79, 17);
  u8g.drawLine(61, 18, 79, 18);
  u8g.drawLine(61, 19, 79, 19);
  u8g.drawLine(61, 20, 79, 20);
  u8g.drawLine(61, 21, 79, 21);
  u8g.drawLine(61, 22, 79, 22);
  u8g.drawLine(61, 23, 79, 23);
  u8g.drawLine(62, 24, 78, 24);
  u8g.drawLine(62, 25, 76, 25);
  u8g.drawLine(62, 26, 75, 26);
  u8g.drawLine(63, 27, 74, 27);
  u8g.drawLine(63, 28, 73, 28);
  u8g.drawLine(64, 29, 72, 29);
  u8g.drawLine(65, 30, 71, 30);
  u8g.drawLine(66, 31, 71, 31);
  u8g.drawLine(67, 32, 70, 32);
  u8g.drawLine(69, 33, 70, 33);


}

void area2(){
    u8g.drawLine(90, 6, 100, 6);
  u8g.drawLine(89, 7, 101, 7);
  u8g.drawLine(87, 8, 103, 8);
  u8g.drawLine(86, 9, 104, 9);
  u8g.drawLine(87, 10, 105, 10);
  u8g.drawLine(88, 11, 106, 11);
  u8g.drawLine(89, 12, 107, 12);
  u8g.drawLine(89, 13, 107, 13);
  u8g.drawLine(90, 14, 108, 14);
  u8g.drawLine(90, 15, 108, 15);
  u8g.drawLine(90, 16, 108, 16);
  u8g.drawLine(91, 17, 109, 17);
  u8g.drawLine(91, 18, 109, 18);
  u8g.drawLine(91, 19, 109, 19);
  u8g.drawLine(91, 20, 109, 20);
  u8g.drawLine(91, 21, 109, 21);
  u8g.drawLine(91, 22, 109, 22);
  u8g.drawLine(91, 23, 109, 23);
  u8g.drawLine(92, 24, 108, 24);
  u8g.drawLine(94, 25, 108, 25);
  u8g.drawLine(95, 26, 108, 26);
  u8g.drawLine(96, 27, 107, 27);
  u8g.drawLine(97, 28, 107, 28);
  u8g.drawLine(98, 29, 106, 29);
  u8g.drawLine(99, 30, 105, 30);
  u8g.drawLine(99, 31, 104, 31);
  u8g.drawLine(100, 32, 103, 32);
  u8g.drawLine(100, 33, 101, 33);



}

void area3(){
    u8g.drawLine(85, 32, 86, 32);
  u8g.drawLine(84, 33, 86, 33);
  u8g.drawLine(82, 34, 88, 34);
  u8g.drawLine(70, 35, 99, 35);
  u8g.drawLine(70, 36, 99, 36);
  u8g.drawLine(70, 37, 99, 37);
  u8g.drawLine(70, 38, 99, 38);
  u8g.drawLine(70, 39, 99, 39);
  u8g.drawLine(70, 40, 99, 40);
  u8g.drawLine(70, 41, 99, 41);
  u8g.drawLine(71, 42, 98, 42);
  u8g.drawLine(71, 43, 98, 43);
  u8g.drawLine(71, 44, 98, 44);
  u8g.drawLine(72, 45, 97, 45);
  u8g.drawLine(72, 46, 97, 46);
  u8g.drawLine(73, 47, 96, 47);
  u8g.drawLine(74, 48, 95, 48);
  u8g.drawLine(75, 49, 94, 49);
  u8g.drawLine(76, 50, 93, 50);
  u8g.drawLine(78, 51, 91, 51);
  u8g.drawLine(80, 52, 89, 52);


}
void area5(){
    u8g.drawLine(78, 25, 80, 25);
  u8g.drawLine(77, 26, 80, 26);
  u8g.drawLine(76, 27, 81, 27);
  u8g.drawLine(75, 28, 81, 28);
  u8g.drawLine(74, 29, 82, 29);
  u8g.drawLine(73, 30, 83, 30);
  u8g.drawLine(73, 31, 84, 31);
  u8g.drawLine(72, 32, 83, 32);
  u8g.drawLine(72, 33, 82, 33);
  u8g.drawLine(71, 34, 81, 34);

}

void area4(){
    u8g.drawLine(85, 10, 86, 10);
  u8g.drawLine(84, 11, 87, 11);
  u8g.drawLine(83, 12, 88, 12);
  u8g.drawLine(82, 13, 89, 13);
  u8g.drawLine(82, 14, 89, 14);
  u8g.drawLine(81, 15, 89, 15);
  u8g.drawLine(81, 16, 89, 16);
  u8g.drawLine(81, 15, 89, 15);
  u8g.drawLine(81, 16, 89, 16);
  u8g.drawLine(80, 17, 90, 17);
  u8g.drawLine(80, 18, 90, 18);
  u8g.drawLine(80, 19, 90, 19);
  u8g.drawLine(80, 20, 90, 20);
  u8g.drawLine(80, 21, 90, 21);
  u8g.drawLine(80, 22, 90, 22);
  u8g.drawPixel(81,23);
  u8g.drawPixel(89,23);


}

void area6(){
    u8g.drawLine(89, 25, 91, 25);
  u8g.drawLine(89, 26, 94, 26);
  u8g.drawLine(88, 27, 95, 27);
  u8g.drawLine(88, 28, 96, 28);
  u8g.drawLine(87, 29, 97, 29);
  u8g.drawLine(86, 30, 98, 30);
  u8g.drawLine(85, 31, 98, 31);
  u8g.drawLine(86, 32, 99, 32);
  u8g.drawLine(89, 33, 99, 33);
  u8g.drawLine(89, 34, 99, 34);



}

void area7(){
  u8g.drawLine(81, 24, 88, 24);
  u8g.drawLine(82, 25, 88, 25);
  u8g.drawLine(82, 26, 88, 26);
  u8g.drawLine(83, 27, 87, 27);
  u8g.drawLine(83, 28, 87, 28);
  u8g.drawLine(84, 29, 86, 29);
  u8g.drawLine(85, 30, 85, 30);

}

void area8(){
    u8g.drawBox(44, 1, 127, 5);
  u8g.drawBox(44, 53, 127, 63);
  u8g.drawLine(44, 6, 68, 6);
  u8g.drawLine(44, 7, 66, 7);
  u8g.drawLine(44, 8, 65, 8);
  u8g.drawLine(44, 9, 64, 9);
  u8g.drawLine(44, 10, 63, 10);
  u8g.drawLine(44, 11, 62, 11);
  u8g.drawLine(44, 12, 61, 12);
  u8g.drawLine(44, 13, 61, 13);
  u8g.drawLine(44, 14, 60, 14);
  u8g.drawLine(44, 15, 60, 15);
  u8g.drawLine(44, 16, 60, 16);
  u8g.drawLine(44, 17, 59, 17);
  u8g.drawLine(44, 18, 59, 18);
  u8g.drawLine(44, 19, 59, 19);
  u8g.drawLine(44, 20, 59, 20);
  u8g.drawLine(44, 21, 59, 21);
  u8g.drawLine(44, 22, 59, 22);
  u8g.drawLine(44, 23, 60, 23);
  u8g.drawLine(44, 24, 60, 24);
  u8g.drawLine(44, 25, 60, 25);
  u8g.drawLine(44, 26, 61, 26);
  u8g.drawLine(44, 27, 61, 27);
  u8g.drawLine(44, 28, 61, 28);
  u8g.drawLine(44, 29, 62, 29);
  u8g.drawLine(44, 30, 63, 30);
  u8g.drawLine(44, 31, 64, 31);
  u8g.drawLine(44, 32, 65, 32);
  u8g.drawLine(44, 33, 66, 33);
  u8g.drawLine(44, 34, 68, 34);
  u8g.drawLine(44, 35, 69, 35);
  u8g.drawLine(44, 36, 69, 36);
  u8g.drawLine(44, 37, 69, 37);
  u8g.drawLine(44, 38, 69, 38);
  u8g.drawLine(44, 39, 69, 39);
  u8g.drawLine(44, 40, 69, 40);
  u8g.drawLine(44, 41, 69, 41);
  u8g.drawLine(44, 42, 70, 42);
  u8g.drawLine(44, 43, 70, 43);
  u8g.drawLine(44, 44, 70, 44);
  u8g.drawLine(44, 45, 71, 45);
  u8g.drawLine(44, 46, 71, 46);
  u8g.drawLine(44, 47, 72, 47);
  u8g.drawLine(44, 48, 73, 48);
  u8g.drawLine(44, 49, 74, 49);
  u8g.drawLine(44, 50, 75, 50);
  u8g.drawLine(44, 51, 76, 51);
  u8g.drawLine(44, 52, 78, 52);
  u8g.drawLine(80, 6, 88, 6);
  u8g.drawLine(82, 7, 86, 7);
  u8g.drawLine(84, 8, 85, 8);
  u8g.drawLine(92, 52, 126, 52);
  u8g.drawLine(94, 51, 126, 51);
  u8g.drawLine(95, 50, 126, 50);
  u8g.drawLine(96, 49, 126, 49);
  u8g.drawLine(97, 48, 126, 48);
  u8g.drawLine(97, 47, 126, 47);
  u8g.drawLine(98, 46, 126, 46);
  u8g.drawLine(98, 45, 126, 45);
  u8g.drawLine(102, 6, 126, 6);
  u8g.drawLine(104, 7, 126, 7);
  u8g.drawLine(105, 8, 126, 8);
  u8g.drawLine(106, 9, 126, 9);
  u8g.drawLine(107, 10, 126, 10);
  u8g.drawLine(108, 11, 126, 11);
  u8g.drawLine(109, 12, 126, 12);
  u8g.drawLine(109, 13, 126, 13);
  u8g.drawLine(110, 14, 126, 14);
  u8g.drawLine(110, 15, 126, 15);
  u8g.drawLine(110, 16, 126, 16);
  u8g.drawLine(111, 17, 126, 17);
  u8g.drawLine(111, 18, 126, 18);
  u8g.drawLine(111, 19, 126, 19);
  u8g.drawLine(111, 20, 126, 20);
  u8g.drawLine(111, 21, 126, 21);
  u8g.drawLine(111, 22, 126, 22);
  u8g.drawLine(111, 23, 126, 23);
  u8g.drawLine(110, 24, 126, 24);
  u8g.drawLine(110, 25, 126, 25);
  u8g.drawLine(110, 26, 126, 26);
  u8g.drawLine(109, 27, 126, 27);
  u8g.drawLine(109, 28, 126, 28);
  u8g.drawLine(108, 29, 126, 29);
  u8g.drawLine(107, 30, 126, 30);
  u8g.drawLine(106, 31, 126, 31);
  u8g.drawLine(105, 32, 126, 32);
  u8g.drawLine(104, 33, 126, 33);
  u8g.drawLine(102, 34, 126, 34);
  u8g.drawLine(101, 35, 126, 35);
  u8g.drawLine(101, 36, 126, 36);
  u8g.drawLine(101, 37, 126, 37);
  u8g.drawLine(101, 38, 126, 38);
  u8g.drawLine(101, 39, 126, 39);
  u8g.drawLine(101, 40, 126, 40);
  u8g.drawLine(101, 41, 126, 41);
  u8g.drawLine(100, 42, 126, 42);
  u8g.drawLine(100, 43, 126, 43);
  u8g.drawLine(100, 44, 126, 44);

}
void Anormal() {
  u8g.drawFrame(43, 0, 84, 63);

  u8g.setFont(u8g_font_6x10);
  u8g.drawStr( 55, 10, "A");
  u8g.drawStr( 110, 10, "B");
  u8g.drawStr( 82, 62, "C");

  u8g.drawCircle(95, 20, 15);
  u8g.drawCircle(85, 38, 15);

  u8g.drawDisc(75, 20, 15);

  u8g.setFont(u8g_font_10x20);
  u8g.drawStr( 115, 60, "U");
}
void Bnormal() {
  u8g.drawFrame(43, 0, 84, 63);

  u8g.setFont(u8g_font_6x10);
  u8g.drawStr( 55, 10, "A");
  u8g.drawStr( 110, 10, "B");
  u8g.drawStr( 82, 62, "C");

  u8g.drawCircle(75, 20, 15);
  u8g.drawCircle(85, 38, 15);

  u8g.drawDisc(95, 20, 15);

  u8g.setFont(u8g_font_10x20);
  u8g.drawStr( 115, 60, "U");
}
void Cnormal() {
  u8g.drawFrame(43, 0, 84, 63);

  u8g.setFont(u8g_font_6x10);
  u8g.drawStr( 55, 10, "A");
  u8g.drawStr( 110, 10, "B");
  u8g.drawStr( 82, 62, "C");

  u8g.drawCircle(75, 20, 15);
  u8g.drawCircle(95, 20, 15);

  u8g.drawDisc(85, 38, 15);

  u8g.setFont(u8g_font_10x20);
  u8g.drawStr( 115, 60, "U");
}
void A_in_B() {
  u8g.drawFrame(43, 0, 84, 63);

  u8g.setFont(u8g_font_6x10);
  u8g.drawStr( 55, 10, "A");
  u8g.drawStr( 110, 10, "B");
  u8g.drawStr( 82, 62, "C");

  u8g.drawCircle(75, 20, 15);
  u8g.drawCircle(95, 20, 15);
  u8g.drawCircle(85, 38, 15);

  u8g.setFont(u8g_font_10x20);
  u8g.drawStr( 115, 60, "U");

  u8g.drawLine(85, 10, 86, 10);
  u8g.drawLine(84, 11, 87, 11);
  u8g.drawLine(83, 12, 88, 12);
  u8g.drawLine(82, 13, 89, 13);
  u8g.drawLine(82, 14, 89, 14);
  u8g.drawLine(81, 15, 89, 15);
  u8g.drawLine(81, 16, 89, 16);
  u8g.drawLine(80, 17, 90, 17);
  u8g.drawLine(80, 18, 90, 18);
  u8g.drawLine(80, 19, 90, 19);
  u8g.drawLine(80, 20, 90, 20);
  u8g.drawLine(80, 21, 90, 21);
  u8g.drawLine(80, 22, 90, 22);
  u8g.drawLine(80, 23, 90, 23);
  u8g.drawLine(81, 24, 89, 24);
  u8g.drawLine(82, 25, 88, 25);
  u8g.drawLine(82, 26, 88, 26);
  u8g.drawLine(83, 27, 87, 27);
  u8g.drawLine(83, 28, 87, 28);
  u8g.drawLine(84, 29, 86, 29);
  u8g.drawLine(85, 30, 86, 30);
}

void A_in_C() {
  u8g.drawFrame(43, 0, 84, 63);

  u8g.setFont(u8g_font_6x10);
  u8g.drawStr( 55, 10, "A");
  u8g.drawStr( 110, 10, "B");
  u8g.drawStr( 82, 62, "C");

  u8g.drawCircle(75, 20, 15);
  u8g.drawCircle(95, 20, 15);
  u8g.drawCircle(85, 38, 15);

  u8g.setFont(u8g_font_10x20);
  u8g.drawStr( 115, 60, "U");

  u8g.drawLine(80, 24, 88, 24);
  u8g.drawLine(79, 25, 88, 25);
  u8g.drawLine(77, 26, 88, 26);
  u8g.drawLine(76, 27, 87, 27);
  u8g.drawLine(75, 28, 87, 28);
  u8g.drawLine(74, 29, 86, 29);
  u8g.drawLine(73, 30, 85, 30);
  u8g.drawLine(73, 31, 84, 31);
  u8g.drawLine(72, 32, 83, 32);
  u8g.drawLine(72, 33, 82, 33);
  u8g.drawLine(71, 34, 81, 34);
}
void B_in_C() {
  u8g.drawFrame(43, 0, 84, 63);

  u8g.setFont(u8g_font_6x10);
  u8g.drawStr( 55, 10, "A");
  u8g.drawStr( 110, 10, "B");
  u8g.drawStr( 82, 62, "C");

  u8g.drawCircle(75, 20, 15);
  u8g.drawCircle(95, 20, 15);
  u8g.drawCircle(85, 38, 15);

  u8g.setFont(u8g_font_10x20);
  u8g.drawStr( 115, 60, "U");

  u8g.drawLine(81, 24, 90, 24);
  u8g.drawLine(82, 25, 91, 25);
  u8g.drawLine(82, 26, 94, 26);
  u8g.drawLine(82, 27, 95, 27);
  u8g.drawLine(83, 28, 96, 28);
  u8g.drawLine(83, 29, 97, 29);
  u8g.drawLine(84, 30, 98, 30);
  u8g.drawLine(85, 31, 99, 31);
  u8g.drawLine(86, 32, 99, 32);
  u8g.drawLine(87, 33, 99, 33);
  u8g.drawLine(88, 34, 99, 34);
}

void A_in_B_in_C() {
  u8g.drawFrame(43, 0, 84, 63);

  u8g.setFont(u8g_font_6x10);
  u8g.drawStr( 55, 10, "A");
  u8g.drawStr( 110, 10, "B");
  u8g.drawStr( 82, 62, "C");

  u8g.drawCircle(75, 20, 15);
  u8g.drawCircle(95, 20, 15);
  u8g.drawCircle(85, 38, 15);

  u8g.setFont(u8g_font_10x20);
  u8g.drawStr( 115, 60, "U");

  u8g.drawLine(81, 24, 88, 24);
  u8g.drawLine(82, 25, 88, 25);
  u8g.drawLine(82, 26, 88, 26);
  u8g.drawLine(83, 27, 87, 27);
  u8g.drawLine(83, 28, 87, 28);
  u8g.drawLine(84, 29, 86, 29);
  u8g.drawLine(85, 30, 85, 30);
}
void A_U_B() {
  u8g.drawFrame(43, 0, 84, 63);

  u8g.setFont(u8g_font_6x10);
  u8g.drawStr( 55, 10, "A");
  u8g.drawStr( 110, 10, "B");
  u8g.drawStr( 82, 62, "C");

  u8g.drawDisc(75, 20, 15);
  u8g.drawDisc(95, 20, 15);
  u8g.drawCircle(85, 38, 15);

  u8g.setFont(u8g_font_10x20);
  u8g.drawStr( 115, 60, "U");
}
void A_U_C() {
  u8g.drawFrame(43, 0, 84, 63);

  u8g.setFont(u8g_font_6x10);
  u8g.drawStr( 55, 10, "A");
  u8g.drawStr( 110, 10, "B");
  u8g.drawStr( 82, 62, "C");

  u8g.drawDisc(75, 20, 15);
  u8g.drawCircle(95, 20, 15);
  u8g.drawDisc(85, 38, 15);

  u8g.setFont(u8g_font_10x20);
  u8g.drawStr( 115, 60, "U");
}
void B_U_C() {
  u8g.drawFrame(43, 0, 84, 63);

  u8g.setFont(u8g_font_6x10);
  u8g.drawStr( 55, 10, "A");
  u8g.drawStr( 110, 10, "B");
  u8g.drawStr( 82, 62, "C");

  u8g.drawCircle(75, 20, 15);
  u8g.drawDisc(95, 20, 15);
  u8g.drawDisc(85, 38, 15);

  u8g.setFont(u8g_font_10x20);
  u8g.drawStr( 115, 60, "U");
}
void A_U_B_U_C() {
  u8g.drawFrame(43, 0, 84, 63);

  u8g.setFont(u8g_font_6x10);
  u8g.drawStr( 55, 10, "A");
  u8g.drawStr( 110, 10, "B");
  u8g.drawStr( 82, 62, "C");

  u8g.drawDisc(75, 20, 15);
  u8g.drawDisc(95, 20, 15);
  u8g.drawDisc(85, 38, 15);

  u8g.setFont(u8g_font_10x20);
  u8g.drawStr( 115, 60, "U");
}

void A_sub_B() {
  u8g.drawFrame(43, 0, 84, 63);

  u8g.setFont(u8g_font_6x10);
  u8g.drawStr( 55, 10, "A");
  u8g.drawStr( 110, 10, "B");
  u8g.drawStr( 82, 62, "C");

  u8g.drawCircle(75, 20, 15);
  u8g.drawCircle(95, 20, 15);
  u8g.drawCircle(85, 38, 15);

  u8g.setFont(u8g_font_10x20);
  u8g.drawStr( 115, 60, "U");

  u8g.drawLine(70, 6, 80, 6);
  u8g.drawLine(69, 7, 81, 7);
  u8g.drawLine(67, 8, 83, 8);
  u8g.drawLine(66, 9, 84, 9);
  u8g.drawLine(65, 10, 83, 10);
  u8g.drawLine(64, 11, 82, 11);
  u8g.drawLine(63, 12, 81, 12);
  u8g.drawLine(63, 13, 81, 13);
  u8g.drawLine(62, 14, 80, 14);
  u8g.drawLine(62, 15, 80, 15);
  u8g.drawLine(61, 16, 80, 16);
  u8g.drawLine(61, 17, 79, 17);
  u8g.drawLine(61, 18, 79, 18);
  u8g.drawLine(61, 19, 79, 19);
  u8g.drawLine(61, 20, 79, 20);
  u8g.drawLine(61, 21, 79, 21);
  u8g.drawLine(61, 22, 79, 22);
  u8g.drawLine(61, 23, 79, 23);
  u8g.drawLine(62, 24, 80, 24);
  u8g.drawLine(62, 25, 80, 25);
  u8g.drawLine(62, 26, 80, 26);
  u8g.drawLine(63, 27, 81, 27);
  u8g.drawLine(63, 28, 81, 28);
  u8g.drawLine(64, 29, 82, 29);
  u8g.drawLine(65, 30, 83, 30);
  u8g.drawLine(66, 31, 84, 31);
  u8g.drawLine(67, 32, 83, 32);
  u8g.drawLine(69, 33, 81, 33);
  u8g.drawLine(71, 34, 79, 34);
}
void B_sub_A() {
  u8g.drawFrame(43, 0, 84, 63);

  u8g.setFont(u8g_font_6x10);
  u8g.drawStr( 55, 10, "A");
  u8g.drawStr( 110, 10, "B");
  u8g.drawStr( 82, 62, "C");

  u8g.drawCircle(75, 20, 15);
  u8g.drawCircle(95, 20, 15);
  u8g.drawCircle(85, 38, 15);

  u8g.setFont(u8g_font_10x20);
  u8g.drawStr( 115, 60, "U");

  u8g.drawLine(90, 6, 100, 6);
  u8g.drawLine(89, 7, 101, 7);
  u8g.drawLine(87, 8, 103, 8);
  u8g.drawLine(86, 9, 104, 9);
  u8g.drawLine(87, 10, 105, 10);
  u8g.drawLine(88, 11, 106, 11);
  u8g.drawLine(89, 12, 107, 12);
  u8g.drawLine(89, 13, 107, 13);
  u8g.drawLine(90, 14, 108, 14);
  u8g.drawLine(90, 15, 108, 15);
  u8g.drawLine(90, 16, 108, 16);
  u8g.drawLine(91, 17, 109, 17);
  u8g.drawLine(91, 18, 109, 18);
  u8g.drawLine(91, 19, 109, 19);
  u8g.drawLine(91, 20, 109, 20);
  u8g.drawLine(91, 21, 109, 21);
  u8g.drawLine(91, 22, 109, 22);
  u8g.drawLine(91, 23, 109, 23);
  u8g.drawLine(90, 24, 108, 24);
  u8g.drawLine(90, 25, 108, 25);
  u8g.drawLine(90, 26, 108, 26);
  u8g.drawLine(89, 27, 107, 27);
  u8g.drawLine(89, 28, 107, 28);
  u8g.drawLine(88, 29, 106, 29);
  u8g.drawLine(86, 30, 105, 30);
  u8g.drawLine(86, 31, 104, 31);
  u8g.drawLine(87, 32, 103, 32);
  u8g.drawLine(89, 33, 101, 33);
  u8g.drawLine(91, 34, 99, 34);
}
void A_sub_C() {
  u8g.drawFrame(43, 0, 84, 63);

  u8g.setFont(u8g_font_6x10);
  u8g.drawStr( 55, 10, "A");
  u8g.drawStr( 110, 10, "B");
  u8g.drawStr( 82, 62, "C");

  u8g.drawCircle(75, 20, 15);
  u8g.drawCircle(95, 20, 15);
  u8g.drawCircle(85, 38, 15);

  u8g.setFont(u8g_font_10x20);
  u8g.drawStr( 115, 60, "U");

  u8g.drawLine(70, 6, 80, 6);
  u8g.drawLine(69, 7, 81, 7);
  u8g.drawLine(67, 8, 83, 8);
  u8g.drawLine(66, 9, 84, 9);
  u8g.drawLine(65, 10, 85, 10);
  u8g.drawLine(64, 11, 86, 11);
  u8g.drawLine(63, 12, 87, 12);
  u8g.drawLine(63, 13, 87, 13);
  u8g.drawLine(62, 14, 88, 14);
  u8g.drawLine(62, 15, 88, 15);
  u8g.drawLine(62, 16, 88, 16);
  u8g.drawLine(61, 17, 89, 17);
  u8g.drawLine(61, 18, 89, 18);
  u8g.drawLine(61, 19, 89, 19);
  u8g.drawLine(61, 20, 89, 20);
  u8g.drawLine(61, 21, 89, 21);
  u8g.drawLine(61, 22, 89, 22);
  u8g.drawLine(61, 23, 89, 23);
  u8g.drawLine(62, 24, 78, 24);
  u8g.drawLine(62, 25, 76, 25);
  u8g.drawLine(62, 26, 75, 26);
  u8g.drawLine(63, 27, 74, 27);
  u8g.drawLine(63, 28, 73, 28);
  u8g.drawLine(64, 29, 72, 29);
  u8g.drawLine(65, 30, 71, 30);
  u8g.drawLine(66, 31, 71, 31);
  u8g.drawLine(67, 32, 70, 32);
  u8g.drawLine(69, 33, 70, 33);
}
void C_sub_A() {
  u8g.drawFrame(43, 0, 84, 63);

  u8g.setFont(u8g_font_6x10);
  u8g.drawStr( 55, 10, "A");
  u8g.drawStr( 110, 10, "B");
  u8g.drawStr( 82, 62, "C");

  u8g.drawCircle(75, 20, 15);
  u8g.drawCircle(95, 20, 15);
  u8g.drawCircle(85, 38, 15);

  u8g.setFont(u8g_font_10x20);
  u8g.drawStr( 115, 60, "U");

  u8g.drawLine(90, 25, 93, 25);
  u8g.drawLine(90, 26, 93, 26);
  u8g.drawLine(89, 27, 94, 27);
  u8g.drawLine(89, 28, 95, 28);
  u8g.drawLine(88, 29, 96, 29);
  u8g.drawLine(87, 30, 97, 30);
  u8g.drawLine(86, 31, 97, 31);
  u8g.drawLine(85, 32, 98, 32);
  u8g.drawLine(84, 33, 98, 33);
  u8g.drawLine(82, 34, 99, 34);
  u8g.drawLine(70, 35, 99, 35);
  u8g.drawLine(70, 36, 99, 36);
  u8g.drawLine(70, 37, 99, 37);
  u8g.drawLine(70, 38, 99, 38);
  u8g.drawLine(70, 39, 99, 39);
  u8g.drawLine(70, 40, 99, 40);
  u8g.drawLine(70, 41, 99, 41);
  u8g.drawLine(71, 42, 98, 42);
  u8g.drawLine(71, 43, 98, 43);
  u8g.drawLine(71, 44, 98, 44);
  u8g.drawLine(72, 45, 97, 45);
  u8g.drawLine(72, 46, 97, 46);
  u8g.drawLine(73, 47, 96, 47);
  u8g.drawLine(74, 48, 95, 48);
  u8g.drawLine(75, 49, 94, 49);
  u8g.drawLine(76, 50, 93, 50);
  u8g.drawLine(78, 51, 91, 51);
  u8g.drawLine(80, 52, 89, 52);
}
void B_sub_C() {
  u8g.drawFrame(43, 0, 84, 63);

  u8g.setFont(u8g_font_6x10);
  u8g.drawStr( 55, 10, "A");
  u8g.drawStr( 110, 10, "B");
  u8g.drawStr( 82, 62, "C");

  u8g.drawCircle(75, 20, 15);
  u8g.drawCircle(95, 20, 15);
  u8g.drawCircle(85, 38, 15);

  u8g.setFont(u8g_font_10x20);
  u8g.drawStr( 115, 60, "U");

  u8g.drawLine(90, 6, 100, 6);
  u8g.drawLine(89, 7, 101, 7);
  u8g.drawLine(87, 8, 103, 8);
  u8g.drawLine(86, 9, 104, 9);
  u8g.drawLine(85, 10, 105, 10);
  u8g.drawLine(84, 11, 106, 11);
  u8g.drawLine(83, 12, 107, 12);
  u8g.drawLine(83, 13, 107, 13);
  u8g.drawLine(82, 14, 108, 14);
  u8g.drawLine(82, 15, 108, 15);
  u8g.drawLine(82, 16, 108, 16);
  u8g.drawLine(81, 17, 109, 17);
  u8g.drawLine(81, 18, 109, 18);
  u8g.drawLine(81, 19, 109, 19);
  u8g.drawLine(81, 20, 109, 20);
  u8g.drawLine(81, 21, 109, 21);
  u8g.drawLine(81, 22, 109, 22);
  u8g.drawLine(81, 23, 109, 23);
  u8g.drawLine(92, 24, 108, 24);
  u8g.drawLine(94, 25, 108, 25);
  u8g.drawLine(95, 26, 108, 26);
  u8g.drawLine(96, 27, 107, 27);
  u8g.drawLine(97, 28, 107, 28);
  u8g.drawLine(98, 29, 106, 29);
  u8g.drawLine(99, 30, 105, 30);
  u8g.drawLine(99, 31, 104, 31);
  u8g.drawLine(100, 32, 103, 32);
  u8g.drawLine(100, 33, 101, 33);
}
void C_sub_B() {
  u8g.drawFrame(43, 0, 84, 63);

  u8g.setFont(u8g_font_6x10);
  u8g.drawStr( 55, 10, "A");
  u8g.drawStr( 110, 10, "B");
  u8g.drawStr( 82, 62, "C");

  u8g.drawCircle(75, 20, 15);
  u8g.drawCircle(95, 20, 15);
  u8g.drawCircle(85, 38, 15);

  u8g.setFont(u8g_font_10x20);
  u8g.drawStr( 115, 60, "U");

  u8g.drawLine(78, 25, 80, 25);
  u8g.drawLine(76, 26, 80, 26);
  u8g.drawLine(75, 27, 81, 27);
  u8g.drawLine(74, 28, 81, 28);
  u8g.drawLine(73, 29, 82, 29);
  u8g.drawLine(72, 30, 83, 30);
  u8g.drawLine(72, 31, 84, 31);
  u8g.drawLine(71, 32, 85, 32);
  u8g.drawLine(71, 33, 86, 33);
  u8g.drawLine(71, 34, 88, 34);
  u8g.drawLine(70, 35, 99, 35);
  u8g.drawLine(70, 36, 99, 36);
  u8g.drawLine(70, 37, 99, 37);
  u8g.drawLine(70, 38, 99, 38);
  u8g.drawLine(70, 39, 99, 39);
  u8g.drawLine(70, 40, 99, 40);
  u8g.drawLine(70, 41, 99, 41);
  u8g.drawLine(71, 42, 98, 42);
  u8g.drawLine(71, 43, 98, 43);
  u8g.drawLine(71, 44, 98, 44);
  u8g.drawLine(72, 45, 97, 45);
  u8g.drawLine(72, 46, 97, 46);
  u8g.drawLine(73, 47, 96, 47);
  u8g.drawLine(74, 48, 95, 48);
  u8g.drawLine(75, 49, 94, 49);
  u8g.drawLine(76, 50, 93, 50);
  u8g.drawLine(78, 51, 91, 51);
  u8g.drawLine(80, 52, 89, 52);
}
void A_sub_B_sub_C() {
  u8g.drawFrame(43, 0, 84, 63);

  u8g.setFont(u8g_font_6x10);
  u8g.drawStr( 55, 10, "A");
  u8g.drawStr( 110, 10, "B");
  u8g.drawStr( 82, 62, "C");

  u8g.drawCircle(75, 20, 15);
  u8g.drawCircle(95, 20, 15);
  u8g.drawCircle(85, 38, 15);

  u8g.setFont(u8g_font_10x20);
  u8g.drawStr( 115, 60, "U");

  u8g.drawLine(70, 6, 80, 6);
  u8g.drawLine(69, 7, 81, 7);
  u8g.drawLine(67, 8, 83, 8);
  u8g.drawLine(66, 9, 84, 9);
  u8g.drawLine(65, 10, 83, 10);
  u8g.drawLine(64, 11, 82, 11);
  u8g.drawLine(63, 12, 81, 12);
  u8g.drawLine(63, 13, 81, 13);
  u8g.drawLine(62, 14, 80, 14);
  u8g.drawLine(62, 15, 80, 15);
  u8g.drawLine(61, 16, 80, 16);
  u8g.drawLine(61, 17, 79, 17);
  u8g.drawLine(61, 18, 79, 18);
  u8g.drawLine(61, 19, 79, 19);
  u8g.drawLine(61, 20, 79, 20);
  u8g.drawLine(61, 21, 79, 21);
  u8g.drawLine(61, 22, 79, 22);
  u8g.drawLine(61, 23, 79, 23);
  u8g.drawLine(62, 24, 78, 24);
  u8g.drawLine(62, 25, 76, 25);
  u8g.drawLine(62, 26, 75, 26);
  u8g.drawLine(63, 27, 74, 27);
  u8g.drawLine(63, 28, 73, 28);
  u8g.drawLine(64, 29, 72, 29);
  u8g.drawLine(65, 30, 71, 30);
  u8g.drawLine(66, 31, 71, 31);
  u8g.drawLine(67, 32, 70, 32);
  u8g.drawLine(69, 33, 70, 33);
}
void B_sub_A_sub_C() {
  u8g.drawFrame(43, 0, 84, 63);

  u8g.setFont(u8g_font_6x10);
  u8g.drawStr( 55, 10, "A");
  u8g.drawStr( 110, 10, "B");
  u8g.drawStr( 82, 62, "C");

  u8g.drawCircle(75, 20, 15);
  u8g.drawCircle(95, 20, 15);
  u8g.drawCircle(85, 38, 15);

  u8g.setFont(u8g_font_10x20);
  u8g.drawStr( 115, 60, "U");

  u8g.drawLine(90, 6, 100, 6);
  u8g.drawLine(89, 7, 101, 7);
  u8g.drawLine(87, 8, 103, 8);
  u8g.drawLine(86, 9, 104, 9);
  u8g.drawLine(87, 10, 105, 10);
  u8g.drawLine(88, 11, 106, 11);
  u8g.drawLine(89, 12, 107, 12);
  u8g.drawLine(89, 13, 107, 13);
  u8g.drawLine(90, 14, 108, 14);
  u8g.drawLine(90, 15, 108, 15);
  u8g.drawLine(90, 16, 108, 16);
  u8g.drawLine(91, 17, 109, 17);
  u8g.drawLine(91, 18, 109, 18);
  u8g.drawLine(91, 19, 109, 19);
  u8g.drawLine(91, 20, 109, 20);
  u8g.drawLine(91, 21, 109, 21);
  u8g.drawLine(91, 22, 109, 22);
  u8g.drawLine(91, 23, 109, 23);
  u8g.drawLine(92, 24, 108, 24);
  u8g.drawLine(94, 25, 108, 25);
  u8g.drawLine(95, 26, 108, 26);
  u8g.drawLine(96, 27, 107, 27);
  u8g.drawLine(97, 28, 107, 28);
  u8g.drawLine(98, 29, 106, 29);
  u8g.drawLine(99, 30, 105, 30);
  u8g.drawLine(99, 31, 104, 31);
  u8g.drawLine(100, 32, 103, 32);
  u8g.drawLine(100, 33, 101, 33);
}
void C_sub_A_sub_B() {
  u8g.drawFrame(43, 0, 84, 63);

  u8g.setFont(u8g_font_6x10);
  u8g.drawStr( 55, 10, "A");
  u8g.drawStr( 110, 10, "B");
  u8g.drawStr( 82, 62, "C");

  u8g.drawCircle(75, 20, 15);
  u8g.drawCircle(95, 20, 15);
  u8g.drawCircle(85, 38, 15);

  u8g.setFont(u8g_font_10x20);
  u8g.drawStr( 115, 60, "U");

  u8g.drawLine(85, 32, 86, 32);
  u8g.drawLine(84, 33, 86, 33);
  u8g.drawLine(82, 34, 88, 34);
  u8g.drawLine(70, 35, 99, 35);
  u8g.drawLine(70, 36, 99, 36);
  u8g.drawLine(70, 37, 99, 37);
  u8g.drawLine(70, 38, 99, 38);
  u8g.drawLine(70, 39, 99, 39);
  u8g.drawLine(70, 40, 99, 40);
  u8g.drawLine(70, 41, 99, 41);
  u8g.drawLine(71, 42, 98, 42);
  u8g.drawLine(71, 43, 98, 43);
  u8g.drawLine(71, 44, 98, 44);
  u8g.drawLine(72, 45, 97, 45);
  u8g.drawLine(72, 46, 97, 46);
  u8g.drawLine(73, 47, 96, 47);
  u8g.drawLine(74, 48, 95, 48);
  u8g.drawLine(75, 49, 94, 49);
  u8g.drawLine(76, 50, 93, 50);
  u8g.drawLine(78, 51, 91, 51);
  u8g.drawLine(80, 52, 89, 52);
}
void A_com() {

  u8g.setFont(u8g_font_6x10);
  u8g.drawStr( 73, 23, "A");

  u8g.drawCircle(75, 20, 15);

  u8g.drawBox(43, 0, 85, 6);
  u8g.drawBox(90, 14, 65, 13);
  u8g.drawBox(43, 14, 18, 13);

  u8g.drawLine(43, 6, 70, 6);   u8g.drawLine(80, 6, 127, 6);
  u8g.drawLine(43, 7, 67, 7);   u8g.drawLine(82, 7, 127, 7);
  u8g.drawLine(43, 8, 66, 8);   u8g.drawLine(84, 8, 127, 8);
  u8g.drawLine(43, 9, 65, 9);   u8g.drawLine(85, 9, 127, 9);
  u8g.drawLine(43, 10, 64, 10);   u8g.drawLine(86, 10, 127, 10);
  u8g.drawLine(43, 11, 63, 11);   u8g.drawLine(87, 11, 127, 11);
  u8g.drawLine(43, 12, 62, 12);   u8g.drawLine(88, 12, 127, 12);
  u8g.drawLine(43, 13, 62, 13);   u8g.drawLine(88, 13, 127, 13);

  u8g.drawLine(43, 27, 62, 27);   u8g.drawLine(89, 27, 127, 27);
  u8g.drawLine(43, 28, 62, 28);   u8g.drawLine(89, 28, 127, 28);
  u8g.drawLine(43, 29, 63, 29);   u8g.drawLine(88, 29, 127, 29);
  u8g.drawLine(43, 30, 64, 30);   u8g.drawLine(87, 30, 127, 30);
  u8g.drawLine(43, 31, 65, 31);   u8g.drawLine(86, 31, 127, 31);
  u8g.drawLine(43, 32, 66, 32);   u8g.drawLine(85, 32, 127, 32);
  u8g.drawLine(43, 33, 67, 33);   u8g.drawLine(84, 33, 127, 33);
  u8g.drawLine(43, 34, 69, 34);   u8g.drawLine(82, 34, 127, 34);
  u8g.drawBox(43, 35, 127, 63);
}
void B_com() {

  u8g.setFont(u8g_font_6x10);
  u8g.drawStr( 93, 23, "B");

  u8g.drawBox(43, 0, 85, 6);
  u8g.drawBox(110, 14, 18, 13);
  u8g.drawBox(43, 14, 38, 13);

  u8g.drawCircle(95, 20, 15);

  u8g.drawLine(43, 6, 88, 6);   u8g.drawLine(102, 6, 127, 6);
  u8g.drawLine(43, 7, 86, 7);   u8g.drawLine(104, 7, 127, 7);
  u8g.drawLine(43, 8, 85, 8);   u8g.drawLine(105, 8, 127, 8);
  u8g.drawLine(43, 9, 84, 9);   u8g.drawLine(106, 9, 127, 9);
  u8g.drawLine(43, 10, 83, 10);   u8g.drawLine(107, 10, 127, 10);
  u8g.drawLine(43, 11, 82, 11);   u8g.drawLine(108, 11, 127, 11);
  u8g.drawLine(43, 12, 81, 12);   u8g.drawLine(109, 12, 127, 12);
  u8g.drawLine(43, 13, 81, 13);   u8g.drawLine(109, 13, 127, 13);

  u8g.drawLine(43, 27, 81, 27);   u8g.drawLine(109, 27, 127, 27);
  u8g.drawLine(43, 28, 81, 28);   u8g.drawLine(109, 28, 127, 28);
  u8g.drawLine(43, 29, 82, 29);   u8g.drawLine(108, 29, 127, 29);
  u8g.drawLine(43, 30, 83, 30);   u8g.drawLine(107, 30, 127, 30);
  u8g.drawLine(43, 31, 84, 31);   u8g.drawLine(106, 31, 127, 31);
  u8g.drawLine(43, 32, 85, 32);   u8g.drawLine(105, 32, 127, 32);
  u8g.drawLine(43, 33, 86, 33);   u8g.drawLine(104, 33, 127, 33);
  u8g.drawLine(43, 34, 88, 34);   u8g.drawLine(102, 34, 127, 34);
  u8g.drawBox(43, 35, 127, 63);
}
void C_com() {

  u8g.setFont(u8g_font_6x10);
  u8g.drawStr( 83, 42, "C");

  u8g.drawCircle(85, 38, 15);

  u8g.drawBox(43, 1, 127, 23);
  u8g.drawBox(43, 53, 127, 10);
  u8g.drawBox(100, 32, 57, 13);
  u8g.drawBox(43, 32, 28, 13);

  u8g.drawLine(43, 24, 78, 24);   u8g.drawLine(92, 24, 127, 24);
  u8g.drawLine(43, 25, 77, 25);   u8g.drawLine(94, 25, 127, 25);
  u8g.drawLine(43, 26, 76, 26);   u8g.drawLine(95, 26, 127, 26);
  u8g.drawLine(43, 27, 75, 27);   u8g.drawLine(96, 27, 127, 27);
  u8g.drawLine(43, 28, 74, 28);   u8g.drawLine(96, 28, 127, 28);
  u8g.drawLine(43, 29, 73, 29);   u8g.drawLine(97, 29, 127, 29);
  u8g.drawLine(43, 30, 72, 30);   u8g.drawLine(98, 30, 127, 30);
  u8g.drawLine(43, 31, 71, 31);   u8g.drawLine(99, 31, 127, 31);

  u8g.drawLine(43, 45, 71, 45);   u8g.drawLine(99, 45, 127, 45);
  u8g.drawLine(43, 46, 71, 46);   u8g.drawLine(98, 46, 127, 46);
  u8g.drawLine(43, 47, 72, 47);   u8g.drawLine(97, 47, 127, 47);
  u8g.drawLine(43, 48, 73, 48);   u8g.drawLine(96, 48, 127, 48);
  u8g.drawLine(43, 49, 74, 49);   u8g.drawLine(95, 49, 127, 49);
  u8g.drawLine(43, 50, 75, 50);   u8g.drawLine(94, 50, 127, 50);
  u8g.drawLine(43, 51, 76, 51);   u8g.drawLine(93, 51, 127, 51);
  u8g.drawLine(43, 52, 78, 52);   u8g.drawLine(92, 52, 127, 52);
}
void A_com_in_B() {
  u8g.drawFrame(43, 0, 84, 63);

  u8g.setFont(u8g_font_6x10);
  u8g.drawStr( 55, 10, "A");
  u8g.drawStr( 110, 10, "B");
  u8g.drawStr( 82, 62, "C");

  u8g.drawCircle(75, 20, 15);
  u8g.drawCircle(95, 20, 15);
  u8g.drawCircle(85, 38, 15);

  u8g.setFont(u8g_font_10x20);
  u8g.drawStr( 115, 60, "U");

  u8g.drawLine(90, 6, 100, 6);
  u8g.drawLine(89, 7, 101, 7);
  u8g.drawLine(87, 8, 103, 8);
  u8g.drawLine(86, 9, 104, 9);
  u8g.drawLine(87, 10, 105, 10);
  u8g.drawLine(88, 11, 106, 11);
  u8g.drawLine(89, 12, 107, 12);
  u8g.drawLine(89, 13, 107, 13);
  u8g.drawLine(90, 14, 108, 14);
  u8g.drawLine(90, 15, 108, 15);
  u8g.drawLine(90, 16, 108, 16);
  u8g.drawLine(91, 17, 109, 17);
  u8g.drawLine(91, 18, 109, 18);
  u8g.drawLine(91, 19, 109, 19);
  u8g.drawLine(91, 20, 109, 20);
  u8g.drawLine(91, 21, 109, 21);
  u8g.drawLine(91, 22, 109, 22);
  u8g.drawLine(91, 23, 109, 23);
  u8g.drawLine(90, 24, 108, 24);
  u8g.drawLine(90, 25, 108, 25);
  u8g.drawLine(90, 26, 108, 26);
  u8g.drawLine(89, 27, 107, 27);
  u8g.drawLine(89, 28, 107, 28);
  u8g.drawLine(88, 29, 106, 29);
  u8g.drawLine(86, 30, 105, 30);
  u8g.drawLine(86, 31, 104, 31);
  u8g.drawLine(87, 32, 103, 32);
  u8g.drawLine(89, 33, 101, 33);
  u8g.drawLine(91, 34, 99, 34);
}
void A_com_in_C() {
  u8g.drawFrame(43, 0, 84, 63);

  u8g.setFont(u8g_font_6x10);
  u8g.drawStr( 55, 10, "A");
  u8g.drawStr( 110, 10, "B");
  u8g.drawStr( 82, 62, "C");

  u8g.drawCircle(75, 20, 15);
  u8g.drawCircle(95, 20, 15);
  u8g.drawCircle(85, 38, 15);

  u8g.setFont(u8g_font_10x20);
  u8g.drawStr( 115, 60, "U");

  u8g.drawLine(90, 25, 93, 25);
  u8g.drawLine(90, 26, 93, 26);
  u8g.drawLine(89, 27, 94, 27);
  u8g.drawLine(89, 28, 95, 28);
  u8g.drawLine(88, 29, 96, 29);
  u8g.drawLine(87, 30, 97, 30);
  u8g.drawLine(86, 31, 97, 31);
  u8g.drawLine(85, 32, 98, 32);
  u8g.drawLine(84, 33, 98, 33);
  u8g.drawLine(82, 34, 99, 34);
  u8g.drawLine(70, 35, 99, 35);
  u8g.drawLine(70, 36, 99, 36);
  u8g.drawLine(70, 37, 99, 37);
  u8g.drawLine(70, 38, 99, 38);
  u8g.drawLine(70, 39, 99, 39);
  u8g.drawLine(70, 40, 99, 40);
  u8g.drawLine(70, 41, 99, 41);
  u8g.drawLine(71, 42, 98, 42);
  u8g.drawLine(71, 43, 98, 43);
  u8g.drawLine(71, 44, 98, 44);
  u8g.drawLine(72, 45, 97, 45);
  u8g.drawLine(72, 46, 97, 46);
  u8g.drawLine(73, 47, 96, 47);
  u8g.drawLine(74, 48, 95, 48);
  u8g.drawLine(75, 49, 94, 49);
  u8g.drawLine(76, 50, 93, 50);
  u8g.drawLine(78, 51, 91, 51);
  u8g.drawLine(80, 52, 89, 52);
}
void B_com_in_A() {
  u8g.drawFrame(43, 0, 84, 63);

  u8g.setFont(u8g_font_6x10);
  u8g.drawStr( 55, 10, "A");
  u8g.drawStr( 110, 10, "B");
  u8g.drawStr( 82, 62, "C");

  u8g.drawCircle(75, 20, 15);
  u8g.drawCircle(95, 20, 15);
  u8g.drawCircle(85, 38, 15);

  u8g.setFont(u8g_font_10x20);
  u8g.drawStr( 115, 60, "U");

  u8g.drawLine(70, 6, 80, 6);
  u8g.drawLine(69, 7, 81, 7);
  u8g.drawLine(67, 8, 83, 8);
  u8g.drawLine(66, 9, 84, 9);
  u8g.drawLine(65, 10, 83, 10);
  u8g.drawLine(64, 11, 82, 11);
  u8g.drawLine(63, 12, 81, 12);
  u8g.drawLine(63, 13, 81, 13);
  u8g.drawLine(62, 14, 80, 14);
  u8g.drawLine(62, 15, 80, 15);
  u8g.drawLine(61, 16, 80, 16);
  u8g.drawLine(61, 17, 79, 17);
  u8g.drawLine(61, 18, 79, 18);
  u8g.drawLine(61, 19, 79, 19);
  u8g.drawLine(61, 20, 79, 20);
  u8g.drawLine(61, 21, 79, 21);
  u8g.drawLine(61, 22, 79, 22);
  u8g.drawLine(61, 23, 79, 23);
  u8g.drawLine(62, 24, 80, 24);
  u8g.drawLine(62, 25, 80, 25);
  u8g.drawLine(62, 26, 80, 26);
  u8g.drawLine(63, 27, 81, 27);
  u8g.drawLine(63, 28, 81, 28);
  u8g.drawLine(64, 29, 82, 29);
  u8g.drawLine(65, 30, 83, 30);
  u8g.drawLine(66, 31, 84, 31);
  u8g.drawLine(67, 32, 83, 32);
  u8g.drawLine(69, 33, 81, 33);
  u8g.drawLine(71, 34, 79, 34);
}
void B_com_in_C() {
  u8g.drawFrame(43, 0, 84, 63);

  u8g.setFont(u8g_font_6x10);
  u8g.drawStr( 55, 10, "A");
  u8g.drawStr( 110, 10, "B");
  u8g.drawStr( 82, 62, "C");

  u8g.drawCircle(75, 20, 15);
  u8g.drawCircle(95, 20, 15);
  u8g.drawCircle(85, 38, 15);

  u8g.setFont(u8g_font_10x20);
  u8g.drawStr( 115, 60, "U");

  u8g.drawLine(78, 25, 80, 25);
  u8g.drawLine(76, 26, 80, 26);
  u8g.drawLine(75, 27, 81, 27);
  u8g.drawLine(74, 28, 81, 28);
  u8g.drawLine(73, 29, 82, 29);
  u8g.drawLine(72, 30, 83, 30);
  u8g.drawLine(72, 31, 84, 31);
  u8g.drawLine(71, 32, 85, 32);
  u8g.drawLine(71, 33, 86, 33);
  u8g.drawLine(71, 34, 88, 34);
  u8g.drawLine(70, 35, 99, 35);
  u8g.drawLine(70, 36, 99, 36);
  u8g.drawLine(70, 37, 99, 37);
  u8g.drawLine(70, 38, 99, 38);
  u8g.drawLine(70, 39, 99, 39);
  u8g.drawLine(70, 40, 99, 40);
  u8g.drawLine(70, 41, 99, 41);
  u8g.drawLine(71, 42, 98, 42);
  u8g.drawLine(71, 43, 98, 43);
  u8g.drawLine(71, 44, 98, 44);
  u8g.drawLine(72, 45, 97, 45);
  u8g.drawLine(72, 46, 97, 46);
  u8g.drawLine(73, 47, 96, 47);
  u8g.drawLine(74, 48, 95, 48);
  u8g.drawLine(75, 49, 94, 49);
  u8g.drawLine(76, 50, 93, 50);
  u8g.drawLine(78, 51, 91, 51);
  u8g.drawLine(80, 52, 89, 52);
}
void C_com_in_B() {
  u8g.drawFrame(43, 0, 84, 63);

  u8g.setFont(u8g_font_6x10);
  u8g.drawStr( 55, 10, "A");
  u8g.drawStr( 110, 10, "B");
  u8g.drawStr( 82, 62, "C");

  u8g.drawCircle(75, 20, 15);
  u8g.drawCircle(95, 20, 15);
  u8g.drawCircle(85, 38, 15);

  u8g.setFont(u8g_font_10x20);
  u8g.drawStr( 115, 60, "U");

  u8g.drawLine(90, 6, 100, 6);
  u8g.drawLine(89, 7, 101, 7);
  u8g.drawLine(87, 8, 103, 8);
  u8g.drawLine(86, 9, 104, 9);
  u8g.drawLine(85, 10, 105, 10);
  u8g.drawLine(84, 11, 106, 11);
  u8g.drawLine(83, 12, 107, 12);
  u8g.drawLine(83, 13, 107, 13);
  u8g.drawLine(82, 14, 108, 14);
  u8g.drawLine(82, 15, 108, 15);
  u8g.drawLine(82, 16, 108, 16);
  u8g.drawLine(81, 17, 109, 17);
  u8g.drawLine(81, 18, 109, 18);
  u8g.drawLine(81, 19, 109, 19);
  u8g.drawLine(81, 20, 109, 20);
  u8g.drawLine(81, 21, 109, 21);
  u8g.drawLine(81, 22, 109, 22);
  u8g.drawLine(81, 23, 109, 23);
  u8g.drawLine(92, 24, 108, 24);
  u8g.drawLine(94, 25, 108, 25);
  u8g.drawLine(95, 26, 108, 26);
  u8g.drawLine(96, 27, 107, 27);
  u8g.drawLine(97, 28, 107, 28);
  u8g.drawLine(98, 29, 106, 29);
  u8g.drawLine(99, 30, 105, 30);
  u8g.drawLine(99, 31, 104, 31);
  u8g.drawLine(100, 32, 103, 32);
  u8g.drawLine(100, 33, 101, 33);
}
void C_com_in_A() {
  u8g.drawFrame(43, 0, 84, 63);

  u8g.setFont(u8g_font_6x10);
  u8g.drawStr( 55, 10, "A");
  u8g.drawStr( 110, 10, "B");
  u8g.drawStr( 82, 62, "C");

  u8g.drawCircle(75, 20, 15);
  u8g.drawCircle(95, 20, 15);
  u8g.drawCircle(85, 38, 15);

  u8g.setFont(u8g_font_10x20);
  u8g.drawStr( 115, 60, "U");

  u8g.drawLine(70, 6, 80, 6);
  u8g.drawLine(69, 7, 81, 7);
  u8g.drawLine(67, 8, 83, 8);
  u8g.drawLine(66, 9, 84, 9);
  u8g.drawLine(65, 10, 85, 10);
  u8g.drawLine(64, 11, 86, 11);
  u8g.drawLine(63, 12, 87, 12);
  u8g.drawLine(63, 13, 87, 13);
  u8g.drawLine(62, 14, 88, 14);
  u8g.drawLine(62, 15, 88, 15);
  u8g.drawLine(62, 16, 88, 16);
  u8g.drawLine(61, 17, 89, 17);
  u8g.drawLine(61, 18, 89, 18);
  u8g.drawLine(61, 19, 89, 19);
  u8g.drawLine(61, 20, 89, 20);
  u8g.drawLine(61, 21, 89, 21);
  u8g.drawLine(61, 22, 89, 22);
  u8g.drawLine(61, 23, 89, 23);
  u8g.drawLine(62, 24, 78, 24);
  u8g.drawLine(62, 25, 76, 25);
  u8g.drawLine(62, 26, 75, 26);
  u8g.drawLine(63, 27, 74, 27);
  u8g.drawLine(63, 28, 73, 28);
  u8g.drawLine(64, 29, 72, 29);
  u8g.drawLine(65, 30, 71, 30);
  u8g.drawLine(66, 31, 71, 31);
  u8g.drawLine(67, 32, 70, 32);
  u8g.drawLine(69, 33, 70, 33);
}
void A_com_in_B_com() {

  u8g.setFont(u8g_font_6x10);
  u8g.drawStr( 73, 23, "A");
  u8g.drawStr( 93, 23, "B");

  u8g.drawCircle(75, 20, 15);
  u8g.drawCircle(95, 20, 15);

  u8g.drawBox(43, 0, 85, 6);

  u8g.drawLine(43, 6, 68, 6);        u8g.drawLine(80, 6, 88, 6);         u8g.drawLine(102, 6, 127, 6);
  u8g.drawLine(43, 7, 66, 7);        u8g.drawLine(82, 7, 86, 7);         u8g.drawLine(104, 7, 127, 7);
  u8g.drawLine(43, 8, 65, 8);        u8g.drawLine(84, 8, 85, 8);         u8g.drawLine(105, 8, 127, 8);
  u8g.drawLine(43, 9, 64, 9);                                            u8g.drawLine(106, 9, 127, 9);
  u8g.drawLine(43, 10, 63, 10);                                          u8g.drawLine(107, 10, 127, 10);
  u8g.drawLine(43, 11, 62, 11);                                          u8g.drawLine(108, 11, 127, 11);
  u8g.drawLine(43, 12, 61, 12);                                          u8g.drawLine(109, 12, 127, 12);
  u8g.drawLine(43, 13, 61, 13);                                          u8g.drawLine(109, 13, 127, 13);
  u8g.drawLine(43, 14, 60, 14);                                          u8g.drawLine(110, 14, 127, 14);
  u8g.drawLine(43, 15, 60, 15);                                          u8g.drawLine(110, 15, 127, 15);
  u8g.drawLine(43, 16, 60, 16);                                          u8g.drawLine(110, 16, 127, 16);

  u8g.drawBox(43, 17, 17, 7);                                            u8g.drawBox(111, 17, 17, 7);

  u8g.drawLine(43, 23, 60, 23);                                          u8g.drawLine(111, 23, 127, 23);
  u8g.drawLine(43, 24, 60, 24);                                          u8g.drawLine(110, 24, 127, 24);
  u8g.drawLine(43, 25, 60, 25);                                          u8g.drawLine(110, 25, 127, 25);
  u8g.drawLine(43, 26, 61, 26);                                          u8g.drawLine(110, 26, 127, 26);
  u8g.drawLine(43, 27, 61, 27);                                          u8g.drawLine(109, 27, 127, 27);
  u8g.drawLine(43, 28, 61, 28);                                          u8g.drawLine(109, 28, 127, 28);
  u8g.drawLine(43, 29, 62, 29);                                          u8g.drawLine(108, 29, 127, 29);
  u8g.drawLine(43, 30, 63, 30);                                          u8g.drawLine(107, 30, 127, 30);
  u8g.drawLine(43, 31, 64, 31);                                          u8g.drawLine(106, 31, 127, 31);
  u8g.drawLine(43, 32, 65, 32);      u8g.drawLine(84, 32, 85, 32);          u8g.drawLine(105, 32, 127, 32);
  u8g.drawLine(43, 33, 66, 33);      u8g.drawLine(82, 33, 86, 33);         u8g.drawLine(104, 33, 127, 33);
  u8g.drawLine(43, 34, 68, 34);      u8g.drawLine(80, 34, 88, 34);         u8g.drawLine(102, 34, 127, 34);

  u8g.drawBox(43, 35, 87, 36);
}
void A_com_in_C_com() {

  u8g.setFont(u8g_font_6x10);
  u8g.drawStr( 73, 23, "A");
  u8g.drawStr( 83, 42, "C");

  u8g.drawCircle(75, 20, 15);
  u8g.drawCircle(85, 38, 15);

  u8g.drawBox(43, 0, 85, 6);

  u8g.drawLine(43, 6, 68, 6);       u8g.drawLine(80, 6, 127, 6);
  u8g.drawLine(43, 7, 66, 7);       u8g.drawLine(82, 7, 127, 7);
  u8g.drawLine(43, 8, 65, 8);       u8g.drawLine(84, 8, 127, 8);
  u8g.drawLine(43, 9, 64, 9);       u8g.drawLine(85, 9, 127, 9);
  u8g.drawLine(43, 10, 63, 10);     u8g.drawLine(86, 10, 127, 10);
  u8g.drawLine(43, 11, 62, 11);     u8g.drawLine(87, 11, 127, 11);
  u8g.drawLine(43, 12, 61, 12);     u8g.drawLine(88, 12, 127, 12);
  u8g.drawLine(43, 13, 61, 13);     u8g.drawLine(89, 13, 127, 13);
  u8g.drawLine(43, 14, 60, 14);     u8g.drawLine(90, 14, 127, 14);
  u8g.drawLine(43, 15, 60, 15);     u8g.drawLine(90, 15, 127, 15);
  u8g.drawLine(43, 16, 60, 16);     u8g.drawLine(90, 16, 127, 16);

  u8g.drawBox(43, 17, 17, 7);       u8g.drawBox(90, 17, 38, 7);

  u8g.drawLine(43, 24, 61, 24);     u8g.drawLine(91, 24, 127, 24);
  u8g.drawLine(43, 25, 61, 25);     u8g.drawLine(93, 25, 127, 25);
  u8g.drawLine(43, 26, 61, 26);     u8g.drawLine(94, 26, 127, 26);
  u8g.drawLine(43, 27, 62, 27);     u8g.drawLine(95, 27, 127, 27);
  u8g.drawLine(43, 28, 62, 28);     u8g.drawLine(96, 28, 127, 28);
  u8g.drawLine(43, 29, 63, 29);     u8g.drawLine(97, 29, 127, 29);
  u8g.drawLine(43, 30, 64, 30);     u8g.drawLine(98, 30, 127, 30);
  u8g.drawLine(43, 31, 65, 31);     u8g.drawLine(98, 31, 127, 31);
  u8g.drawLine(43, 32, 66, 32);     u8g.drawLine(99, 32, 127, 32);
  u8g.drawLine(43, 33, 68, 33);     u8g.drawLine(99, 33, 127, 33);
  u8g.drawLine(43, 34, 69, 34);     u8g.drawLine(99, 34, 127, 34);
  u8g.drawLine(43, 35, 74, 35);

  u8g.drawBox(43, 35, 28, 7);       u8g.drawBox(100, 35, 28, 7);

  u8g.drawLine(43, 42, 71, 42);        u8g.drawLine(99, 42, 127, 42);
  u8g.drawLine(43, 43, 71, 43);        u8g.drawLine(99, 43, 127, 43);
  u8g.drawLine(43, 44, 71, 44);        u8g.drawLine(99, 44, 127, 44);
  u8g.drawLine(43, 45, 72, 45);        u8g.drawLine(98, 45, 127, 45);
  u8g.drawLine(43, 46, 72, 46);        u8g.drawLine(98, 46, 127, 46);
  u8g.drawLine(43, 47, 73, 47);        u8g.drawLine(97, 47, 127, 47);
  u8g.drawLine(43, 48, 74, 48);        u8g.drawLine(96, 48, 127, 48);
  u8g.drawLine(43, 49, 75, 49);        u8g.drawLine(95, 49, 127, 49);
  u8g.drawLine(43, 50, 76, 50);        u8g.drawLine(94, 50, 127, 50);
  u8g.drawLine(43, 51, 78, 51);        u8g.drawLine(92, 51, 127, 51);
  u8g.drawLine(43, 52, 81, 52);        u8g.drawLine(88, 52, 127, 52);

  u8g.drawBox(43, 53, 85, 15);
}
void B_com_in_C_com() {
  u8g.setFont(u8g_font_6x10);
  u8g.drawStr( 93, 23, "B");
  u8g.drawStr( 83, 42, "C");

  u8g.drawCircle(95, 20, 15);
  u8g.drawCircle(85, 38, 15);

  u8g.drawBox(43, 0, 85, 6);

  u8g.drawLine(43, 6, 90, 6);
  u8g.drawLine(43, 7, 88, 7);
  u8g.drawLine(43, 8, 86, 8);
  u8g.drawLine(43, 9, 85, 9);
  u8g.drawLine(43, 10, 84, 10);
  u8g.drawLine(43, 11, 83, 11);
  u8g.drawLine(43, 12, 82, 12);
  u8g.drawLine(43, 13, 82, 13);
  u8g.drawLine(43, 14, 81, 14);
  u8g.drawLine(43, 15, 81, 15);
  u8g.drawLine(43, 16, 81, 16);
  u8g.drawLine(102, 6, 127, 6);
  u8g.drawLine(104, 7, 127, 7);
  u8g.drawLine(105, 8, 127, 8);
  u8g.drawLine(106, 9, 127, 9);
  u8g.drawLine(107, 10, 127, 10);
  u8g.drawLine(108, 11, 127, 11);
  u8g.drawLine(109, 12, 127, 12);
  u8g.drawLine(109, 13, 127, 13);
  u8g.drawLine(110, 14, 127, 14);
  u8g.drawLine(110, 15, 127, 15);
  u8g.drawLine(110, 16, 127, 16);

  u8g.drawBox(43, 17, 38, 7);       u8g.drawBox(111, 17, 17, 7);

  u8g.drawLine(43, 24, 78, 24);        u8g.drawLine(110, 24, 127, 24);
  u8g.drawLine(43, 25, 77, 25);        u8g.drawLine(110, 25, 127, 25);
  u8g.drawLine(43, 26, 76, 26);        u8g.drawLine(109, 26, 127, 26);
  u8g.drawLine(43, 27, 75, 27);        u8g.drawLine(109, 27, 127, 27);
  u8g.drawLine(43, 28, 74, 28);        u8g.drawLine(108, 28, 127, 28);
  u8g.drawLine(43, 29, 73, 29);        u8g.drawLine(107, 29, 127, 29);
  u8g.drawLine(43, 30, 72, 30);        u8g.drawLine(106, 30, 127, 30);
  u8g.drawLine(43, 31, 72, 31);        u8g.drawLine(105, 31, 127, 31);
  u8g.drawLine(43, 32, 71, 32);        u8g.drawLine(104, 32, 127, 32);
  u8g.drawLine(43, 33, 71, 33);        u8g.drawLine(102, 33, 127, 33);
  u8g.drawLine(43, 34, 71, 34);        u8g.drawLine(100, 34, 127, 34);

  u8g.drawBox(43, 35, 28, 7);       u8g.drawBox(100, 35, 28, 7);

  u8g.drawLine(43, 42, 71, 42);        u8g.drawLine(99, 42, 127, 42);
  u8g.drawLine(43, 43, 71, 43);        u8g.drawLine(99, 43, 127, 43);
  u8g.drawLine(43, 44, 71, 44);        u8g.drawLine(99, 44, 127, 44);
  u8g.drawLine(43, 45, 72, 45);        u8g.drawLine(98, 45, 127, 45);
  u8g.drawLine(43, 46, 72, 46);        u8g.drawLine(98, 46, 127, 46);
  u8g.drawLine(43, 47, 73, 47);        u8g.drawLine(97, 47, 127, 47);
  u8g.drawLine(43, 48, 74, 48);        u8g.drawLine(96, 48, 127, 48);
  u8g.drawLine(43, 49, 75, 49);        u8g.drawLine(95, 49, 127, 49);
  u8g.drawLine(43, 50, 76, 50);        u8g.drawLine(94, 50, 127, 50);
  u8g.drawLine(43, 51, 78, 51);        u8g.drawLine(92, 51, 127, 51);
  u8g.drawLine(43, 52, 81, 52);        u8g.drawLine(88, 52, 127, 52);

  u8g.drawBox(43, 53, 85, 15);
}
void A_com_in_B_in_C() {
  u8g.drawFrame(43, 0, 84, 63);

  u8g.setFont(u8g_font_6x10);
  u8g.drawStr( 55, 10, "A");
  u8g.drawStr( 110, 10, "B");
  u8g.drawStr( 82, 62, "C");

  u8g.drawCircle(75, 20, 15);
  u8g.drawCircle(95, 20, 15);
  u8g.drawCircle(85, 38, 15);

  u8g.setFont(u8g_font_10x20);
  u8g.drawStr( 115, 60, "U");

  u8g.drawLine(89, 25, 91, 25);
  u8g.drawLine(89, 26, 94, 26);
  u8g.drawLine(89, 27, 95, 27);
  u8g.drawLine(89, 28, 96, 28);
  u8g.drawLine(88, 29, 97, 29);
  u8g.drawLine(87, 30, 98, 30);
  u8g.drawLine(86, 31, 99, 31);
  u8g.drawLine(86, 32, 99, 32);
  u8g.drawLine(87, 33, 99, 33);
  u8g.drawLine(88, 34, 99, 34);
}
void B_com_in_A_in_C() {
  u8g.drawFrame(43, 0, 84, 63);

  u8g.setFont(u8g_font_6x10);
  u8g.drawStr( 55, 10, "A");
  u8g.drawStr( 110, 10, "B");
  u8g.drawStr( 82, 62, "C");

  u8g.drawCircle(75, 20, 15);
  u8g.drawCircle(95, 20, 15);
  u8g.drawCircle(85, 38, 15);

  u8g.setFont(u8g_font_10x20);
  u8g.drawStr( 115, 60, "U");

  u8g.drawLine(79, 25, 80, 25);
  u8g.drawLine(77, 26, 80, 26);
  u8g.drawLine(76, 27, 81, 27);
  u8g.drawLine(75, 28, 81, 28);
  u8g.drawLine(74, 29, 82, 29);
  u8g.drawLine(73, 30, 83, 30);
  u8g.drawLine(73, 31, 84, 31);
  u8g.drawLine(72, 32, 83, 32);
  u8g.drawLine(72, 33, 82, 33);
  u8g.drawLine(71, 34, 81, 34);
}
void C_com_in_A_in_B() {
  u8g.drawFrame(43, 0, 84, 63);

  u8g.setFont(u8g_font_6x10);
  u8g.drawStr( 55, 10, "A");
  u8g.drawStr( 110, 10, "B");
  u8g.drawStr( 82, 62, "C");

  u8g.drawCircle(75, 20, 15);
  u8g.drawCircle(95, 20, 15);
  u8g.drawCircle(85, 38, 15);

  u8g.setFont(u8g_font_10x20);
  u8g.drawStr( 115, 60, "U");

  u8g.drawLine(85, 10, 86, 10);
  u8g.drawLine(84, 11, 87, 11);
  u8g.drawLine(83, 12, 88, 12);
  u8g.drawLine(82, 13, 89, 13);
  u8g.drawLine(82, 14, 89, 14);
  u8g.drawLine(81, 15, 89, 15);
  u8g.drawLine(81, 16, 89, 16);
  u8g.drawLine(80, 17, 90, 17);
  u8g.drawLine(80, 18, 90, 18);
  u8g.drawLine(80, 19, 90, 19);
  u8g.drawLine(80, 20, 90, 20);
  u8g.drawLine(80, 21, 90, 21);
  u8g.drawLine(80, 22, 90, 22);
  u8g.drawLine(80, 23, 90, 23);
}
void A_com_in_B_com_in_C() {
  u8g.drawFrame(43, 0, 84, 63);

  u8g.setFont(u8g_font_6x10);
  u8g.drawStr( 55, 10, "A");
  u8g.drawStr( 110, 10, "B");
  u8g.drawStr( 82, 62, "C");

  u8g.drawCircle(75, 20, 15);
  u8g.drawCircle(95, 20, 15);
  u8g.drawCircle(85, 38, 15);

  u8g.setFont(u8g_font_10x20);
  u8g.drawStr( 115, 60, "U");

  u8g.drawLine(85, 32, 86, 32);
  u8g.drawLine(84, 33, 86, 33);
  u8g.drawLine(82, 34, 88, 34);
  u8g.drawLine(70, 35, 99, 35);
  u8g.drawLine(70, 36, 99, 36);
  u8g.drawLine(70, 37, 99, 37);
  u8g.drawLine(70, 38, 99, 38);
  u8g.drawLine(70, 39, 99, 39);
  u8g.drawLine(70, 40, 99, 40);
  u8g.drawLine(70, 41, 99, 41);
  u8g.drawLine(71, 42, 98, 42);
  u8g.drawLine(71, 43, 98, 43);
  u8g.drawLine(71, 44, 98, 44);
  u8g.drawLine(72, 45, 97, 45);
  u8g.drawLine(72, 46, 97, 46);
  u8g.drawLine(73, 47, 96, 47);
  u8g.drawLine(74, 48, 95, 48);
  u8g.drawLine(75, 49, 94, 49);
  u8g.drawLine(76, 50, 93, 50);
  u8g.drawLine(78, 51, 91, 51);
  u8g.drawLine(80, 52, 89, 52);
}
void A_com_in_B_in_C_com() {
  u8g.drawFrame(43, 0, 84, 63);

  u8g.setFont(u8g_font_6x10);
  u8g.drawStr( 55, 10, "A");
  u8g.drawStr( 110, 10, "B");
  u8g.drawStr( 82, 62, "C");

  u8g.drawCircle(75, 20, 15);
  u8g.drawCircle(95, 20, 15);
  u8g.drawCircle(85, 38, 15);

  u8g.setFont(u8g_font_10x20);
  u8g.drawStr( 115, 60, "U");

  u8g.drawLine(90, 6, 100, 6);
  u8g.drawLine(89, 7, 101, 7);
  u8g.drawLine(87, 8, 103, 8);
  u8g.drawLine(86, 9, 104, 9);
  u8g.drawLine(87, 10, 105, 10);
  u8g.drawLine(88, 11, 106, 11);
  u8g.drawLine(89, 12, 107, 12);
  u8g.drawLine(89, 13, 107, 13);
  u8g.drawLine(90, 14, 108, 14);
  u8g.drawLine(90, 15, 108, 15);
  u8g.drawLine(90, 16, 108, 16);
  u8g.drawLine(91, 17, 109, 17);
  u8g.drawLine(91, 18, 109, 18);
  u8g.drawLine(91, 19, 109, 19);
  u8g.drawLine(91, 20, 109, 20);
  u8g.drawLine(91, 21, 109, 21);
  u8g.drawLine(91, 22, 109, 22);
  u8g.drawLine(91, 23, 109, 23);
  u8g.drawLine(92, 24, 108, 24);
  u8g.drawLine(94, 25, 108, 25);
  u8g.drawLine(95, 26, 108, 26);
  u8g.drawLine(96, 27, 107, 27);
  u8g.drawLine(97, 28, 107, 28);
  u8g.drawLine(98, 29, 106, 29);
  u8g.drawLine(99, 30, 105, 30);
  u8g.drawLine(99, 31, 104, 31);
  u8g.drawLine(100, 32, 103, 32);
  u8g.drawLine(100, 33, 101, 33);
}
void A_com_in_B_com_in_C_com() {

  u8g.drawBox(43, 0, 127, 6);
  u8g.drawBox(43, 53, 127, 63);
  u8g.drawLine(43, 6, 68, 6);
  u8g.drawLine(43, 7, 66, 7);
  u8g.drawLine(43, 8, 65, 8);
  u8g.drawLine(43, 9, 64, 9);
  u8g.drawLine(43, 10, 63, 10);
  u8g.drawLine(43, 11, 62, 11);
  u8g.drawLine(43, 12, 61, 12);
  u8g.drawLine(43, 13, 61, 13);
  u8g.drawLine(43, 14, 60, 14);
  u8g.drawLine(43, 15, 60, 15);
  u8g.drawLine(43, 16, 60, 16);
  u8g.drawLine(43, 17, 59, 17);
  u8g.drawLine(43, 18, 59, 18);
  u8g.drawLine(43, 19, 59, 19);
  u8g.drawLine(43, 20, 59, 20);
  u8g.drawLine(43, 21, 59, 21);
  u8g.drawLine(43, 22, 59, 22);
  u8g.drawLine(43, 23, 60, 23);
  u8g.drawLine(43, 24, 60, 24);
  u8g.drawLine(43, 25, 60, 25);
  u8g.drawLine(43, 26, 61, 26);
  u8g.drawLine(43, 27, 61, 27);
  u8g.drawLine(43, 28, 61, 28);
  u8g.drawLine(43, 29, 62, 29);
  u8g.drawLine(43, 30, 63, 30);
  u8g.drawLine(43, 31, 64, 31);
  u8g.drawLine(43, 32, 65, 32);
  u8g.drawLine(43, 33, 66, 33);
  u8g.drawLine(43, 34, 68, 34);
  u8g.drawLine(43, 35, 69, 35);
  u8g.drawLine(43, 36, 69, 36);
  u8g.drawLine(43, 37, 69, 37);
  u8g.drawLine(43, 38, 69, 38);
  u8g.drawLine(43, 39, 69, 39);
  u8g.drawLine(43, 40, 69, 40);
  u8g.drawLine(43, 41, 69, 41);
  u8g.drawLine(43, 42, 70, 42);
  u8g.drawLine(43, 43, 70, 43);
  u8g.drawLine(43, 44, 70, 44);
  u8g.drawLine(43, 45, 71, 45);
  u8g.drawLine(43, 46, 71, 46);
  u8g.drawLine(43, 47, 72, 47);
  u8g.drawLine(43, 48, 73, 48);
  u8g.drawLine(43, 49, 74, 49);
  u8g.drawLine(43, 50, 75, 50);
  u8g.drawLine(43, 51, 76, 51);
  u8g.drawLine(43, 52, 78, 52);
  u8g.drawLine(80, 6, 88, 6);
  u8g.drawLine(82, 7, 86, 7);
  u8g.drawLine(84, 8, 85, 8);
  u8g.drawLine(92, 52, 127, 52);
  u8g.drawLine(94, 51, 127, 51);
  u8g.drawLine(95, 50, 127, 50);
  u8g.drawLine(96, 49, 127, 49);
  u8g.drawLine(97, 48, 127, 48);
  u8g.drawLine(97, 47, 127, 47);
  u8g.drawLine(98, 46, 127, 46);
  u8g.drawLine(98, 45, 127, 45);
  u8g.drawLine(102, 6, 127, 6);
  u8g.drawLine(104, 7, 127, 7);
  u8g.drawLine(105, 8, 127, 8);
  u8g.drawLine(106, 9, 127, 9);
  u8g.drawLine(107, 10, 127, 10);
  u8g.drawLine(108, 11, 127, 11);
  u8g.drawLine(109, 12, 127, 12);
  u8g.drawLine(109, 13, 127, 13);
  u8g.drawLine(110, 14, 127, 14);
  u8g.drawLine(110, 15, 127, 15);
  u8g.drawLine(110, 16, 127, 16);
  u8g.drawLine(111, 17, 127, 17);
  u8g.drawLine(111, 18, 127, 18);
  u8g.drawLine(111, 19, 127, 19);
  u8g.drawLine(111, 20, 127, 20);
  u8g.drawLine(111, 21, 127, 21);
  u8g.drawLine(111, 22, 127, 22);
  u8g.drawLine(111, 23, 127, 23);
  u8g.drawLine(110, 24, 127, 24);
  u8g.drawLine(110, 25, 127, 25);
  u8g.drawLine(110, 26, 127, 26);
  u8g.drawLine(109, 27, 127, 27);
  u8g.drawLine(109, 28, 127, 28);
  u8g.drawLine(108, 29, 127, 29);
  u8g.drawLine(107, 30, 127, 30);
  u8g.drawLine(106, 31, 127, 31);
  u8g.drawLine(105, 32, 127, 32);
  u8g.drawLine(104, 33, 127, 33);
  u8g.drawLine(102, 34, 127, 34);
  u8g.drawLine(101, 35, 127, 35);
  u8g.drawLine(101, 36, 127, 36);
  u8g.drawLine(101, 37, 127, 37);
  u8g.drawLine(101, 38, 127, 38);
  u8g.drawLine(101, 39, 127, 39);
  u8g.drawLine(101, 40, 127, 40);
  u8g.drawLine(101, 41, 127, 41);
  u8g.drawLine(100, 42, 127, 42);
  u8g.drawLine(100, 43, 127, 43);
  u8g.drawLine(100, 44, 127, 44);

  u8g.drawCircle(75, 20, 15);
  u8g.drawCircle(95, 20, 15);
  u8g.drawCircle(85, 38, 15);
}
void A_com_U_B() {

  u8g.setFont(u8g_font_6x10);
  u8g.drawStr( 73, 23, "A");

  u8g.drawCircle(75, 20, 15);
  u8g.drawDisc(95, 20, 15);

  u8g.drawBox(43, 0, 126, 6);

  u8g.drawLine(43, 6, 70, 6);   u8g.drawLine(80, 6, 127, 6);
  u8g.drawLine(43, 7, 67, 7);   u8g.drawLine(82, 7, 127, 7);
  u8g.drawLine(43, 8, 66, 8);   u8g.drawLine(84, 8, 127, 8);
  u8g.drawLine(43, 9, 65, 9);   u8g.drawLine(85, 9, 127, 9);
  u8g.drawLine(43, 10, 64, 10);   u8g.drawLine(86, 10, 127, 10);
  u8g.drawLine(43, 11, 63, 11);   u8g.drawLine(87, 11, 127, 11);
  u8g.drawLine(43, 12, 62, 12);   u8g.drawLine(88, 12, 127, 12);
  u8g.drawLine(43, 13, 62, 13);   u8g.drawLine(88, 13, 127, 13);
  u8g.drawLine(43, 14, 61, 14);   u8g.drawLine(89, 14, 127, 14);
  u8g.drawLine(43, 15, 61, 15);   u8g.drawLine(89, 15, 127, 15);
  u8g.drawLine(43, 16, 61, 16);   u8g.drawLine(89, 16, 127, 16);
  u8g.drawLine(43, 17, 60, 17);   u8g.drawLine(90, 17, 127, 17);
  u8g.drawLine(43, 18, 60, 18);   u8g.drawLine(90, 18, 127, 18);
  u8g.drawLine(43, 19, 60, 19);   u8g.drawLine(90, 19, 127, 19);
  u8g.drawLine(43, 20, 60, 20);   u8g.drawLine(90, 20, 127, 20);
  u8g.drawLine(43, 21, 60, 21);   u8g.drawLine(90, 21, 127, 21);
  u8g.drawLine(43, 22, 60, 22);   u8g.drawLine(90, 22, 127, 22);
  u8g.drawLine(43, 23, 60, 23);   u8g.drawLine(90, 23, 127, 23);
  u8g.drawLine(43, 24, 61, 24);   u8g.drawLine(90, 24, 127, 24);
  u8g.drawLine(43, 25, 61, 25);   u8g.drawLine(90, 25, 127, 25);
  u8g.drawLine(43, 26, 61, 26);   u8g.drawLine(90, 26, 127, 26);
  u8g.drawLine(43, 27, 62, 27);   u8g.drawLine(89, 27, 127, 27);
  u8g.drawLine(43, 28, 62, 28);   u8g.drawLine(89, 28, 127, 28);
  u8g.drawLine(43, 29, 63, 29);   u8g.drawLine(88, 29, 127, 29);
  u8g.drawLine(43, 30, 64, 30);   u8g.drawLine(87, 30, 127, 30);
  u8g.drawLine(43, 31, 65, 31);   u8g.drawLine(86, 31, 127, 31);
  u8g.drawLine(43, 32, 66, 32);   u8g.drawLine(85, 32, 127, 32);
  u8g.drawLine(43, 33, 67, 33);   u8g.drawLine(84, 33, 127, 33);
  u8g.drawLine(43, 34, 69, 34);   u8g.drawLine(82, 34, 127, 34);
  u8g.drawBox(43, 35, 127, 63);
}
void A_com_U_C() {

  u8g.setFont(u8g_font_6x10);
  u8g.drawStr( 73, 23, "A");

  u8g.drawCircle(75, 20, 15);
  u8g.drawDisc(85, 38, 15);

  u8g.drawBox(43, 0, 85, 6);

  u8g.drawLine(43, 6, 70, 6);   u8g.drawLine(80, 6, 127, 6);
  u8g.drawLine(43, 7, 67, 7);   u8g.drawLine(82, 7, 127, 7);
  u8g.drawLine(43, 8, 66, 8);   u8g.drawLine(84, 8, 127, 8);
  u8g.drawLine(43, 9, 65, 9);   u8g.drawLine(85, 9, 127, 9);
  u8g.drawLine(43, 10, 64, 10);   u8g.drawLine(86, 10, 127, 10);
  u8g.drawLine(43, 11, 63, 11);   u8g.drawLine(87, 11, 127, 11);
  u8g.drawLine(43, 12, 62, 12);   u8g.drawLine(88, 12, 127, 12);
  u8g.drawLine(43, 13, 62, 13);   u8g.drawLine(88, 13, 127, 13);
  u8g.drawLine(43, 14, 61, 14);   u8g.drawLine(89, 14, 127, 14);
  u8g.drawLine(43, 15, 61, 15);   u8g.drawLine(89, 15, 127, 15);
  u8g.drawLine(43, 16, 61, 16);   u8g.drawLine(89, 16, 127, 16);
  u8g.drawBox(43, 17, 18, 7);   u8g.drawLine(90, 17, 127, 17);
  u8g.drawLine(90, 18, 127, 18);
  u8g.drawLine(90, 19, 127, 19);
  u8g.drawLine(90, 20, 127, 20);
  u8g.drawLine(90, 21, 127, 21);
  u8g.drawLine(90, 22, 127, 22);
  u8g.drawLine(90, 23, 127, 23);
  u8g.drawLine(43, 24, 61, 24);   u8g.drawLine(90, 24, 127, 24);
  u8g.drawLine(43, 25, 61, 25);   u8g.drawLine(90, 25, 127, 25);
  u8g.drawLine(43, 26, 61, 26);   u8g.drawLine(90, 26, 127, 26);
  u8g.drawLine(43, 27, 62, 27);   u8g.drawLine(89, 27, 127, 27);
  u8g.drawLine(43, 28, 62, 28);   u8g.drawLine(89, 28, 127, 28);
  u8g.drawLine(43, 29, 63, 29);   u8g.drawLine(88, 29, 127, 29);
  u8g.drawLine(43, 30, 64, 30);   u8g.drawLine(87, 30, 127, 30);
  u8g.drawLine(43, 31, 65, 31);   u8g.drawLine(86, 31, 127, 31);
  u8g.drawLine(43, 32, 66, 32);   u8g.drawLine(85, 32, 127, 32);
  u8g.drawLine(43, 33, 67, 33);   u8g.drawLine(84, 33, 127, 33);
  u8g.drawLine(43, 34, 69, 34);   u8g.drawLine(82, 34, 127, 34);
  u8g.drawBox(43, 35, 127, 63);
}
void B_com_U_A() {

  u8g.setFont(u8g_font_6x10);
  u8g.drawStr( 93, 23, "B");

  u8g.drawDisc(75, 20, 15);
  u8g.drawCircle(95, 20, 15);

  u8g.setFont(u8g_font_10x20);
  u8g.drawStr( 115, 60, "U");

  u8g.drawBox(43, 0, 126, 6);
  u8g.drawLine(43, 6, 88, 6);   u8g.drawLine(102, 6, 127, 6);
  u8g.drawLine(43, 7, 86, 7);   u8g.drawLine(104, 7, 127, 7);
  u8g.drawLine(43, 8, 85, 8);   u8g.drawLine(105, 8, 127, 8);
  u8g.drawLine(43, 9, 84, 9);   u8g.drawLine(106, 9, 127, 9);
  u8g.drawLine(43, 10, 83, 10);   u8g.drawLine(107, 10, 127, 10);
  u8g.drawLine(43, 11, 82, 11);   u8g.drawLine(108, 11, 127, 11);
  u8g.drawLine(43, 12, 81, 12);   u8g.drawLine(109, 12, 127, 12);
  u8g.drawLine(43, 13, 81, 13);   u8g.drawLine(109, 13, 127, 13);
  u8g.drawLine(43, 14, 80, 14);   u8g.drawLine(110, 14, 127, 14);
  u8g.drawLine(43, 15, 80, 15);   u8g.drawLine(110, 15, 127, 15);
  u8g.drawLine(43, 16, 80, 16);   u8g.drawLine(110, 16, 127, 16);
  u8g.drawLine(43, 17, 79, 17);   u8g.drawLine(111, 17, 127, 17);
  u8g.drawLine(43, 18, 79, 18);   u8g.drawLine(111, 18, 127, 18);
  u8g.drawLine(43, 19, 79, 19);   u8g.drawLine(111, 19, 127, 19);
  u8g.drawLine(43, 20, 79, 20);   u8g.drawLine(111, 20, 127, 20);
  u8g.drawLine(43, 21, 79, 21);   u8g.drawLine(111, 21, 127, 21);
  u8g.drawLine(43, 22, 79, 22);   u8g.drawLine(111, 22, 127, 22);
  u8g.drawLine(43, 23, 79, 23);   u8g.drawLine(111, 23, 127, 23);
  u8g.drawLine(43, 24, 80, 24);   u8g.drawLine(110, 24, 127, 24);
  u8g.drawLine(43, 25, 80, 25);   u8g.drawLine(110, 25, 127, 25);
  u8g.drawLine(43, 26, 80, 26);   u8g.drawLine(110, 26, 127, 26);
  u8g.drawLine(43, 27, 81, 27);   u8g.drawLine(109, 27, 127, 27);
  u8g.drawLine(43, 28, 81, 28);   u8g.drawLine(109, 28, 127, 28);
  u8g.drawLine(43, 29, 82, 29);   u8g.drawLine(108, 29, 127, 29);
  u8g.drawLine(43, 30, 83, 30);   u8g.drawLine(107, 30, 127, 30);
  u8g.drawLine(43, 31, 84, 31);   u8g.drawLine(106, 31, 127, 31);
  u8g.drawLine(43, 32, 85, 32);   u8g.drawLine(105, 32, 127, 32);
  u8g.drawLine(43, 33, 86, 33);   u8g.drawLine(104, 33, 127, 33);
  u8g.drawLine(43, 34, 88, 34);   u8g.drawLine(102, 34, 127, 34);
  u8g.drawBox(43, 35, 127, 63);
}
void B_com_U_C() {

  u8g.setFont(u8g_font_6x10);
  u8g.drawStr( 93, 23, "B");

  u8g.drawCircle(95, 20, 15);
  u8g.drawDisc(85, 38, 15);

  u8g.drawBox(43, 0, 126, 6);
  u8g.drawLine(43, 6, 88, 6);   u8g.drawLine(102, 6, 127, 6);
  u8g.drawLine(43, 7, 86, 7);   u8g.drawLine(104, 7, 127, 7);
  u8g.drawLine(43, 8, 85, 8);   u8g.drawLine(105, 8, 127, 8);
  u8g.drawLine(43, 9, 84, 9);   u8g.drawLine(106, 9, 127, 9);
  u8g.drawLine(43, 10, 83, 10);   u8g.drawLine(107, 10, 127, 10);
  u8g.drawLine(43, 11, 82, 11);   u8g.drawLine(108, 11, 127, 11);
  u8g.drawLine(43, 12, 81, 12);   u8g.drawLine(109, 12, 127, 12);
  u8g.drawLine(43, 13, 81, 13);   u8g.drawLine(109, 13, 127, 13);
  u8g.drawLine(43, 14, 80, 14);   u8g.drawLine(110, 14, 127, 14);
  u8g.drawLine(43, 15, 80, 15);   u8g.drawLine(110, 15, 127, 15);
  u8g.drawLine(43, 16, 80, 16);   u8g.drawLine(110, 16, 127, 16);
  u8g.drawLine(43, 17, 79, 17);   u8g.drawLine(111, 17, 127, 17);
  u8g.drawLine(43, 18, 79, 18);   u8g.drawLine(111, 18, 127, 18);
  u8g.drawLine(43, 19, 79, 19);   u8g.drawLine(111, 19, 127, 19);
  u8g.drawLine(43, 20, 79, 20);   u8g.drawLine(111, 20, 127, 20);
  u8g.drawLine(43, 21, 79, 21);   u8g.drawLine(111, 21, 127, 21);
  u8g.drawLine(43, 22, 79, 22);   u8g.drawLine(111, 22, 127, 22);
  u8g.drawLine(43, 23, 79, 23);   u8g.drawLine(111, 23, 127, 23);
  u8g.drawLine(43, 24, 80, 24);   u8g.drawLine(110, 24, 127, 24);
  u8g.drawLine(43, 25, 80, 25);   u8g.drawLine(110, 25, 127, 25);
  u8g.drawLine(43, 26, 80, 26);   u8g.drawLine(110, 26, 127, 26);
  u8g.drawLine(43, 27, 81, 27);   u8g.drawLine(109, 27, 127, 27);
  u8g.drawLine(43, 28, 81, 28);   u8g.drawLine(109, 28, 127, 28);
  u8g.drawLine(43, 29, 82, 29);   u8g.drawLine(108, 29, 127, 29);
  u8g.drawLine(43, 30, 83, 30);   u8g.drawLine(107, 30, 127, 30);
  u8g.drawLine(43, 31, 84, 31);   u8g.drawLine(106, 31, 127, 31);
  u8g.drawLine(43, 32, 85, 32);   u8g.drawLine(105, 32, 127, 32);
  u8g.drawLine(43, 33, 86, 33);   u8g.drawLine(104, 33, 127, 33);
  u8g.drawLine(43, 34, 88, 34);   u8g.drawLine(102, 34, 127, 34);
  u8g.drawBox(44, 35, 127, 63);
}
void C_com_U_A() {

  u8g.setFont(u8g_font_6x10);
  u8g.drawStr( 83, 42, "C");

  u8g.drawDisc(75, 20, 15);
  u8g.drawCircle(85, 38, 15);

  u8g.drawBox(43, 0, 127, 24);
  u8g.drawBox(43, 53, 127, 63);
  u8g.drawBox(100, 24, 127, 52);
  u8g.drawLine(44, 24, 78, 24);   u8g.drawLine(92, 24, 100, 24);
  u8g.drawLine(44, 25, 77, 25);   u8g.drawLine(94, 25, 100, 25);
  u8g.drawLine(44, 26, 76, 26);   u8g.drawLine(95, 26, 100, 26);
  u8g.drawLine(44, 27, 75, 27);   u8g.drawLine(96, 27, 100, 27);
  u8g.drawLine(44, 28, 74, 28);   u8g.drawLine(96, 28, 100, 28);
  u8g.drawLine(44, 29, 73, 29);   u8g.drawLine(96, 29, 100, 29);
  u8g.drawLine(44, 30, 72, 30);   u8g.drawLine(98, 30, 100, 30);
  u8g.drawLine(44, 31, 71, 31);   u8g.drawLine(99, 31, 101, 31);
  u8g.drawLine(44, 32, 70, 32);
  u8g.drawLine(44, 33, 70, 33);
  u8g.drawLine(44, 34, 70, 34);
  u8g.drawLine(44, 35, 69, 35);
  u8g.drawLine(44, 36, 69, 36);
  u8g.drawLine(44, 37, 69, 37);
  u8g.drawLine(44, 38, 69, 38);
  u8g.drawLine(44, 39, 69, 39);
  u8g.drawLine(44, 40, 69, 40);
  u8g.drawLine(44, 41, 69, 41);
  u8g.drawLine(44, 42, 70, 42);
  u8g.drawLine(44, 43, 70, 43);
  u8g.drawLine(44, 44, 70, 44);
  u8g.drawLine(44, 45, 71, 45);   u8g.drawLine(99, 45, 101, 45);
  u8g.drawLine(44, 46, 71, 46);   u8g.drawLine(98, 46, 101, 46);
  u8g.drawLine(44, 47, 72, 47);   u8g.drawLine(97, 47, 101, 47);
  u8g.drawLine(44, 48, 73, 48);   u8g.drawLine(96, 48, 101, 48);
  u8g.drawLine(44, 49, 74, 49);   u8g.drawLine(95, 49, 101, 49);
  u8g.drawLine(44, 50, 75, 50);   u8g.drawLine(94, 50, 101, 50);
  u8g.drawLine(44, 51, 76, 51);   u8g.drawLine(93, 51, 101, 51);
  u8g.drawLine(44, 52, 78, 52);   u8g.drawLine(92, 52, 101, 52);
}
void C_com_U_B() {

  u8g.setFont(u8g_font_6x10);
  u8g.drawStr( 83, 42, "C");

  u8g.drawDisc(95, 20, 15);
  u8g.drawCircle(85, 38, 15);

  u8g.drawBox(43, 0, 127, 24);
  u8g.drawBox(43, 53, 127, 63);
  u8g.drawBox(100, 24, 127, 52);
  u8g.drawLine(43, 24, 78, 24);   u8g.drawLine(92, 24, 100, 24);
  u8g.drawLine(43, 25, 77, 25);   u8g.drawLine(94, 25, 100, 25);
  u8g.drawLine(43, 26, 76, 26);   u8g.drawLine(95, 26, 100, 26);
  u8g.drawLine(43, 27, 75, 27);   u8g.drawLine(96, 27, 100, 27);
  u8g.drawLine(43, 28, 74, 28);   u8g.drawLine(96, 28, 100, 28);
  u8g.drawLine(43, 29, 73, 29);   u8g.drawLine(96, 29, 100, 29);
  u8g.drawLine(43, 30, 72, 30);   u8g.drawLine(98, 30, 100, 30);
  u8g.drawLine(43, 31, 71, 31);   u8g.drawLine(99, 31, 101, 31);
  u8g.drawLine(43, 32, 70, 32);
  u8g.drawLine(43, 33, 70, 33);
  u8g.drawLine(43, 34, 70, 34);
  u8g.drawLine(43, 35, 69, 35);
  u8g.drawLine(43, 36, 69, 36);
  u8g.drawLine(43, 37, 69, 37);
  u8g.drawLine(43, 38, 69, 38);
  u8g.drawLine(43, 39, 69, 39);
  u8g.drawLine(43, 40, 69, 40);
  u8g.drawLine(43, 41, 69, 41);
  u8g.drawLine(43, 42, 70, 42);
  u8g.drawLine(43, 43, 70, 43);
  u8g.drawLine(43, 44, 70, 44);
  u8g.drawLine(43, 45, 71, 45);   u8g.drawLine(99, 45, 101, 45);
  u8g.drawLine(43, 46, 71, 46);   u8g.drawLine(98, 46, 101, 46);
  u8g.drawLine(43, 47, 72, 47);   u8g.drawLine(97, 47, 101, 47);
  u8g.drawLine(43, 48, 73, 48);   u8g.drawLine(96, 48, 101, 48);
  u8g.drawLine(43, 49, 74, 49);   u8g.drawLine(95, 49, 101, 49);
  u8g.drawLine(43, 50, 75, 50);   u8g.drawLine(94, 50, 101, 50);
  u8g.drawLine(43, 51, 76, 51);   u8g.drawLine(93, 51, 101, 51);
  u8g.drawLine(43, 52, 78, 52);   u8g.drawLine(92, 52, 101, 52);
}
void B_S() {
  u8g.drawBox(43, 0, 85, 64);
}
void A_com_U_B_U_C() {

  u8g.setFont(u8g_font_6x10);
  u8g.drawStr( 73, 23, "A");

  u8g.drawCircle(75, 20, 15);
  u8g.drawDisc(95, 20, 15);
  u8g.drawDisc(85, 38, 15);

  u8g.drawBox(43, 0, 126, 6);
  u8g.drawLine(43, 6, 70, 6);   u8g.drawLine(80, 6, 127, 6);
  u8g.drawLine(43, 7, 67, 7);   u8g.drawLine(82, 7, 127, 7);
  u8g.drawLine(43, 8, 66, 8);   u8g.drawLine(84, 8, 127, 8);
  u8g.drawLine(43, 9, 65, 9);   u8g.drawLine(85, 9, 127, 9);
  u8g.drawLine(43, 10, 64, 10);   u8g.drawLine(86, 10, 127, 10);
  u8g.drawLine(43, 11, 63, 11);   u8g.drawLine(87, 11, 127, 11);
  u8g.drawLine(43, 12, 62, 12);   u8g.drawLine(88, 12, 127, 12);
  u8g.drawLine(43, 13, 62, 13);   u8g.drawLine(88, 13, 127, 13);
  u8g.drawLine(43, 14, 61, 14);   u8g.drawLine(89, 14, 127, 14);
  u8g.drawLine(43, 15, 61, 15);   u8g.drawLine(89, 15, 127, 15);
  u8g.drawLine(43, 16, 61, 16);   u8g.drawLine(89, 16, 127, 16);
  u8g.drawLine(43, 17, 60, 17);   u8g.drawLine(90, 17, 127, 17);
  u8g.drawLine(43, 18, 60, 18);   u8g.drawLine(90, 18, 127, 18);
  u8g.drawLine(43, 19, 60, 19);   u8g.drawLine(90, 19, 127, 19);
  u8g.drawLine(43, 20, 60, 20);   u8g.drawLine(90, 20, 127, 20);
  u8g.drawLine(43, 21, 60, 21);   u8g.drawLine(90, 21, 127, 21);
  u8g.drawLine(43, 22, 60, 22);   u8g.drawLine(90, 22, 127, 22);
  u8g.drawLine(43, 23, 60, 23);   u8g.drawLine(90, 23, 127, 23);
  u8g.drawLine(43, 24, 61, 24);   u8g.drawLine(90, 24, 127, 24);
  u8g.drawLine(43, 25, 61, 25);   u8g.drawLine(90, 25, 127, 25);
  u8g.drawLine(43, 26, 61, 26);   u8g.drawLine(90, 26, 127, 26);
  u8g.drawLine(43, 27, 62, 27);   u8g.drawLine(89, 27, 127, 27);
  u8g.drawLine(43, 28, 62, 28);   u8g.drawLine(89, 28, 127, 28);
  u8g.drawLine(43, 29, 63, 29);   u8g.drawLine(88, 29, 127, 29);
  u8g.drawLine(43, 30, 64, 30);   u8g.drawLine(87, 30, 127, 30);
  u8g.drawLine(43, 31, 65, 31);   u8g.drawLine(86, 31, 127, 31);
  u8g.drawLine(43, 32, 66, 32);   u8g.drawLine(85, 32, 127, 32);
  u8g.drawLine(43, 33, 67, 33);   u8g.drawLine(84, 33, 127, 33);
  u8g.drawLine(43, 34, 69, 34);   u8g.drawLine(82, 34, 127, 34);
  u8g.drawBox(43, 35, 127, 63);
}
void B_com_U_A_U_C() {

  u8g.setFont(u8g_font_6x10);
  u8g.drawStr( 93, 23, "B");

  u8g.drawDisc(75, 20, 15);
  u8g.drawCircle(95, 20, 15);
  u8g.drawDisc(85, 38, 15);

  u8g.drawBox(43, 0, 126, 6);
  u8g.drawLine(43, 6, 88, 6);   u8g.drawLine(102, 6, 127, 6);
  u8g.drawLine(43, 7, 86, 7);   u8g.drawLine(104, 7, 127, 7);
  u8g.drawLine(43, 8, 85, 8);   u8g.drawLine(105, 8, 127, 8);
  u8g.drawLine(43, 9, 84, 9);   u8g.drawLine(106, 9, 127, 9);
  u8g.drawLine(43, 10, 83, 10);   u8g.drawLine(107, 10, 127, 10);
  u8g.drawLine(43, 11, 82, 11);   u8g.drawLine(108, 11, 127, 11);
  u8g.drawLine(43, 12, 81, 12);   u8g.drawLine(109, 12, 127, 12);
  u8g.drawLine(43, 13, 81, 13);   u8g.drawLine(109, 13, 127, 13);
  u8g.drawLine(43, 14, 80, 14);   u8g.drawLine(110, 14, 127, 14);
  u8g.drawLine(43, 15, 80, 15);   u8g.drawLine(110, 15, 127, 15);
  u8g.drawLine(43, 16, 80, 16);   u8g.drawLine(110, 16, 127, 16);
  u8g.drawLine(43, 17, 79, 17);   u8g.drawLine(111, 17, 127, 17);
  u8g.drawLine(43, 18, 79, 18);   u8g.drawLine(111, 18, 127, 18);
  u8g.drawLine(43, 19, 79, 19);   u8g.drawLine(111, 19, 127, 19);
  u8g.drawLine(43, 20, 79, 20);   u8g.drawLine(111, 20, 127, 20);
  u8g.drawLine(43, 21, 79, 21);   u8g.drawLine(111, 21, 127, 21);
  u8g.drawLine(43, 22, 79, 22);   u8g.drawLine(111, 22, 127, 22);
  u8g.drawLine(43, 23, 79, 23);   u8g.drawLine(111, 23, 127, 23);
  u8g.drawLine(43, 24, 80, 24);   u8g.drawLine(110, 24, 127, 24);
  u8g.drawLine(43, 25, 80, 25);   u8g.drawLine(110, 25, 127, 25);
  u8g.drawLine(43, 26, 80, 26);   u8g.drawLine(110, 26, 127, 26);
  u8g.drawLine(43, 27, 81, 27);   u8g.drawLine(109, 27, 127, 27);
  u8g.drawLine(43, 28, 81, 28);   u8g.drawLine(109, 28, 127, 28);
  u8g.drawLine(43, 29, 82, 29);   u8g.drawLine(108, 29, 127, 29);
  u8g.drawLine(43, 30, 83, 30);   u8g.drawLine(107, 30, 127, 30);
  u8g.drawLine(43, 31, 84, 31);   u8g.drawLine(106, 31, 127, 31);
  u8g.drawLine(43, 32, 85, 32);   u8g.drawLine(105, 32, 127, 32);
  u8g.drawLine(43, 33, 86, 33);   u8g.drawLine(104, 33, 127, 33);
  u8g.drawLine(43, 34, 88, 34);   u8g.drawLine(102, 34, 127, 34);

  u8g.drawBox(43, 35, 127, 63);
}
void C_com_U_A_U_B() {

  u8g.setFont(u8g_font_6x10);
  u8g.drawStr( 83, 42, "C");

  u8g.drawDisc(75, 20, 15);
  u8g.drawDisc(95, 20, 15);
  u8g.drawCircle(85, 38, 15);

  u8g.drawBox(43, 0, 127, 24);
  u8g.drawBox(43, 53, 127, 63);
  u8g.drawBox(100, 24, 127, 52);
  u8g.drawLine(43, 24, 78, 24);   u8g.drawLine(92, 24, 100, 24);
  u8g.drawLine(43, 25, 77, 25);   u8g.drawLine(94, 25, 100, 25);
  u8g.drawLine(43, 26, 76, 26);   u8g.drawLine(95, 26, 100, 26);
  u8g.drawLine(43, 27, 75, 27);   u8g.drawLine(96, 27, 100, 27);
  u8g.drawLine(43, 28, 74, 28);   u8g.drawLine(96, 28, 100, 28);
  u8g.drawLine(43, 29, 73, 29);   u8g.drawLine(96, 29, 100, 29);
  u8g.drawLine(43, 30, 72, 30);   u8g.drawLine(98, 30, 100, 30);
  u8g.drawLine(43, 31, 71, 31);   u8g.drawLine(99, 31, 101, 31);
  u8g.drawLine(43, 32, 70, 32);
  u8g.drawLine(43, 33, 70, 33);
  u8g.drawLine(43, 34, 70, 34);
  u8g.drawLine(43, 35, 69, 35);
  u8g.drawLine(43, 36, 69, 36);
  u8g.drawLine(43, 37, 69, 37);
  u8g.drawLine(43, 38, 69, 38);
  u8g.drawLine(43, 39, 69, 39);
  u8g.drawLine(43, 40, 69, 40);
  u8g.drawLine(43, 41, 69, 41);
  u8g.drawLine(43, 42, 70, 42);
  u8g.drawLine(43, 43, 70, 43);
  u8g.drawLine(43, 44, 70, 44);
  u8g.drawLine(43, 45, 71, 45);   u8g.drawLine(99, 45, 101, 45);
  u8g.drawLine(43, 46, 71, 46);   u8g.drawLine(98, 46, 101, 46);
  u8g.drawLine(43, 47, 72, 47);   u8g.drawLine(97, 47, 101, 47);
  u8g.drawLine(43, 48, 73, 48);   u8g.drawLine(96, 48, 101, 48);
  u8g.drawLine(43, 49, 74, 49);   u8g.drawLine(95, 49, 101, 49);
  u8g.drawLine(43, 50, 75, 50);   u8g.drawLine(94, 50, 101, 50);
  u8g.drawLine(43, 51, 76, 51);   u8g.drawLine(93, 51, 101, 51);
  u8g.drawLine(43, 52, 78, 52);   u8g.drawLine(92, 52, 101, 52);
}
//?????????????????

void C_sub_A_com() {
  //////////// Frame /////////////////////
  u8g.drawLine(43, 0, 127, 0);
  u8g.drawLine(43, 63, 127, 63);
  u8g.drawLine(43, 0, 43, 63);
  u8g.drawLine(127, 0, 127, 63);
  //////////////// Show Text //////////////////
  u8g.setFont(u8g_font_6x10);
  u8g.drawStr( 55, 10, "A");
  //u8g.drawStr( 110, 10, "B");
  u8g.drawStr( 82, 62, "C");

  u8g.drawCircle(75, 20, 15);
  //u8g.drawCircle(95,20,15);
  u8g.drawCircle(85, 38, 15);

  u8g.setFont(u8g_font_10x20);
  u8g.drawStr( 115, 60, "U");
  ////////////// Paint /////////////////////////
  u8g.drawLine(80, 24, 88, 24);
  u8g.drawLine(79, 25, 88, 25);
  u8g.drawLine(77, 26, 88, 26);
  u8g.drawLine(76, 27, 87, 27);
  u8g.drawLine(75, 28, 87, 28);
  u8g.drawLine(74, 29, 86, 29);
  u8g.drawLine(73, 30, 85, 30);
  u8g.drawLine(73, 31, 84, 31);
  u8g.drawLine(72, 32, 83, 32);
  u8g.drawLine(72, 33, 82, 33);
  u8g.drawLine(71, 34, 81, 34);
}

void B_com_sub_C() {
  //////////// Frame /////////////////////
  u8g.drawLine(43, 0, 127, 0);
  u8g.drawLine(43, 63, 127, 63);
  u8g.drawLine(43, 0, 43, 63);
  u8g.drawLine(127, 0, 127, 63);

  u8g.setFont(u8g_font_6x10);
  //u8g.drawStr( 55, 10, "A");
  u8g.drawStr( 93, 23, "B");
  u8g.drawStr( 83, 42, "C");

  //u8g.drawCircle(75,20,15);
  u8g.drawCircle(95, 20, 15);
  u8g.drawCircle(85, 38, 15);

  u8g.setFont(u8g_font_10x20);
  u8g.drawStr( 115, 60, "U");

  /////////////////Paint ////////////////
  u8g.drawBox(44, 1, 127, 5);
  u8g.drawBox(44, 53, 127, 63);

  u8g.drawLine(44, 6, 88, 6);
  u8g.drawLine(44, 7, 88, 7);
  u8g.drawLine(44, 8, 86, 8);
  u8g.drawLine(44, 9, 85, 9);
  u8g.drawLine(44, 10, 84, 10);
  u8g.drawLine(44, 11, 83, 11);
  u8g.drawLine(44, 12, 82, 12);
  u8g.drawLine(44, 13, 81, 13);
  u8g.drawLine(44, 14, 81, 14);
  u8g.drawLine(44, 15, 80, 15);
  u8g.drawLine(44, 16, 80, 16);
  u8g.drawLine(44, 17, 80, 17);
  u8g.drawLine(44, 18, 79, 18);
  u8g.drawLine(44, 19, 79, 19);
  u8g.drawLine(44, 20, 79, 20);
  u8g.drawLine(44, 21, 79, 21);
  u8g.drawLine(44, 22, 79, 22);
  u8g.drawLine(44, 23, 79, 23);
  u8g.drawLine(44, 24, 78, 24);
  u8g.drawLine(44, 25, 77, 25);
  u8g.drawLine(44, 26, 76, 26);
  u8g.drawLine(44, 27, 75, 27);
  u8g.drawLine(44, 28, 74, 28);
  u8g.drawLine(44, 29, 73, 29);
  u8g.drawLine(44, 30, 72, 30);
  u8g.drawLine(44, 31, 72, 31);
  u8g.drawLine(44, 32, 71, 32);
  u8g.drawLine(44, 33, 71, 33);
  u8g.drawLine(44, 34, 71, 34);

  u8g.drawLine(44, 35, 69, 35);
  u8g.drawLine(44, 36, 69, 36);
  u8g.drawLine(44, 37, 69, 37);
  u8g.drawLine(44, 38, 69, 38);
  u8g.drawLine(44, 39, 69, 39);
  u8g.drawLine(44, 40, 69, 40);
  u8g.drawLine(44, 41, 69, 41);
  u8g.drawLine(44, 42, 70, 42);
  u8g.drawLine(44, 43, 70, 43);
  u8g.drawLine(44, 44, 70, 44);
  u8g.drawLine(44, 45, 71, 45);
  u8g.drawLine(44, 46, 71, 46);
  u8g.drawLine(44, 47, 72, 47);
  u8g.drawLine(44, 48, 73, 48);
  u8g.drawLine(44, 49, 74, 49);
  u8g.drawLine(44, 50, 75, 50);
  u8g.drawLine(44, 51, 76, 51);
  u8g.drawLine(44, 52, 78, 52);

  u8g.drawLine(92, 52, 126, 52);
  u8g.drawLine(94, 51, 126, 51);
  u8g.drawLine(95, 50, 126, 50);
  u8g.drawLine(96, 49, 126, 49);
  u8g.drawLine(97, 48, 126, 48);
  u8g.drawLine(97, 47, 126, 47);
  u8g.drawLine(98, 46, 126, 46);
  u8g.drawLine(98, 45, 126, 45);

  u8g.drawLine(102, 6, 126, 6);
  u8g.drawLine(104, 7, 126, 7);
  u8g.drawLine(105, 8, 126, 8);
  u8g.drawLine(106, 9, 126, 9);
  u8g.drawLine(107, 10, 126, 10);
  u8g.drawLine(108, 11, 126, 11);
  u8g.drawLine(109, 12, 126, 12);
  u8g.drawLine(109, 13, 126, 13);
  u8g.drawLine(110, 14, 126, 14);
  u8g.drawLine(110, 15, 126, 15);
  u8g.drawLine(110, 16, 126, 16);
  u8g.drawLine(111, 17, 126, 17);
  u8g.drawLine(111, 18, 126, 18);
  u8g.drawLine(111, 19, 126, 19);
  u8g.drawLine(111, 20, 126, 20);
  u8g.drawLine(111, 21, 126, 21);
  u8g.drawLine(111, 22, 126, 22);
  u8g.drawLine(111, 23, 126, 23);
  u8g.drawLine(110, 24, 126, 24);
  u8g.drawLine(110, 25, 126, 25);
  u8g.drawLine(110, 26, 126, 26);
  u8g.drawLine(109, 27, 126, 27);
  u8g.drawLine(109, 28, 126, 28);
  u8g.drawLine(108, 29, 126, 29);
  u8g.drawLine(107, 30, 126, 30);
  u8g.drawLine(106, 31, 126, 31);
  u8g.drawLine(105, 32, 126, 32);
  u8g.drawLine(104, 33, 126, 33);
  u8g.drawLine(102, 34, 126, 34);

  u8g.drawLine(101, 35, 126, 35);
  u8g.drawLine(101, 36, 126, 36);
  u8g.drawLine(101, 37, 126, 37);
  u8g.drawLine(101, 38, 126, 38);
  u8g.drawLine(101, 39, 126, 39);
  u8g.drawLine(101, 40, 126, 40);
  u8g.drawLine(101, 41, 126, 41);
  u8g.drawLine(100, 42, 126, 42);
  u8g.drawLine(100, 43, 126, 43);
  u8g.drawLine(100, 44, 126, 44);

}

void C_sub_B_com() {
  //////////// Frame /////////////////////
  u8g.drawLine(43, 0, 127, 0);
  u8g.drawLine(43, 63, 127, 63);
  u8g.drawLine(43, 0, 43, 63);
  u8g.drawLine(127, 0, 127, 63);
  //////////////// Show Text //////////////////
  u8g.setFont(u8g_font_6x10);
  //u8g.drawStr( 55, 10, "A");
  u8g.drawStr( 110, 10, "B");
  u8g.drawStr( 82, 62, "C");

  //u8g.drawCircle(75,20,15);
  u8g.drawCircle(95, 20, 15);
  u8g.drawCircle(85, 38, 15);

  u8g.setFont(u8g_font_10x20);
  u8g.drawStr( 115, 60, "U");
  ////////////// Paint /////////////////////////
  u8g.drawLine(81, 24, 90, 24);
  u8g.drawLine(82, 25, 91, 25);
  u8g.drawLine(82, 26, 94, 26);
  u8g.drawLine(82, 27, 95, 27);
  u8g.drawLine(83, 28, 96, 28);
  u8g.drawLine(83, 29, 97, 29);
  u8g.drawLine(84, 30, 98, 30);
  u8g.drawLine(85, 31, 99, 31);
  u8g.drawLine(86, 32, 99, 32);
  u8g.drawLine(87, 33, 99, 33);
  u8g.drawLine(88, 34, 99, 34);
}

void A_com_sub_B_com() {
    u8g.drawLine(90, 6, 100, 6);
  u8g.drawLine(89, 7, 101, 7);
  u8g.drawLine(87, 8, 103, 8);
  u8g.drawLine(86, 9, 104, 9);
  u8g.drawLine(87, 10, 105, 10);
  u8g.drawLine(88, 11, 106, 11);
  u8g.drawLine(89, 12, 107, 12);
  u8g.drawLine(89, 13, 107, 13);
  u8g.drawLine(90, 14, 108, 14);
  u8g.drawLine(90, 15, 108, 15);
  u8g.drawLine(90, 16, 108, 16);
  u8g.drawLine(91, 17, 109, 17);
  u8g.drawLine(91, 18, 109, 18);
  u8g.drawLine(91, 19, 109, 19);
  u8g.drawLine(91, 20, 109, 20);
  u8g.drawLine(91, 21, 109, 21);
  u8g.drawLine(91, 22, 109, 22);
  u8g.drawLine(91, 23, 109, 23);
  u8g.drawLine(92, 24, 108, 24);
  u8g.drawLine(94, 25, 108, 25);
  u8g.drawLine(95, 26, 108, 26);
  u8g.drawLine(96, 27, 107, 27);
  u8g.drawLine(97, 28, 107, 28);
  u8g.drawLine(98, 29, 106, 29);
  u8g.drawLine(99, 30, 105, 30);
  u8g.drawLine(99, 31, 104, 31);
  u8g.drawLine(100, 32, 103, 32);
  u8g.drawLine(100, 33, 101, 33);


   u8g.drawLine(89, 25, 91, 25);
  u8g.drawLine(89, 26, 94, 26);
  u8g.drawLine(88, 27, 95, 27);
  u8g.drawLine(88, 28, 96, 28);
  u8g.drawLine(87, 29, 97, 29);
  u8g.drawLine(86, 30, 98, 30);
  u8g.drawLine(85, 31, 98, 31);
  u8g.drawLine(86, 32, 99, 32);
  u8g.drawLine(89, 33, 99, 33);
  u8g.drawLine(89, 34, 99, 34);

  
  
  //////////// Frame /////////////////////
  u8g.drawLine(43, 0, 127, 0);
  u8g.drawLine(43, 63, 127, 63);
  u8g.drawLine(43, 0, 43, 63);
  u8g.drawLine(127, 0, 127, 63);
 
  u8g.setFont(u8g_font_10x20);
  u8g.drawStr( 115, 60, "U");

}

void A_com_sub_B_sub_C() {
  //////////// Frame /////////////////////
  u8g.drawLine(43, 0, 127, 0);
  u8g.drawLine(43, 63, 127, 63);
  u8g.drawLine(43, 0, 43, 63);
  u8g.drawLine(127, 0, 127, 63);

  u8g.setFont(u8g_font_6x10);
  u8g.drawStr( 73, 23, "A");
  u8g.drawStr( 93, 23, "B");
  u8g.drawStr( 83, 42, "C");

  u8g.drawCircle(75, 20, 15);
  u8g.drawCircle(95, 20, 15);
  u8g.drawCircle(85, 38, 15);

  u8g.setFont(u8g_font_10x20);
  u8g.drawStr( 115, 60, "U");

  /////////////////Paint ////////////////
  u8g.drawBox(44, 1, 127, 5);
  u8g.drawBox(44, 53, 127, 63);

  u8g.drawLine(44, 6, 68, 6);
  u8g.drawLine(44, 7, 66, 7);
  u8g.drawLine(44, 8, 65, 8);
  u8g.drawLine(44, 9, 64, 9);
  u8g.drawLine(44, 10, 63, 10);
  u8g.drawLine(44, 11, 62, 11);
  u8g.drawLine(44, 12, 61, 12);
  u8g.drawLine(44, 13, 61, 13);
  u8g.drawLine(44, 14, 60, 14);
  u8g.drawLine(44, 15, 60, 15);
  u8g.drawLine(44, 16, 60, 16);
  u8g.drawLine(44, 17, 59, 17);
  u8g.drawLine(44, 18, 59, 18);
  u8g.drawLine(44, 19, 59, 19);
  u8g.drawLine(44, 20, 59, 20);
  u8g.drawLine(44, 21, 59, 21);
  u8g.drawLine(44, 22, 59, 22);
  u8g.drawLine(44, 23, 60, 23);
  u8g.drawLine(44, 24, 60, 24);
  u8g.drawLine(44, 25, 60, 25);
  u8g.drawLine(44, 26, 61, 26);
  u8g.drawLine(44, 27, 61, 27);
  u8g.drawLine(44, 28, 61, 28);
  u8g.drawLine(44, 29, 62, 29);
  u8g.drawLine(44, 30, 63, 30);
  u8g.drawLine(44, 31, 64, 31);
  u8g.drawLine(44, 32, 65, 32);
  u8g.drawLine(44, 33, 66, 33);
  u8g.drawLine(44, 34, 68, 34);

  u8g.drawLine(44, 35, 69, 35);
  u8g.drawLine(44, 36, 69, 36);
  u8g.drawLine(44, 37, 69, 37);
  u8g.drawLine(44, 38, 69, 38);
  u8g.drawLine(44, 39, 69, 39);
  u8g.drawLine(44, 40, 69, 40);
  u8g.drawLine(44, 41, 69, 41);
  u8g.drawLine(44, 42, 70, 42);
  u8g.drawLine(44, 43, 70, 43);
  u8g.drawLine(44, 44, 70, 44);
  u8g.drawLine(44, 45, 71, 45);
  u8g.drawLine(44, 46, 71, 46);
  u8g.drawLine(44, 47, 72, 47);
  u8g.drawLine(44, 48, 73, 48);
  u8g.drawLine(44, 49, 74, 49);
  u8g.drawLine(44, 50, 75, 50);
  u8g.drawLine(44, 51, 76, 51);
  u8g.drawLine(44, 52, 78, 52);

  u8g.drawLine(80, 6, 88, 6);
  u8g.drawLine(82, 7, 86, 7);
  u8g.drawLine(84, 8, 85, 8);

  u8g.drawLine(92, 52, 126, 52);
  u8g.drawLine(94, 51, 126, 51);
  u8g.drawLine(95, 50, 126, 50);
  u8g.drawLine(96, 49, 126, 49);
  u8g.drawLine(97, 48, 126, 48);
  u8g.drawLine(97, 47, 126, 47);
  u8g.drawLine(98, 46, 126, 46);
  u8g.drawLine(98, 45, 126, 45);

  u8g.drawLine(102, 6, 126, 6);
  u8g.drawLine(104, 7, 126, 7);
  u8g.drawLine(105, 8, 126, 8);
  u8g.drawLine(106, 9, 126, 9);
  u8g.drawLine(107, 10, 126, 10);
  u8g.drawLine(108, 11, 126, 11);
  u8g.drawLine(109, 12, 126, 12);
  u8g.drawLine(109, 13, 126, 13);
  u8g.drawLine(110, 14, 126, 14);
  u8g.drawLine(110, 15, 126, 15);
  u8g.drawLine(110, 16, 126, 16);
  u8g.drawLine(111, 17, 126, 17);
  u8g.drawLine(111, 18, 126, 18);
  u8g.drawLine(111, 19, 126, 19);
  u8g.drawLine(111, 20, 126, 20);
  u8g.drawLine(111, 21, 126, 21);
  u8g.drawLine(111, 22, 126, 22);
  u8g.drawLine(111, 23, 126, 23);
  u8g.drawLine(110, 24, 126, 24);
  u8g.drawLine(110, 25, 126, 25);
  u8g.drawLine(110, 26, 126, 26);
  u8g.drawLine(109, 27, 126, 27);
  u8g.drawLine(109, 28, 126, 28);
  u8g.drawLine(108, 29, 126, 29);
  u8g.drawLine(107, 30, 126, 30);
  u8g.drawLine(106, 31, 126, 31);
  u8g.drawLine(105, 32, 126, 32);
  u8g.drawLine(104, 33, 126, 33);
  u8g.drawLine(102, 34, 126, 34);

  u8g.drawLine(101, 35, 126, 35);
  u8g.drawLine(101, 36, 126, 36);
  u8g.drawLine(101, 37, 126, 37);
  u8g.drawLine(101, 38, 126, 38);
  u8g.drawLine(101, 39, 126, 39);
  u8g.drawLine(101, 40, 126, 40);
  u8g.drawLine(101, 41, 126, 41);
  u8g.drawLine(100, 42, 126, 42);
  u8g.drawLine(100, 43, 126, 43);
  u8g.drawLine(100, 44, 126, 44);

}

void A_U_A_com() {

  u8g.drawBox(43, 0, 127, 63);
}

void A_in_B_U_C() {
  //////////// Frame /////////////////////
  u8g.drawLine(43, 0, 127, 0);
  u8g.drawLine(43, 63, 127, 63);
  u8g.drawLine(43, 0, 43, 63);
  u8g.drawLine(127, 0, 127, 63);
  //////////////// Show Text //////////////////
  u8g.setFont(u8g_font_6x10);
  u8g.drawStr( 55, 10, "A");
  u8g.drawStr( 110, 10, "B");
  u8g.drawStr( 82, 62, "C");

  u8g.drawCircle(75, 20, 15);
  u8g.drawCircle(95, 20, 15);
  u8g.drawDisc(85, 38, 15);

  u8g.setFont(u8g_font_10x20);
  u8g.drawStr( 115, 60, "U");
  ////////////// Paint /////////////////////////
  u8g.drawLine(85, 10, 86, 10);
  u8g.drawLine(84, 11, 87, 11);
  u8g.drawLine(83, 12, 88, 12);
  u8g.drawLine(82, 13, 89, 13);
  u8g.drawLine(82, 14, 89, 14);
  u8g.drawLine(81, 15, 89, 15);
  u8g.drawLine(81, 16, 89, 16);
  u8g.drawLine(80, 17, 90, 17);
  u8g.drawLine(80, 18, 90, 18);
  u8g.drawLine(80, 19, 90, 19);
  u8g.drawLine(80, 20, 90, 20);
  u8g.drawLine(80, 21, 90, 21);
  u8g.drawLine(80, 22, 90, 22);
  u8g.drawLine(80, 23, 90, 23);

}

void A_in_C_U_B() {
  //////////// Frame /////////////////////
  u8g.drawLine(43, 0, 127, 0);
  u8g.drawLine(43, 63, 127, 63);
  u8g.drawLine(43, 0, 43, 63);
  u8g.drawLine(127, 0, 127, 63);
  //////////////// Show Text //////////////////
  u8g.setFont(u8g_font_6x10);
  u8g.drawStr( 55, 10, "A");
  u8g.drawStr( 110, 10, "B");
  u8g.drawStr( 82, 62, "C");

  u8g.drawCircle(75, 20, 15);
  u8g.drawDisc(95, 20, 15);
  u8g.drawCircle(85, 38, 15);

  u8g.setFont(u8g_font_10x20);
  u8g.drawStr( 115, 60, "U");
  ////////////// Paint /////////////////////////
  u8g.drawLine(80, 24, 88, 24);
  u8g.drawLine(79, 25, 88, 25);
  u8g.drawLine(77, 26, 88, 26);
  u8g.drawLine(76, 27, 87, 27);
  u8g.drawLine(75, 28, 87, 28);
  u8g.drawLine(74, 29, 86, 29);
  u8g.drawLine(73, 30, 85, 30);
  u8g.drawLine(73, 31, 84, 31);
  u8g.drawLine(72, 32, 83, 32);
  u8g.drawLine(72, 33, 82, 33);
  u8g.drawLine(71, 34, 81, 34);
}

void B_in_C_U_A() {
  //////////// Frame /////////////////////
  u8g.drawLine(43, 0, 127, 0);
  u8g.drawLine(43, 63, 127, 63);
  u8g.drawLine(43, 0, 43, 63);
  u8g.drawLine(127, 0, 127, 63);
  //////////////// Show Text //////////////////
  u8g.setFont(u8g_font_6x10);
  u8g.drawStr( 55, 10, "A");
  u8g.drawStr( 110, 10, "B");
  u8g.drawStr( 82, 62, "C");

  u8g.drawDisc(75, 20, 15);
  u8g.drawCircle(95, 20, 15);
  u8g.drawCircle(85, 38, 15);

  u8g.setFont(u8g_font_10x20);
  u8g.drawStr( 115, 60, "U");
  ////////////// Paint /////////////////////////
  u8g.drawLine(81, 24, 90, 24);
  u8g.drawLine(82, 25, 91, 25);
  u8g.drawLine(82, 26, 94, 26);
  u8g.drawLine(82, 27, 95, 27);
  u8g.drawLine(83, 28, 96, 28);
  u8g.drawLine(83, 29, 97, 29);
  u8g.drawLine(84, 30, 98, 30);
  u8g.drawLine(85, 31, 99, 31);
  u8g.drawLine(86, 32, 99, 32);
  u8g.drawLine(87, 33, 99, 33);
  u8g.drawLine(88, 34, 99, 34);
}

void A_in_B_U_C_com() {
  //////////// Frame /////////////////////
  u8g.drawLine(43, 0, 127, 0);
  u8g.drawLine(43, 63, 127, 63);
  u8g.drawLine(43, 0, 43, 63);
  u8g.drawLine(127, 0, 127, 63);
  //u8g.drawBox(43, 0, 127, 63);

  u8g.setFont(u8g_font_6x10);
  //u8g.drawStr( 73, 23, "A");
  //u8g.drawStr( 93, 23, "B");
  u8g.drawStr( 83, 42, "C");

  //u8g.drawCircle(75,20,15);
  //u8g.drawCircle(95,20,15);
  u8g.drawCircle(85, 38, 15);

  u8g.setFont(u8g_font_10x20);
  u8g.drawStr( 115, 60, "U");

  ////////////// Paint /////////////////////////

  u8g.drawBox(44, 1, 127, 23);
  u8g.drawBox(44, 53, 127, 63);
  u8g.drawBox(100, 24, 127, 52);
  //u8g.drawBox(44, 24, 70, 52);
  u8g.drawLine(44, 24, 78, 24);   u8g.drawLine(92, 24, 100, 24);
  u8g.drawLine(44, 25, 77, 25);   u8g.drawLine(94, 25, 100, 25);
  u8g.drawLine(44, 26, 76, 26);   u8g.drawLine(95, 26, 100, 26);
  u8g.drawLine(44, 27, 75, 27);   u8g.drawLine(96, 27, 100, 27);
  u8g.drawLine(44, 28, 74, 28);   u8g.drawLine(96, 28, 100, 28);
  u8g.drawLine(44, 29, 73, 29);   u8g.drawLine(96, 29, 100, 29);
  u8g.drawLine(44, 30, 72, 30);   u8g.drawLine(98, 30, 100, 30);
  u8g.drawLine(44, 31, 71, 31);   u8g.drawLine(99, 31, 101, 31);
  u8g.drawLine(44, 32, 70, 32);
  u8g.drawLine(44, 33, 70, 33);
  u8g.drawLine(44, 34, 70, 34);
  u8g.drawLine(44, 35, 69, 35);
  u8g.drawLine(44, 36, 69, 36);
  u8g.drawLine(44, 37, 69, 37);
  u8g.drawLine(44, 38, 69, 38);
  u8g.drawLine(44, 39, 69, 39);
  u8g.drawLine(44, 40, 69, 40);
  u8g.drawLine(44, 41, 69, 41);
  u8g.drawLine(44, 42, 70, 42);
  u8g.drawLine(44, 43, 70, 43);
  u8g.drawLine(44, 44, 70, 44);
  u8g.drawLine(44, 45, 71, 45);   u8g.drawLine(99, 45, 101, 45);
  u8g.drawLine(44, 46, 71, 46);   u8g.drawLine(98, 46, 101, 46);
  u8g.drawLine(44, 47, 72, 47);   u8g.drawLine(97, 47, 101, 47);
  u8g.drawLine(44, 48, 73, 48);   u8g.drawLine(96, 48, 101, 48);
  u8g.drawLine(44, 49, 74, 49);   u8g.drawLine(95, 49, 101, 49);
  u8g.drawLine(44, 50, 75, 50);   u8g.drawLine(94, 50, 101, 50);
  u8g.drawLine(44, 51, 76, 51);   u8g.drawLine(93, 51, 101, 51);
  u8g.drawLine(44, 52, 78, 52);   u8g.drawLine(92, 52, 101, 52);

  u8g.drawLine(85, 10, 86, 10);
  u8g.drawLine(84, 11, 87, 11);
  u8g.drawLine(83, 12, 88, 12);
  u8g.drawLine(82, 13, 89, 13);
  u8g.drawLine(82, 14, 89, 14);
  u8g.drawLine(81, 15, 89, 15);
  u8g.drawLine(81, 16, 89, 16);
  u8g.drawLine(80, 17, 90, 17);
  u8g.drawLine(80, 18, 90, 18);
  u8g.drawLine(80, 19, 90, 19);
  u8g.drawLine(80, 20, 90, 20);
  u8g.drawLine(80, 21, 90, 21);
  u8g.drawLine(80, 22, 90, 22);
  u8g.drawLine(80, 23, 90, 23);
  u8g.drawLine(81, 24, 89, 24);
  u8g.drawLine(82, 25, 88, 25);
  u8g.drawLine(82, 26, 88, 26);
  u8g.drawLine(83, 27, 87, 27);
  u8g.drawLine(83, 28, 87, 28);
  u8g.drawLine(84, 29, 86, 29);
  u8g.drawLine(85, 30, 86, 30);

}

void A_in_C_U_B_com() {
  //////////// Frame /////////////////////
  u8g.drawLine(43, 0, 127, 0);
  u8g.drawLine(43, 63, 127, 63);
  u8g.drawLine(43, 0, 43, 63);
  u8g.drawLine(127, 0, 127, 63);
  //u8g.drawBox(43, 0, 127, 63);

  u8g.setFont(u8g_font_6x10);
  //u8g.drawStr( 73, 23, "A");
  u8g.drawStr( 93, 23, "B");
  //u8g.drawStr( 82, 62, "C");

  //u8g.drawCircle(75,20,15);
  u8g.drawCircle(95, 20, 15);
  //u8g.drawCircle(85,38,15);

  u8g.setFont(u8g_font_10x20);
  u8g.drawStr( 115, 60, "U");

  ////////////// Paint /////////////////////////
  u8g.drawLine(44, 1, 126, 1);
  u8g.drawLine(44, 2, 126, 2);
  u8g.drawLine(44, 3, 126, 3);
  u8g.drawLine(44, 4, 126, 4);
  u8g.drawLine(44, 5, 126, 5);
  u8g.drawLine(44, 6, 88, 6);   u8g.drawLine(102, 6, 126, 6);
  u8g.drawLine(44, 7, 86, 7);   u8g.drawLine(104, 7, 126, 7);
  u8g.drawLine(44, 8, 85, 8);   u8g.drawLine(105, 8, 126, 8);
  u8g.drawLine(44, 9, 84, 9);   u8g.drawLine(106, 9, 126, 9);
  u8g.drawLine(44, 10, 83, 10);   u8g.drawLine(107, 10, 126, 10);
  u8g.drawLine(44, 11, 82, 11);   u8g.drawLine(108, 11, 126, 11);
  u8g.drawLine(44, 12, 81, 12);   u8g.drawLine(109, 12, 126, 12);
  u8g.drawLine(44, 13, 81, 13);   u8g.drawLine(109, 13, 126, 13);
  u8g.drawLine(44, 14, 80, 14);   u8g.drawLine(110, 14, 126, 14);
  u8g.drawLine(44, 15, 80, 15);   u8g.drawLine(110, 15, 126, 15);
  u8g.drawLine(44, 16, 80, 16);   u8g.drawLine(110, 16, 126, 16);
  u8g.drawLine(44, 17, 79, 17);   u8g.drawLine(111, 17, 126, 17);
  u8g.drawLine(44, 18, 79, 18);   u8g.drawLine(111, 18, 126, 18);
  u8g.drawLine(44, 19, 79, 19);   u8g.drawLine(111, 19, 126, 19);
  u8g.drawLine(44, 20, 79, 20);   u8g.drawLine(111, 20, 126, 20);
  u8g.drawLine(44, 21, 79, 21);   u8g.drawLine(111, 21, 126, 21);
  u8g.drawLine(44, 22, 79, 22);   u8g.drawLine(111, 22, 126, 22);
  u8g.drawLine(44, 23, 79, 23);   u8g.drawLine(111, 23, 126, 23);
  u8g.drawLine(44, 24, 80, 24);   u8g.drawLine(110, 24, 126, 24);
  u8g.drawLine(44, 25, 80, 25);   u8g.drawLine(110, 25, 126, 25);
  u8g.drawLine(44, 26, 80, 26);   u8g.drawLine(110, 26, 126, 26);
  u8g.drawLine(44, 27, 81, 27);   u8g.drawLine(109, 27, 126, 27);
  u8g.drawLine(44, 28, 81, 28);   u8g.drawLine(109, 28, 126, 28);
  u8g.drawLine(44, 29, 82, 29);   u8g.drawLine(108, 29, 126, 29);
  u8g.drawLine(44, 30, 83, 30);   u8g.drawLine(107, 30, 126, 30);
  u8g.drawLine(44, 31, 84, 31);   u8g.drawLine(106, 31, 126, 31);
  u8g.drawLine(44, 32, 85, 32);   u8g.drawLine(105, 32, 126, 32);
  u8g.drawLine(44, 33, 86, 33);   u8g.drawLine(104, 33, 126, 33);
  u8g.drawLine(44, 34, 88, 34);   u8g.drawLine(102, 34, 126, 34);
  u8g.drawBox(44, 35, 127, 63);

  u8g.drawLine(80, 24, 88, 24);
  u8g.drawLine(79, 25, 88, 25);
  u8g.drawLine(77, 26, 88, 26);
  u8g.drawLine(76, 27, 87, 27);
  u8g.drawLine(75, 28, 87, 28);
  u8g.drawLine(74, 29, 86, 29);
  u8g.drawLine(73, 30, 85, 30);
  u8g.drawLine(73, 31, 84, 31);
  u8g.drawLine(72, 32, 83, 32);
  u8g.drawLine(72, 33, 82, 33);
  u8g.drawLine(71, 34, 81, 34);
}

void B_in_C_U_A_com() {
  //////////// Frame /////////////////////
  u8g.drawLine(43, 0, 127, 0);
  u8g.drawLine(43, 63, 127, 63);
  u8g.drawLine(43, 0, 43, 63);
  u8g.drawLine(127, 0, 127, 63);
  //u8g.drawBox(43, 0, 127, 63);

  u8g.setFont(u8g_font_6x10);
  u8g.drawStr( 73, 23, "A");
  //u8g.drawStr( 110, 10, "B");
  //u8g.drawStr( 82, 62, "C");

  u8g.drawCircle(75, 20, 15);
  //u8g.drawCircle(95,20,15);
  //u8g.drawCircle(85,38,15);

  u8g.setFont(u8g_font_10x20);
  u8g.drawStr( 115, 60, "U");

  ////////////// Paint /////////////////////////
  u8g.drawLine(44, 1, 126, 1);
  u8g.drawLine(44, 2, 126, 2);
  u8g.drawLine(44, 3, 126, 3);
  u8g.drawLine(44, 4, 126, 4);
  u8g.drawLine(44, 5, 126, 5);
  u8g.drawLine(44, 6, 70, 6);   u8g.drawLine(80, 6, 126, 6);
  u8g.drawLine(44, 7, 67, 7);   u8g.drawLine(82, 7, 126, 7);
  u8g.drawLine(44, 8, 66, 8);   u8g.drawLine(84, 8, 126, 8);
  u8g.drawLine(44, 9, 65, 9);   u8g.drawLine(85, 9, 126, 9);
  u8g.drawLine(44, 10, 64, 10);   u8g.drawLine(86, 10, 126, 10);
  u8g.drawLine(44, 11, 63, 11);   u8g.drawLine(87, 11, 126, 11);
  u8g.drawLine(44, 12, 62, 12);   u8g.drawLine(88, 12, 126, 12);
  u8g.drawLine(44, 13, 62, 13);   u8g.drawLine(88, 13, 126, 13);
  u8g.drawLine(44, 14, 61, 14);   u8g.drawLine(89, 14, 126, 14);
  u8g.drawLine(44, 15, 61, 15);   u8g.drawLine(89, 15, 126, 15);
  u8g.drawLine(44, 16, 61, 16);   u8g.drawLine(89, 16, 126, 16);
  u8g.drawLine(44, 17, 60, 17);   u8g.drawLine(90, 17, 126, 17);
  u8g.drawLine(44, 18, 60, 18);   u8g.drawLine(90, 18, 126, 18);
  u8g.drawLine(44, 19, 60, 19);   u8g.drawLine(90, 19, 126, 19);
  u8g.drawLine(44, 20, 60, 20);   u8g.drawLine(90, 20, 126, 20);
  u8g.drawLine(44, 21, 60, 21);   u8g.drawLine(90, 21, 126, 21);
  u8g.drawLine(44, 22, 60, 22);   u8g.drawLine(90, 22, 126, 22);
  u8g.drawLine(44, 23, 60, 23);   u8g.drawLine(90, 23, 126, 23);
  u8g.drawLine(44, 24, 61, 24);   u8g.drawLine(90, 24, 126, 24);
  u8g.drawLine(44, 25, 61, 25);   u8g.drawLine(90, 25, 126, 25);
  u8g.drawLine(44, 26, 61, 26);   u8g.drawLine(90, 26, 126, 26);
  u8g.drawLine(44, 27, 62, 27);   u8g.drawLine(89, 27, 126, 27);
  u8g.drawLine(44, 28, 62, 28);   u8g.drawLine(89, 28, 126, 28);
  u8g.drawLine(44, 29, 63, 29);   u8g.drawLine(88, 29, 126, 29);
  u8g.drawLine(44, 30, 64, 30);   u8g.drawLine(87, 30, 126, 30);
  u8g.drawLine(44, 31, 65, 31);   u8g.drawLine(86, 31, 126, 31);
  u8g.drawLine(44, 32, 66, 32);   u8g.drawLine(85, 32, 126, 32);
  u8g.drawLine(44, 33, 67, 33);   u8g.drawLine(84, 33, 126, 33);
  u8g.drawLine(44, 34, 69, 34);   u8g.drawLine(82, 34, 126, 34);
  u8g.drawBox(44, 35, 127, 63);

  u8g.drawLine(81, 24, 90, 24);
  u8g.drawLine(82, 25, 91, 25);
  u8g.drawLine(82, 26, 94, 26);
  u8g.drawLine(82, 27, 95, 27);
  u8g.drawLine(83, 28, 96, 28);
  u8g.drawLine(83, 29, 97, 29);
  u8g.drawLine(84, 30, 98, 30);
  u8g.drawLine(85, 31, 99, 31);
  u8g.drawLine(86, 32, 99, 32);
  u8g.drawLine(87, 33, 99, 33);
  u8g.drawLine(88, 34, 99, 34);

}

void A_com_in_B_U_C() {
  //////////// Frame /////////////////////
  u8g.drawLine(43, 0, 127, 0);
  u8g.drawLine(43, 63, 127, 63);
  u8g.drawLine(43, 0, 43, 63);
  u8g.drawLine(127, 0, 127, 63);

  u8g.setFont(u8g_font_6x10);
  u8g.drawStr( 55, 10, "A");
  u8g.drawStr( 110, 10, "B");
  u8g.drawStr( 82, 62, "C");

  u8g.drawCircle(75, 20, 15);
  u8g.drawCircle(95, 20, 15);
  u8g.drawDisc(85, 38, 15);

  u8g.setFont(u8g_font_10x20);
  u8g.drawStr( 115, 60, "U");

  ////////////// Paint /////////////////////////
  u8g.drawLine(90, 6, 100, 6);
  u8g.drawLine(89, 7, 101, 7);
  u8g.drawLine(87, 8, 103, 8);
  u8g.drawLine(86, 9, 104, 9);
  u8g.drawLine(87, 10, 105, 10);
  u8g.drawLine(88, 11, 106, 11);
  u8g.drawLine(89, 12, 107, 12);
  u8g.drawLine(89, 13, 107, 13);
  u8g.drawLine(90, 14, 108, 14);
  u8g.drawLine(90, 15, 108, 15);
  u8g.drawLine(90, 16, 108, 16);
  u8g.drawLine(91, 17, 109, 17);
  u8g.drawLine(91, 18, 109, 18);
  u8g.drawLine(91, 19, 109, 19);
  u8g.drawLine(91, 20, 109, 20);
  u8g.drawLine(91, 21, 109, 21);
  u8g.drawLine(91, 22, 109, 22);
  u8g.drawLine(91, 23, 109, 23);
  u8g.drawLine(90, 24, 108, 24);
  u8g.drawLine(90, 25, 108, 25);
  u8g.drawLine(90, 26, 108, 26);
  u8g.drawLine(89, 27, 107, 27);
  u8g.drawLine(89, 28, 107, 28);
  u8g.drawLine(88, 29, 106, 29);
  u8g.drawLine(86, 30, 105, 30);
  u8g.drawLine(86, 31, 104, 31);
  u8g.drawLine(87, 32, 103, 32);
  u8g.drawLine(89, 33, 101, 33);
  u8g.drawLine(91, 34, 99, 34);
}

void A_com_in_C_U_B() {
  //////////// Frame /////////////////////
  u8g.drawLine(43, 0, 127, 0);
  u8g.drawLine(43, 63, 127, 63);
  u8g.drawLine(43, 0, 43, 63);
  u8g.drawLine(127, 0, 127, 63);

  u8g.setFont(u8g_font_6x10);
  u8g.drawStr( 55, 10, "A");
  u8g.drawStr( 110, 10, "B");
  u8g.drawStr( 82, 62, "C");

  u8g.drawCircle(75, 20, 15);
  u8g.drawDisc(95, 20, 15);
  u8g.drawCircle(85, 38, 15);

  u8g.setFont(u8g_font_10x20);
  u8g.drawStr( 115, 60, "U");

  ////////////// Paint /////////////////////////
  u8g.drawLine(90, 25, 93, 25);
  u8g.drawLine(90, 26, 93, 26);
  u8g.drawLine(89, 27, 94, 27);
  u8g.drawLine(89, 28, 95, 28);
  u8g.drawLine(88, 29, 96, 29);
  u8g.drawLine(87, 30, 97, 30);
  u8g.drawLine(86, 31, 97, 31);
  u8g.drawLine(85, 32, 98, 32);
  u8g.drawLine(84, 33, 98, 33);
  u8g.drawLine(82, 34, 99, 34);
  u8g.drawLine(70, 35, 99, 35);
  u8g.drawLine(70, 36, 99, 36);
  u8g.drawLine(70, 37, 99, 37);
  u8g.drawLine(70, 38, 99, 38);
  u8g.drawLine(70, 39, 99, 39);
  u8g.drawLine(70, 40, 99, 40);
  u8g.drawLine(70, 41, 99, 41);
  u8g.drawLine(71, 42, 98, 42);
  u8g.drawLine(71, 43, 98, 43);
  u8g.drawLine(71, 44, 98, 44);
  u8g.drawLine(72, 45, 97, 45);
  u8g.drawLine(72, 46, 97, 46);
  u8g.drawLine(73, 47, 96, 47);
  u8g.drawLine(74, 48, 95, 48);
  u8g.drawLine(75, 49, 94, 49);
  u8g.drawLine(76, 50, 93, 50);
  u8g.drawLine(78, 51, 91, 51);
  u8g.drawLine(80, 52, 89, 52);

}

void B_com_in_C_U_A() {
  //////////// Frame /////////////////////
  u8g.drawLine(43, 0, 127, 0);
  u8g.drawLine(43, 63, 127, 63);
  u8g.drawLine(43, 0, 43, 63);
  u8g.drawLine(127, 0, 127, 63);

  u8g.setFont(u8g_font_6x10);
  u8g.drawStr( 55, 10, "A");
  u8g.drawStr( 110, 10, "B");
  u8g.drawStr( 82, 62, "C");

  u8g.drawDisc(75, 20, 15);
  u8g.drawCircle(95, 20, 15);
  u8g.drawCircle(85, 38, 15);

  u8g.setFont(u8g_font_10x20);
  u8g.drawStr( 115, 60, "U");

  ////////////// Paint /////////////////////////

  u8g.drawLine(78, 25, 80, 25);
  u8g.drawLine(76, 26, 80, 26);
  u8g.drawLine(75, 27, 81, 27);
  u8g.drawLine(74, 28, 81, 28);
  u8g.drawLine(73, 29, 82, 29);
  u8g.drawLine(72, 30, 83, 30);
  u8g.drawLine(72, 31, 84, 31);
  u8g.drawLine(71, 32, 85, 32);
  u8g.drawLine(71, 33, 86, 33);
  u8g.drawLine(71, 34, 88, 34);
  u8g.drawLine(70, 35, 99, 35);
  u8g.drawLine(70, 36, 99, 36);
  u8g.drawLine(70, 37, 99, 37);
  u8g.drawLine(70, 38, 99, 38);
  u8g.drawLine(70, 39, 99, 39);
  u8g.drawLine(70, 40, 99, 40);
  u8g.drawLine(70, 41, 99, 41);
  u8g.drawLine(71, 42, 98, 42);
  u8g.drawLine(71, 43, 98, 43);
  u8g.drawLine(71, 44, 98, 44);
  u8g.drawLine(72, 45, 97, 45);
  u8g.drawLine(72, 46, 97, 46);
  u8g.drawLine(73, 47, 96, 47);
  u8g.drawLine(74, 48, 95, 48);
  u8g.drawLine(75, 49, 94, 49);
  u8g.drawLine(76, 50, 93, 50);
  u8g.drawLine(78, 51, 91, 51);
  u8g.drawLine(80, 52, 89, 52);

}

void A_com_in_B_com_U_C() {
  //////////// Frame /////////////////////
  u8g.drawLine(43, 0, 127, 0);
  u8g.drawLine(43, 63, 127, 63);
  u8g.drawLine(43, 0, 43, 63);
  u8g.drawLine(127, 0, 127, 63);

  u8g.setFont(u8g_font_6x10);
  u8g.drawStr( 55, 10, "A");
  u8g.drawStr( 110, 10, "B");
  //u8g.drawStr( 82, 62, "C");

  u8g.drawCircle(75, 20, 15);
  u8g.drawCircle(95, 20, 15);
  u8g.drawDisc(85, 38, 15);

  u8g.setFont(u8g_font_10x20);
  u8g.drawStr( 115, 60, "U");

  ////////////// Paint /////////////////////////
  u8g.drawLine(44, 1, 126, 1);
  u8g.drawLine(44, 2, 126, 2);
  u8g.drawLine(44, 3, 126, 3);
  u8g.drawLine(44, 4, 126, 4);
  u8g.drawLine(44, 5, 126, 5);
  u8g.drawLine(44, 6, 126, 6);
  u8g.drawLine(44, 7, 126, 7);
  u8g.drawLine(44, 8, 126, 8);
  u8g.drawLine(44, 9, 126, 9);
  u8g.drawLine(44, 10, 83, 10);
  u8g.drawLine(44, 11, 82, 11);
  u8g.drawLine(44, 12, 81, 12);
  u8g.drawLine(44, 13, 81, 13);
  u8g.drawLine(44, 14, 80, 14);
  u8g.drawLine(44, 15, 80, 15);
  u8g.drawLine(44, 16, 80, 16);
  u8g.drawLine(44, 17, 79, 17);
  u8g.drawLine(44, 18, 79, 18);
  u8g.drawLine(44, 19, 79, 19);
  u8g.drawLine(44, 20, 79, 20);
  u8g.drawLine(44, 21, 79, 21);
  u8g.drawLine(44, 22, 79, 22);
  u8g.drawLine(44, 23, 79, 23);
  u8g.drawLine(44, 24, 80, 24);
  u8g.drawLine(44, 25, 80, 25);
  u8g.drawLine(44, 26, 80, 26);
  u8g.drawLine(44, 27, 81, 27);
  u8g.drawLine(44, 28, 81, 28);
  u8g.drawLine(44, 29, 82, 29);
  u8g.drawLine(44, 30, 83, 30);
  u8g.drawLine(44, 31, 84, 31);
  u8g.drawLine(44, 32, 83, 32);
  u8g.drawLine(44, 33, 81, 33);
  u8g.drawLine(44, 34, 79, 34);

  u8g.drawLine(87, 10, 126, 10);
  u8g.drawLine(88, 11, 126, 11);
  u8g.drawLine(89, 12, 126, 12);
  u8g.drawLine(89, 13, 126, 13);
  u8g.drawLine(90, 14, 126, 14);
  u8g.drawLine(90, 15, 126, 15);
  u8g.drawLine(90, 16, 126, 16);
  u8g.drawLine(91, 17, 126, 17);
  u8g.drawLine(91, 18, 126, 18);
  u8g.drawLine(91, 19, 126, 19);
  u8g.drawLine(91, 20, 126, 20);
  u8g.drawLine(91, 21, 126, 21);
  u8g.drawLine(91, 22, 126, 22);
  u8g.drawLine(91, 23, 126, 23);
  u8g.drawLine(90, 24, 126, 24);
  u8g.drawLine(90, 25, 126, 25);
  u8g.drawLine(90, 26, 126, 26);
  u8g.drawLine(89, 27, 126, 27);
  u8g.drawLine(89, 28, 126, 28);
  u8g.drawLine(88, 29, 126, 29);
  u8g.drawLine(86, 30, 126, 30);
  u8g.drawLine(86, 31, 126, 31);
  u8g.drawLine(87, 32, 126, 32);
  u8g.drawLine(89, 33, 126, 33);
  u8g.drawLine(91, 34, 126, 34);
  u8g.drawBox(44, 32, 126, 63);

}

void A_com_in_C_com_U_B() {
  //////////// Frame /////////////////////
  u8g.drawLine(43, 0, 127, 0);
  u8g.drawLine(43, 63, 127, 63);
  u8g.drawLine(43, 0, 43, 63);
  u8g.drawLine(127, 0, 127, 63);

  u8g.setFont(u8g_font_6x10);
  u8g.drawStr( 55, 10, "A");
  //u8g.drawStr( 110, 10, "B");
  u8g.drawStr( 82, 62, "C");

  u8g.drawCircle(75, 20, 15);
  u8g.drawDisc(95, 20, 15);
  u8g.drawCircle(85, 38, 15);

  u8g.setFont(u8g_font_10x20);
  u8g.drawStr( 115, 60, "U");

  ////////////// Paint /////////////////////////
  u8g.drawBox(44, 1, 126, 23);
  u8g.drawLine(44, 24, 78, 24);
  u8g.drawLine(44, 25, 76, 25);
  u8g.drawLine(44, 26, 75, 26);
  u8g.drawLine(44, 27, 74, 27);
  u8g.drawLine(44, 28, 73, 28);
  u8g.drawLine(44, 29, 72, 29);
  u8g.drawLine(44, 30, 71, 30);
  u8g.drawLine(44, 31, 71, 31);
  u8g.drawLine(44, 32, 70, 32);
  u8g.drawLine(44, 33, 70, 33);
  u8g.drawLine(44, 34, 70, 34);
  u8g.drawLine(44, 35, 70, 35);

  u8g.drawLine(91, 24, 126, 24);
  u8g.drawLine(90, 25, 126, 25);
  u8g.drawLine(90, 26, 126, 26);
  u8g.drawLine(89, 27, 126, 27);
  u8g.drawLine(89, 28, 126, 28);
  u8g.drawLine(88, 29, 126, 29);
  u8g.drawLine(87, 30, 126, 30);
  u8g.drawLine(86, 31, 126, 31);
  u8g.drawLine(85, 32, 126, 32);
  u8g.drawLine(84, 33, 126, 33);
  u8g.drawLine(82, 34, 126, 34);
  u8g.drawLine(70, 35, 126, 35);
  u8g.drawBox(44, 36, 126, 63);

}

void B_com_in_C_com_U_A() {
  //////////// Frame /////////////////////
  u8g.drawLine(43, 0, 127, 0);
  u8g.drawLine(43, 63, 127, 63);
  u8g.drawLine(43, 0, 43, 63);
  u8g.drawLine(127, 0, 127, 63);

  u8g.setFont(u8g_font_6x10);
  //u8g.drawStr( 55, 10, "A");
  u8g.drawStr( 110, 10, "B");
  u8g.drawStr( 82, 62, "C");

  u8g.drawDisc(75, 20, 15);
  u8g.drawCircle(95, 20, 15);
  u8g.drawCircle(85, 38, 15);

  u8g.setFont(u8g_font_10x20);
  u8g.drawStr( 115, 60, "U");

  ////////////// Paint /////////////////////////
  u8g.drawBox(44, 1, 126, 23);
  u8g.drawLine(92, 24, 126, 24);
  u8g.drawLine(94, 25, 126, 25);
  u8g.drawLine(95, 26, 126, 26);
  u8g.drawLine(96, 27, 126, 27);
  u8g.drawLine(97, 28, 126, 28);
  u8g.drawLine(98, 29, 126, 29);
  u8g.drawLine(99, 30, 126, 30);
  u8g.drawLine(99, 31, 126, 31);
  u8g.drawLine(100, 32, 126, 32);
  u8g.drawLine(100, 33, 126, 33);
  u8g.drawLine(100, 34, 126, 34);
  u8g.drawLine(100, 35, 126, 35);

  u8g.drawLine(44, 24, 80, 24);
  u8g.drawLine(44, 25, 80, 25);
  u8g.drawLine(44, 26, 80, 26);
  u8g.drawLine(44, 27, 81, 27);
  u8g.drawLine(44, 28, 81, 28);
  u8g.drawLine(44, 29, 82, 29);
  u8g.drawLine(44, 30, 83, 30);
  u8g.drawLine(44, 31, 84, 31);
  u8g.drawLine(44, 32, 85, 32);
  u8g.drawLine(44, 33, 86, 33);
  u8g.drawLine(44, 34, 88, 34);
  u8g.drawLine(44, 35, 99, 35);
  u8g.drawBox(44, 36, 126, 63);

}

void A_com_in_B_U_C_com() {
  //////////// Frame /////////////////////
  u8g.drawLine(43, 0, 127, 0);
  u8g.drawLine(43, 63, 127, 63);
  u8g.drawLine(43, 0, 43, 63);
  u8g.drawLine(127, 0, 127, 63);

  u8g.setFont(u8g_font_6x10);
  u8g.drawStr( 55, 10, "A");
  u8g.drawStr( 110, 10, "B");
  u8g.drawStr( 82, 62, "C");

  u8g.drawCircle(75, 20, 15);
  u8g.drawCircle(95, 20, 15);
  u8g.drawCircle(85, 38, 15);

  u8g.setFont(u8g_font_10x20);
  u8g.drawStr( 115, 60, "U");

  ////////////// Paint /////////////////////////
  u8g.drawLine(90, 6, 100, 6);
  u8g.drawLine(89, 7, 101, 7);
  u8g.drawLine(87, 8, 103, 8);
  u8g.drawLine(86, 9, 104, 9);
  u8g.drawLine(87, 10, 105, 10);
  u8g.drawLine(88, 11, 106, 11);
  u8g.drawLine(89, 12, 107, 12);
  u8g.drawLine(89, 13, 107, 13);
  u8g.drawLine(90, 14, 108, 14);
  u8g.drawLine(90, 15, 108, 15);
  u8g.drawLine(90, 16, 108, 16);
  u8g.drawLine(91, 17, 109, 17);
  u8g.drawLine(91, 18, 109, 18);
  u8g.drawLine(91, 19, 109, 19);
  u8g.drawLine(91, 20, 109, 20);
  u8g.drawLine(91, 21, 109, 21);
  u8g.drawLine(91, 22, 109, 22);
  u8g.drawLine(91, 23, 109, 23);
  u8g.drawLine(90, 24, 108, 24);
  u8g.drawLine(90, 25, 108, 25);
  u8g.drawLine(90, 26, 108, 26);
  u8g.drawLine(89, 27, 107, 27);
  u8g.drawLine(89, 28, 107, 28);
  u8g.drawLine(88, 29, 106, 29);
  u8g.drawLine(86, 30, 105, 30);
  u8g.drawLine(86, 31, 104, 31);
  u8g.drawLine(87, 32, 103, 32);
  u8g.drawLine(89, 33, 101, 33);
  u8g.drawLine(91, 34, 99, 34);

  u8g.drawBox(44, 1, 127, 23);
  u8g.drawBox(44, 53, 127, 63);
  u8g.drawBox(100, 24, 127, 52);
  u8g.drawBox(44, 24, 70, 52);
  u8g.drawLine(44, 24, 78, 24);   u8g.drawLine(92, 24, 100, 24);
  u8g.drawLine(44, 25, 77, 25);   u8g.drawLine(94, 25, 100, 25);
  u8g.drawLine(44, 26, 76, 26);   u8g.drawLine(95, 26, 100, 26);
  u8g.drawLine(44, 27, 75, 27);   u8g.drawLine(96, 27, 100, 27);
  u8g.drawLine(44, 28, 74, 28);   u8g.drawLine(96, 28, 100, 28);
  u8g.drawLine(44, 29, 73, 29);   u8g.drawLine(96, 29, 100, 29);
  u8g.drawLine(44, 30, 72, 30);   u8g.drawLine(98, 30, 100, 30);
  u8g.drawLine(44, 31, 71, 31);   u8g.drawLine(99, 31, 101, 31);
  u8g.drawLine(44, 32, 70, 32);
  u8g.drawLine(44, 33, 70, 33);
  u8g.drawLine(44, 34, 70, 34);
  u8g.drawLine(44, 35, 69, 35);
  u8g.drawLine(44, 36, 69, 36);
  u8g.drawLine(44, 37, 69, 37);
  u8g.drawLine(44, 38, 69, 38);
  u8g.drawLine(44, 39, 69, 39);
  u8g.drawLine(44, 40, 69, 40);
  u8g.drawLine(44, 41, 69, 41);
  u8g.drawLine(44, 42, 70, 42);
  u8g.drawLine(44, 43, 70, 43);
  u8g.drawLine(44, 44, 70, 44);
  u8g.drawLine(44, 45, 71, 45);   u8g.drawLine(99, 45, 101, 45);
  u8g.drawLine(44, 46, 71, 46);   u8g.drawLine(98, 46, 101, 46);
  u8g.drawLine(44, 47, 72, 47);   u8g.drawLine(97, 47, 101, 47);
  u8g.drawLine(44, 48, 73, 48);   u8g.drawLine(96, 48, 101, 48);
  u8g.drawLine(44, 49, 74, 49);   u8g.drawLine(95, 49, 101, 49);
  u8g.drawLine(44, 50, 75, 50);   u8g.drawLine(94, 50, 101, 50);
  u8g.drawLine(44, 51, 76, 51);   u8g.drawLine(93, 51, 101, 51);
  u8g.drawLine(44, 52, 78, 52);   u8g.drawLine(92, 52, 101, 52);

}

void A_com_in_C_U_B_com() {
  //////////// Frame /////////////////////
  u8g.drawLine(43, 0, 127, 0);
  u8g.drawLine(43, 63, 127, 63);
  u8g.drawLine(43, 0, 43, 63);
  u8g.drawLine(127, 0, 127, 63);

  u8g.setFont(u8g_font_6x10);
  u8g.drawStr( 55, 10, "A");
  //u8g.drawStr( 110, 10, "B");
  u8g.drawStr( 82, 62, "C");

  u8g.drawCircle(75, 20, 15);
  u8g.drawCircle(95, 20, 15);
  u8g.drawCircle(85, 38, 15);

  u8g.setFont(u8g_font_10x20);
  u8g.drawStr( 115, 60, "U");

  ////////////// Paint /////////////////////////
  u8g.drawLine(90, 25, 93, 25);
  u8g.drawLine(90, 26, 93, 26);
  u8g.drawLine(89, 27, 94, 27);
  u8g.drawLine(89, 28, 95, 28);
  u8g.drawLine(88, 29, 96, 29);
  u8g.drawLine(87, 30, 97, 30);
  u8g.drawLine(86, 31, 97, 31);
  u8g.drawLine(85, 32, 98, 32);
  u8g.drawLine(84, 33, 98, 33);
  u8g.drawLine(82, 34, 99, 34);
  u8g.drawLine(70, 35, 99, 35);
  u8g.drawLine(70, 36, 99, 36);
  u8g.drawLine(70, 37, 99, 37);
  u8g.drawLine(70, 38, 99, 38);
  u8g.drawLine(70, 39, 99, 39);
  u8g.drawLine(70, 40, 99, 40);
  u8g.drawLine(70, 41, 99, 41);
  u8g.drawLine(71, 42, 98, 42);
  u8g.drawLine(71, 43, 98, 43);
  u8g.drawLine(71, 44, 98, 44);
  u8g.drawLine(72, 45, 97, 45);
  u8g.drawLine(72, 46, 97, 46);
  u8g.drawLine(73, 47, 96, 47);
  u8g.drawLine(74, 48, 95, 48);
  u8g.drawLine(75, 49, 94, 49);
  u8g.drawLine(76, 50, 93, 50);
  u8g.drawLine(78, 51, 91, 51);
  u8g.drawLine(80, 52, 89, 52);

  u8g.drawLine(44, 1, 126, 1);
  u8g.drawLine(44, 2, 126, 2);
  u8g.drawLine(44, 3, 126, 3);
  u8g.drawLine(44, 4, 126, 4);
  u8g.drawLine(44, 5, 126, 5);
  u8g.drawLine(44, 6, 88, 6);   u8g.drawLine(102, 6, 126, 6);
  u8g.drawLine(44, 7, 86, 7);   u8g.drawLine(104, 7, 126, 7);
  u8g.drawLine(44, 8, 85, 8);   u8g.drawLine(105, 8, 126, 8);
  u8g.drawLine(44, 9, 84, 9);   u8g.drawLine(106, 9, 126, 9);
  u8g.drawLine(44, 10, 83, 10);   u8g.drawLine(107, 10, 126, 10);
  u8g.drawLine(44, 11, 82, 11);   u8g.drawLine(108, 11, 126, 11);
  u8g.drawLine(44, 12, 81, 12);   u8g.drawLine(109, 12, 126, 12);
  u8g.drawLine(44, 13, 81, 13);   u8g.drawLine(109, 13, 126, 13);
  u8g.drawLine(44, 14, 80, 14);   u8g.drawLine(110, 14, 126, 14);
  u8g.drawLine(44, 15, 80, 15);   u8g.drawLine(110, 15, 126, 15);
  u8g.drawLine(44, 16, 80, 16);   u8g.drawLine(110, 16, 126, 16);
  u8g.drawLine(44, 17, 79, 17);   u8g.drawLine(111, 17, 126, 17);
  u8g.drawLine(44, 18, 79, 18);   u8g.drawLine(111, 18, 126, 18);
  u8g.drawLine(44, 19, 79, 19);   u8g.drawLine(111, 19, 126, 19);
  u8g.drawLine(44, 20, 79, 20);   u8g.drawLine(111, 20, 126, 20);
  u8g.drawLine(44, 21, 79, 21);   u8g.drawLine(111, 21, 126, 21);
  u8g.drawLine(44, 22, 79, 22);   u8g.drawLine(111, 22, 126, 22);
  u8g.drawLine(44, 23, 79, 23);   u8g.drawLine(111, 23, 126, 23);
  u8g.drawLine(44, 24, 80, 24);   u8g.drawLine(110, 24, 126, 24);
  u8g.drawLine(44, 25, 80, 25);   u8g.drawLine(110, 25, 126, 25);
  u8g.drawLine(44, 26, 80, 26);   u8g.drawLine(110, 26, 126, 26);
  u8g.drawLine(44, 27, 81, 27);   u8g.drawLine(109, 27, 126, 27);
  u8g.drawLine(44, 28, 81, 28);   u8g.drawLine(109, 28, 126, 28);
  u8g.drawLine(44, 29, 82, 29);   u8g.drawLine(108, 29, 126, 29);
  u8g.drawLine(44, 30, 83, 30);   u8g.drawLine(107, 30, 126, 30);
  u8g.drawLine(44, 31, 84, 31);   u8g.drawLine(106, 31, 126, 31);
  u8g.drawLine(44, 32, 85, 32);   u8g.drawLine(105, 32, 126, 32);
  u8g.drawLine(44, 33, 86, 33);   u8g.drawLine(104, 33, 126, 33);
  u8g.drawLine(44, 34, 88, 34);   u8g.drawLine(102, 34, 126, 34);
  u8g.drawBox(44, 35, 127, 63);

}

void B_com_in_C_U_A_com() {
  //////////// Frame /////////////////////
  u8g.drawLine(43, 0, 127, 0);
  u8g.drawLine(43, 63, 127, 63);
  u8g.drawLine(43, 0, 43, 63);
  u8g.drawLine(127, 0, 127, 63);

  u8g.setFont(u8g_font_6x10);
  //u8g.drawStr( 55, 10, "A");
  u8g.drawStr( 110, 10, "B");
  u8g.drawStr( 82, 62, "C");

  u8g.drawCircle(75, 20, 15);
  u8g.drawCircle(95, 20, 15);
  u8g.drawCircle(85, 38, 15);

  u8g.setFont(u8g_font_10x20);
  u8g.drawStr( 115, 60, "U");

  ////////////// Paint /////////////////////////

  u8g.drawLine(78, 25, 80, 25);
  u8g.drawLine(76, 26, 80, 26);
  u8g.drawLine(75, 27, 81, 27);
  u8g.drawLine(74, 28, 81, 28);
  u8g.drawLine(73, 29, 82, 29);
  u8g.drawLine(72, 30, 83, 30);
  u8g.drawLine(72, 31, 84, 31);
  u8g.drawLine(71, 32, 85, 32);
  u8g.drawLine(71, 33, 86, 33);
  u8g.drawLine(71, 34, 88, 34);
  u8g.drawLine(70, 35, 99, 35);
  u8g.drawLine(70, 36, 99, 36);
  u8g.drawLine(70, 37, 99, 37);
  u8g.drawLine(70, 38, 99, 38);
  u8g.drawLine(70, 39, 99, 39);
  u8g.drawLine(70, 40, 99, 40);
  u8g.drawLine(70, 41, 99, 41);
  u8g.drawLine(71, 42, 98, 42);
  u8g.drawLine(71, 43, 98, 43);
  u8g.drawLine(71, 44, 98, 44);
  u8g.drawLine(72, 45, 97, 45);
  u8g.drawLine(72, 46, 97, 46);
  u8g.drawLine(73, 47, 96, 47);
  u8g.drawLine(74, 48, 95, 48);
  u8g.drawLine(75, 49, 94, 49);
  u8g.drawLine(76, 50, 93, 50);
  u8g.drawLine(78, 51, 91, 51);
  u8g.drawLine(80, 52, 89, 52);

  u8g.drawLine(44, 1, 126, 1);
  u8g.drawLine(44, 2, 126, 2);
  u8g.drawLine(44, 3, 126, 3);
  u8g.drawLine(44, 4, 126, 4);
  u8g.drawLine(44, 5, 126, 5);
  u8g.drawLine(44, 6, 70, 6);   u8g.drawLine(80, 6, 126, 6);
  u8g.drawLine(44, 7, 67, 7);   u8g.drawLine(82, 7, 126, 7);
  u8g.drawLine(44, 8, 66, 8);   u8g.drawLine(84, 8, 126, 8);
  u8g.drawLine(44, 9, 65, 9);   u8g.drawLine(85, 9, 126, 9);
  u8g.drawLine(44, 10, 64, 10);   u8g.drawLine(86, 10, 126, 10);
  u8g.drawLine(44, 11, 63, 11);   u8g.drawLine(87, 11, 126, 11);
  u8g.drawLine(44, 12, 62, 12);   u8g.drawLine(88, 12, 126, 12);
  u8g.drawLine(44, 13, 62, 13);   u8g.drawLine(88, 13, 126, 13);
  u8g.drawLine(44, 14, 61, 14);   u8g.drawLine(89, 14, 126, 14);
  u8g.drawLine(44, 15, 61, 15);   u8g.drawLine(89, 15, 126, 15);
  u8g.drawLine(44, 16, 61, 16);   u8g.drawLine(89, 16, 126, 16);
  u8g.drawLine(44, 17, 60, 17);   u8g.drawLine(90, 17, 126, 17);
  u8g.drawLine(44, 18, 60, 18);   u8g.drawLine(90, 18, 126, 18);
  u8g.drawLine(44, 19, 60, 19);   u8g.drawLine(90, 19, 126, 19);
  u8g.drawLine(44, 20, 60, 20);   u8g.drawLine(90, 20, 126, 20);
  u8g.drawLine(44, 21, 60, 21);   u8g.drawLine(90, 21, 126, 21);
  u8g.drawLine(44, 22, 60, 22);   u8g.drawLine(90, 22, 126, 22);
  u8g.drawLine(44, 23, 60, 23);   u8g.drawLine(90, 23, 126, 23);
  u8g.drawLine(44, 24, 61, 24);   u8g.drawLine(90, 24, 126, 24);
  u8g.drawLine(44, 25, 61, 25);   u8g.drawLine(90, 25, 126, 25);
  u8g.drawLine(44, 26, 61, 26);   u8g.drawLine(90, 26, 126, 26);
  u8g.drawLine(44, 27, 62, 27);   u8g.drawLine(89, 27, 126, 27);
  u8g.drawLine(44, 28, 62, 28);   u8g.drawLine(89, 28, 126, 28);
  u8g.drawLine(44, 29, 63, 29);   u8g.drawLine(88, 29, 126, 29);
  u8g.drawLine(44, 30, 64, 30);   u8g.drawLine(87, 30, 126, 30);
  u8g.drawLine(44, 31, 65, 31);   u8g.drawLine(86, 31, 126, 31);
  u8g.drawLine(44, 32, 66, 32);   u8g.drawLine(85, 32, 126, 32);
  u8g.drawLine(44, 33, 67, 33);   u8g.drawLine(84, 33, 126, 33);
  u8g.drawLine(44, 34, 69, 34);   u8g.drawLine(82, 34, 126, 34);
  u8g.drawBox(44, 35, 127, 63);
}
void AA() {
  u8g.drawStr( 23, 35, "FUCK YOU");
}
void no_data() {
  u8g.setFont(u8g_font_10x20);
  u8g.drawStr( 30, 35, "NO DATA");
}