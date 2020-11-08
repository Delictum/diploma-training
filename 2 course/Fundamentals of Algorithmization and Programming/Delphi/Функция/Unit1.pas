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

Var    stop:boolean; // ������� ���������
x:Integer; // ���������� ��� X

procedure TForm1.Button1Click(Sender: TObject);
Var y:Integer; // ��� Y
begin
if x=0 then // ���� ����� � ������ ���������, ��:
   begin
      PaintBox1.Canvas.Brush.Color:=clWhite; // ���� ���� �����
      PaintBox1.Canvas.FillRect(ClientRect); // ������� ���� ������� �������
   end;
stop:=false; // ���� ������ �������� ���������
While not stop do // ����������� ����, ���� ���� ��������� �� ������:
   begin
      if (RadioButton1.Checked)or(CheckBox1.Checked) then // ���� ���������� "Sin" ��� "���", ��:
         begin
            y:=Round(Sin(pi*x/100)*50)+70; // ���������� ��������� ���������
            PaintBox1.Canvas.Pixels[x,y]:=clBlack; // ���������� ������ �����
         end;
      if (RadioButton2.Checked)or(CheckBox1.Checked) then // ���� ���������� "Cos" ��� "���", ��:
         begin
            y:=Round(Cos(pi*x/100)*50)+70; // ���������� ��������� �����������
            PaintBox1.Canvas.Pixels[x,y]:=clBlack; // ���������� ������ �����
         end;
      inc(x); // ��������� �������� X �� �������. ������ X:=X+1
      if x>500 then // ���� X ����� �� ������� PaintBox1, ��:
         begin
            x:=0; // ���������� X �� ������ ���������
            PaintBox1.Canvas.Brush.Color:=clWhite; // ���� ���� �����
            PaintBox1.Canvas.FillRect(ClientRect); // ������� ������� ������� PaintBox1
         end;

      Sleep(TrackBar1.Position); // ��������� "��������" �� �������� ����� � �������������
      Application.ProcessMessages; // ��������� ���� ������� ���������
   end;
end;

procedure TForm1.Button2Click(Sender: TObject);
begin
Stop:=true;
end;

procedure TForm1.Button3Click(Sender: TObject);
begin
Close; // ������� ����
end;

procedure TForm1.FormCreate(Sender: TObject);
begin
x:=0; // ��������� �������� X
end;

end.
