unit Unit1;

interface

uses
  Winapi.Windows, Winapi.Messages, System.SysUtils, System.Variants, System.Classes, Vcl.Graphics,
  Vcl.Controls, Vcl.Forms, Vcl.Dialogs, Vcl.ExtCtrls, Vcl.StdCtrls;

type
  TForm1 = class(TForm)
    Pic: TPaintBox;
    ComboBox1: TComboBox;
    ComboBox2: TComboBox;
    procedure PicPaint(Sender: TObject);
    procedure PicMouseDown(Sender: TObject; Button: TMouseButton;
      Shift: TShiftState; X, Y: Integer);
    procedure PicMouseUp(Sender: TObject; Button: TMouseButton;
      Shift: TShiftState; X, Y: Integer);
    procedure PicMouseMove(Sender: TObject; Shift: TShiftState; X, Y: Integer);
    procedure FormCreate(Sender: TObject);
    procedure FormDestroy(Sender: TObject);
    procedure ComboBox1Change(Sender: TObject);
    procedure ComboBox2Change(Sender: TObject);
  private
    { Private declarations }
  public
    { Public declarations }
    procedure Draw;
  end;

var
  Form1: TForm1;
  bmp: TBitmap;
  IsDragging, IsReady: boolean;

implementation

{$R *.dfm}

procedure TForm1.ComboBox1Change(Sender: TObject);
begin
with bmp.Canvas do
begin
    case combobox1.ItemIndex of
    0:     Pen.Color := clBlack;
    1:     Pen.Color := clGray;
    2:     Pen.Color := clBlue;
    3:     Pen.Color := clRed;
    4:     Pen.Color := clGreen;
    end;
end;
end;

procedure TForm1.ComboBox2Change(Sender: TObject);
begin
with bmp.Canvas do
begin
    case combobox1.ItemIndex of
    0:     Pen.Width := 1;
    1:     Pen.Width := 2;
    2:     Pen.Width := 3;
    3:     Pen.Width := 4;
    4:     Pen.Width := 5;
    end;
end;
end;

procedure TForm1.Draw;
  begin
  with bmp.Canvas do begin
    Pen.Color := clBlue;
    MoveTo(0,0);
    LineTo(100,100);
  end;
    Canvas.Draw ( 0, 0, bmp );
  end;

procedure TForm1.FormCreate(Sender: TObject);
begin
  bmp := TBitmap.Create;
  bmp.Width := 300;
  bmp.Height := 300;
end;

procedure TForm1.FormDestroy(Sender: TObject);
begin
bmp.Free;
end;

procedure TForm1.PicMouseDown(Sender: TObject; Button: TMouseButton;
  Shift: TShiftState; X, Y: Integer);
begin
  IsDragging := True;
  bmp.Canvas.MoveTo(x,y);
end;

procedure TForm1.PicMouseMove(Sender: TObject; Shift: TShiftState; X,
  Y: Integer);
begin
  if IsDragging then
  begin
     bmp.Canvas.LineTo(x, y);
     PicPaint(Sender);
  end;
end;

procedure TForm1.PicMouseUp(Sender: TObject; Button: TMouseButton;
  Shift: TShiftState; X, Y: Integer);
begin
  IsDragging := False;
end;

procedure TForm1.PicPaint(Sender: TObject);
begin
Pic.Canvas.Draw ( 0, 0, bmp );
end;

end.
