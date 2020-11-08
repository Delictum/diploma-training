unit Unit1;

interface

uses
  Winapi.Windows, Winapi.Messages, System.SysUtils, System.Variants, System.Classes, Vcl.Graphics,
  Vcl.Controls, Vcl.Forms, Vcl.Dialogs, Vcl.StdCtrls, Vcl.ComCtrls, Vcl.MPlayer,
  Vcl.ExtCtrls;

type
  TForm1 = class(TForm)
    PageControl1: TPageControl;
    TabSheet1: TTabSheet;
    TabSheet2: TTabSheet;
    MonthCalendar1: TMonthCalendar;
    Label1: TLabel;
    MediaPlayer1: TMediaPlayer;
    Button1: TButton;
    Panel1: TPanel;
    OpenDialog1: TOpenDialog;
    TabSheet3: TTabSheet;
    Button3: TButton;
    Edit1: TEdit;
    Label2: TLabel;
    Label3: TLabel;
    Timer1: TTimer;
    Label4: TLabel;
    Edit2: TEdit;
    Button2: TButton;
    Label5: TLabel;
    Label6: TLabel;
    Timer2: TTimer;
    TabSheet4: TTabSheet;
    GroupBox1: TGroupBox;
    Image1: TImage;
    Button4: TButton;
    Button5: TButton;
    SaveDialog1: TSaveDialog;
    Button6: TButton;
    Button7: TButton;
    OpenDialog2: TOpenDialog;
    procedure MonthCalendar1Click(Sender: TObject);
    procedure Button1Click(Sender: TObject);
    procedure Button3Click(Sender: TObject);
    procedure Timer1Timer(Sender: TObject);
    procedure Button2Click(Sender: TObject);
    procedure Timer2Timer(Sender: TObject);
    procedure Image1MouseMove(Sender: TObject; Shift: TShiftState; X,
      Y: Integer);
    procedure Image1MouseUp(Sender: TObject; Button: TMouseButton;
      Shift: TShiftState; X, Y: Integer);
    procedure Image1MouseDown(Sender: TObject; Button: TMouseButton;
      Shift: TShiftState; X, Y: Integer);
    procedure Button5Click(Sender: TObject);
    procedure Button4Click(Sender: TObject);
    procedure Button6Click(Sender: TObject);
    procedure PaintBox1MouseMove(Sender: TObject; Shift: TShiftState; X,
      Y: Integer);
    procedure PaintBox1MouseUp(Sender: TObject; Button: TMouseButton;
      Shift: TShiftState; X, Y: Integer);
    procedure PaintBox1MouseDown(Sender: TObject; Button: TMouseButton;
      Shift: TShiftState; X, Y: Integer);
    procedure Button7Click(Sender: TObject);
  private
    { Private declarations }
  public
    { Public declarations }
  end;

var
d,d1:Boolean;
xi:string; k,i,sec,n:integer;
//sec:Double;
  Form1: TForm1;

implementation

{$R *.dfm}




procedure TForm1.Button1Click(Sender: TObject);
begin
if OpenDialog1.Execute then
with MediaPlayer1 do
begin
FileName:= OpenDialog1.FileName;
  Open;
end;
end;



procedure TForm1.Button2Click(Sender: TObject);
begin

if Edit2.Text='555' then begin
Timer1.Enabled:=false;
//MessageBox(Handle,Текст,Заголовок,Дополнения);
MessageBox(Handle,'Таймер успешно остановлен','Профит!',MB_OK);
edit1.Enabled:=true;
Button3.Enabled:=true;
Edit1.Text:='';
Label5.Visible:=false;
Label6.Visible:=false;
Button2.Visible:=false;
Edit2.Visible:=false;
label4.Caption:='';
end
 else
 begin
  xi:=Label5.Caption;
   Label5.Font.Color:=clred;
  Label5.Caption:='НЕВЕРНЫЙ КЛЮЧ';
  Label5.Left:=132;
  Label6.Caption:='Попытки: '+inttostr(k);
   k:=k-1;
   if k=-1 then form1.Close;
   Timer2.Enabled:=true;
 end;

