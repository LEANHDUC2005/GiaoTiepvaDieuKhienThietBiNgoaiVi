#define led_on     1
#define led_off    0

#define in_size    64
#define out_size   64

char count_1 = 0;
char count_2 = 0;
char count_3 = 0;

unsigned char readbuff[in_size] absolute 0x500;     // USB Data or User Data
unsigned char writebuff[out_size] absolute 0x540;   // 0x500 - 0x7FF

typedef enum{
   SW1,
   SW2,
   NONE,
}SW_Trigger;

SW_Trigger SW_trigger = NONE;
void interrupt()
{
    if (PIR2.USBIF == 1){
        PIR2.USBIF = 0;
        USB_Interrupt_Proc();
    }

    if (INTCON.INT0IF == 1)
    {
        INTCON.INT0IF = 0;
        count_1++;
        writebuff[0] = count_1;
        SW_trigger = SW1;
    }
    
    if (INTCON3.INT1IF == 1){
       INTCON3.INT1IF = 0;
       LATE.LATE0 = ~PORTE.RE0;
       SW_trigger = SW2;
    }
    
}

void main(void)
{
    ADCON1 = 0x0F;
    CMCON  = 0x07;

    // Input
    PORTB = 0x00; LATB = 0x00;
    TRISB.TRISB0 = 1;
    TRISB.TRISB1 = 1;
    TRISB.TRISB2 = 1;
    INTCON2.RBPU = 0x07;

    // Output
    PORTE = 0x00; LATE = 0x00;
    TRISE.TRISE1 = 0;
    TRISE.TRISE0 = 0;

    // USB
    HID_Enable(&readbuff,&writebuff);
    Delay_ms(100);

    // Input Interupt
    INTCON.INT0IF = 0;
    INTCON.INT0IE = 1;
    INTCON2.INTEDG0 = 1;
    
    INTCON3.INT1IF = 0;
    INTCON3.INT1IE = 1;
    INTCON2.INTEDG1 = 1;

    // USB Interupt
    PIR2.USBIF = 0;
    PIE2.USBIE = 1;
    // Kich hoat dien tro pull-up cho D+
    UPUEN_bit = 1;
    FSEN_bit = 1;

    INTCON.GIE = 1;
    INTCON.PEIE = 1;

    while(1)
    {
        if (HID_Read() != 0)
        {
            switch(readbuff[0]){
                case 0:
                     LATE.LATE1 = led_off;
                     writebuff[8] = 'F';
                     break;
                
                case 1:
                     LATE.LATE1 = led_on;
                     writebuff[8] = 'O';
                     break;

                case 2:
                     LATE.LATE0 = led_on;
                     if(PORTB.RB2 == 1){
                         writebuff[8] = 'f';
                     }
                     else{
                         writebuff[8] = 'o';
                     }
                     break;
                case 3:
                     LATE.LATE0 = led_off;
                     if(PORTB.RB2 == 1){
                         writebuff[8] = 'f';
                     }
                     else{
                         writebuff[8] = 'o';
                     }
                     break;
                default: break;
            }
            HID_Write(&writebuff,out_size);
        }

        if (SW_trigger == SW1)
        {
            HID_Write(&writebuff,out_size);
            SW_trigger = NONE;
        }
        
        if (SW_trigger == SW2){
           if(PORTB.RB2 == 1){
               writebuff[8] = 'f';
           }
           else{
               writebuff[8] = 'o';
           }
           SW_trigger = NONE;
           HID_Write(&writebuff,out_size);
        }
        
    }
}