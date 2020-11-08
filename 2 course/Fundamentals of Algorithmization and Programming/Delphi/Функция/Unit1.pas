unit Unit1;

interface

uses
  Winapi.Windows, Winapi.Messages, System.SysUtils, System.Variants, System.Classes, Vcl.Graphics,
  Vcl.Controls, Vcl.Forms, Vcl.Dialogs, Vcl.ComCtrls, Vcl.StdCtrls, Vcl.ExtCtrls;

type
  TForm1 = class(TForm)
    PaintBox1: TPaintBox;
    RadioButton1: TRadioButton;
    RadioButton2: TRadioButton;
    CheckBox1: TCheckBox;
    Button1: TButton;
    Button2: TButton;
    Button3: TButton;
    TrackBar1: TTrackBar;
    procedure Button1Click(Sender: TObject);
    procedure Button2Click(Sender: TObject);
    procedure FormCreate(Sender: TObject);
    procedure Button3Click(Sender: TObject);
  private
    { Private declarations }
  public
    { Public declarations }
  end;

var
  Form1: TForm1;

implementation

{$R *.dfm}

Var    stop:boolean; // признак рисования
x:Integer; // координата оси X

procedure TForm1.Button1Click(Sender: TObject);
Var y:Integer; // ось Y
begin
if x=0 then // если точка в начале координат, то:
   begin
      PaintBox1.Canvas.Brush.Color:=clWhite; // цвет фона белый
      PaintBox1.Canvas.FillRect(ClientRect); // заливка всей рабочей области
   end;
stop:=false; // флаг старта процесса рисования
While not stop do // бесконечный цикл, пока флаг остановки не поднят:
   begin
      if (RadioButton1.Checked)or(CheckBox1.Checked) then // если установлен "Sin" или "Все", то:
         begin
            y:=Round(Sin(pi*x/100)*50)+70; // вычисление положения синусоиды
            PaintBox1.Canvas.Pixels[x,y]:=clBlack; // нарисовать черную точку
         end;
      if (RadioButton2.Checked)or(CheckBox1.Checked) then // если установлен "Cos" или "Все", то:
         begin
            y:=Round(Cos(pi*x/100)*50)+70; // вычисление положения косинусоиды
            PaintBox1.Canvas.Pixels[x,y]:=clBlack; // нарисовать черную точку
         end;
      inc(x); // увеличить значение X на едицину. Аналог X:=X+1
      if x>500 then // если X вышел за пределы PaintBox1, то:
         begin
            x:=0; // установить X на начало координат
            PaintBox1.Canvas.Brush.Color:=clWhite; // Цвет фона белый
            PaintBox1.Canvas.FillRect(ClientRect); // Очистка рабочей области PaintBox1
         end;

      Sleep(TrackBar1.Position); // Процедура "засыпает" на заданное время в миллисекундах
      Application.ProcessMessages; // Обработка всей очереди сообщений
   end;
end;

procedure TForm1.Button2Click(Sender: TObject);
begin
Stop:=true;
end;

procedure TForm1.Button3Click(Sender: TObject);
begin
Close; // закрыть окно
end;

procedure TForm1.FormCreate(Sender: TObject);
begin
x:=0; // начальное значение X
end;

end.