end;

procedure TForm1.Button3Click(Sender: TObject);

begin
k:=2;
Label6.Caption:='Попыток: 3';
label6.Visible:=true;
Label5.Visible:=true;
edit2.Visible:=true;
Button2.Visible:=true;
if Edit1.Text<>'' then begin
Button3.Enabled:=false;
i:=strtoint(Edit1.Text);
edit1.Text:='';
edit1.Enabled:=false;
sec:=1;
Timer1.Enabled:=True;
end
else
Edit1.Text:='Ошибка!';

end;

procedure TForm1.Button4Click(Sender: TObject);
begin
Image1.Picture.SaveTofile('C:\Users\from1\Desktop\Лаба 4\Laba 4.jpg');
end;

procedure TForm1.Button5Click(Sender: TObject);
begin
Image1.Picture:=nil;
end;

procedure TForm1.Button6Click(Sender: TObject);
var filename:string;
begin
SaveDialog1.FileName :=filename;
if SaveDialog1.Execute then
 begin
  FileName:=SaveDialog1.FileName;
  Image1.Picture.SaveToFile(filename);
 end;
end;

procedure TForm1.Button7Click(Sender: TObject);
var filename:string;
begin
OpenDialog1.FileName :=filename;
if OpenDialog1.Execute then
 begin
  FileName:=OpenDialog1.FileName;
  Image1.Picture.LoadFromFile(filename);
 end;
end;

procedure TForm1.Image1MouseDown(Sender: TObject; Button: TMouseButton;
  Shift: TShiftState; X, Y: Integer);
begin
  d := true;
Image1.Canvas.Pixels[x,y]:=clRed;

  Image1.Canvas.MoveTo(x,y);
end;

procedure TForm1.Image1MouseMove(Sender: TObject; Shift: TShiftState; X,
  Y: Integer);
begin
 if d=true then
  Image1.Canvas.LineTo(x,y);
end;

procedure TForm1.Image1MouseUp(Sender: TObject; Button: TMouseButton;
  Shift: TShiftState; X, Y: Integer);
begin
d := false;
end;

procedure TForm1.MonthCalendar1Click(Sender: TObject);
var x:string;
begin
Label1.Caption:=DateToStr(MonthCalendar1.Date);
x:=DateToStr(MonthCalendar1.Date);
if label1.Caption='02.03.2017' then
Label1.Caption:='Еууу, моя Днюха!!!';

end;

procedure TForm1.PaintBox1MouseDown(Sender: TObject; Button: TMouseButton;
  Shift: TShiftState; X, Y: Integer);
begin
 d1 := true;
Image1.Canvas.Pixels[x,y]:=clRed;

  Image1.Canvas.MoveTo(x,y);
end;

procedure TForm1.PaintBox1MouseMove(Sender: TObject; Shift: TShiftState; X,
  Y: Integer);
begin
 if d1=true then
  Image1.Canvas.LineTo(x,y);
end;

procedure TForm1.PaintBox1MouseUp(Sender: TObject; Button: TMouseButton;
  Shift: TShiftState; X, Y: Integer);
begin
d1:=false;
end;

procedure TForm1.Timer1Timer(Sender: TObject);
begin
Label4.Caption:= format('Приоожение закроеться через: '+'%.2d:%.2d',[(i-sec) div 60, (i-sec) mod 60]);
Application.ProcessMessages;
Inc(sec);
if sec>i then
Timer1.Enabled:=False;
if timer1.Enabled=false then form1.Close;
end;

procedure TForm1.Timer2Timer(Sender: TObject);
begin
Label5.Font.Color:=clBlack;
label5.Caption:=xi;
Label5.Left:=92;
Timer2.Enabled:=false;
end;

end.
