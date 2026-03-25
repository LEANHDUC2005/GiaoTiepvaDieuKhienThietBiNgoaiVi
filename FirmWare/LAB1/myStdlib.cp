#line 1 "D:/File hoc tap/GiaoTiepVaDieuKhienThietBiNgoaiVi_FirmWare/LAB1/myStdlib.c"
#line 1 "d:/file hoc tap/giaotiepvadieukhienthietbingoaivi_firmware/lab1/mystdlib.h"

char* my_itoa(int value, char* str, int base);
#line 2 "D:/File hoc tap/GiaoTiepVaDieuKhienThietBiNgoaiVi_FirmWare/LAB1/myStdlib.c"
char* my_itoa(int value, char* str, int base)
{
 char* ptr = str;
 char* ptr1 = str;
 char tmp_char;
 int tmp_value;


 if(value < 0 && base == 10){
 value = -value;
 *ptr++ = '-';
 ptr1++;
 }


 do {
 tmp_value = value;
 value /= base;
 *ptr++ = (tmp_value - value * base) + '0';
 } while(value);

 *ptr-- = '\0';


 while(ptr1 < ptr){
 tmp_char = *ptr;
 *ptr-- = *ptr1;
 *ptr1++ = tmp_char;
 }

 return str;
}
