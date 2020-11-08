unit Unit2;

interface

uses
  Winapi.Windows, Winapi.Messages, System.SysUtils, System.Variants, System.Classes, Vcl.Graphics,
  Vcl.Controls, Vcl.Forms, Vcl.Dialogs, Vcl.StdCtrls, Vcl.Imaging.pngimage,
  Vcl.Imaging.jpeg, Vcl.ExtCtrls, Vcl.ComCtrls;

type
  TForm2 = class(TForm)
    ImgAdmin: TImage;
    LabAdmin: TLabel;
    ImgGuest: TImage;
    LabGuest: TLabel;
    Timer1: TTimer;
    Image1: TImage;
    Timer2: TTimer;
    TrackBar1: TTrackBar;
    Label3: TLabel;
    Label4: TLabel;
    procedure ImgAdminClick(Sender: TObject);
    procedure Timer1Timer(Sender: TObject);
    procedure Timer2Timer(Sender: TObject);
    procedure TrackBar1Change(Sender: TObject);
    procedure ImgGuestClick(Sender: TObject);
    procedure FormClose(Sender: TObject; var Action: TCloseAction);
    procedure FormShow(Sender: TObject);
    procedure FormCreate(Sender: TObject);

  private
    { Private declarations }
  public
    tm: Real;
    img1, img2: TBitmap;

    function GetNewImage(const map1, map2: TBitmap; const factor: Real): TBitmap;
  end;

var
  Form2: TForm2;

implementation

{$R *.dfm}

uses Unit1, Unit5;

procedure TForm2.FormClose(Sender: TObject; var Action: TCloseAction);
begin
  FormStart.Close;
end;

procedure TForm2.FormCreate(Sender: TObject);
begin
  img1 := TBitmap.Create;
  img1.LoadFromFile('img1.bmp');
  img1.PixelFormat := pf32bit;
  img2 := TBitmap.Create;
  img2.LoadFromFile('img2.bmp');
  img2.PixelFormat := pf32bit;
end;

procedure TForm2.FormShow(Sender: TObject);
begin
  TrackBar1Change(TrackBar1);
end;

function TForm2.GetNewImage(const map1, map2: TBitmap; const factor: Real): TBitmap;
type
  TMyColor = record
    A, B, G, R: Byte;
  end;
  pRGBA = ^TMyColor;
var
  i, j, m, n: Integer;
  p, p1, p2: pRGBA;
begin
  m := map1.Width;
  n := map1.Height;
  result := TBitmap.Create;
  result.PixelFormat := pf32bit;
  result.Width := map1.Width;
  result.Height := map1.Height;
  for j := 0 to n - 1 do
    begin
      p := result.ScanLine[j];
      p1 := map1.ScanLine[j];
      p2 := map2.ScanLine[j];
      for i := 0 to m - 1 do
        begin
          p^.B := Round( ((1 - factor) * p1^.B) + (factor * p2^.B) );
          p^.G := Round( ((1 - factor) * p1^.G) + (factor * p2^.G) );
          p^.R := Round( ((1 - factor) * p1^.R) + (factor * p2^.R) );
          p^.A := Round( ((1 - factor) * p1^.A) + (factor * p2^.A) );
          inc(p);
          inc(p1);
          inc(p2);
        end;
    end;
end;

procedure TForm2.Timer2Timer(Sender: TObject);
begin
trackbar1.Position := trackbar1.Position + 1;
if trackbar1.Position >= 100 then
  begin
    labAdmin.Visible := true;
    labGuest.Visible := true;
    label3.Visible := true;
    label4.Visible := true;
    ImgAdmin.Visible := true;
    ImgGuest.Visible := true;
    timer2.Enabled := false;
  end;
end;

procedure TForm2.TrackBar1Change(Sender: TObject);
var
  map: TBitmap;
  tm1, tm2: Cardinal;
begin
  tm1 := GetTiCkCount;
  map := GetNewImage(img1, img2, (TrackBar1.Position / 100));
  Image1.Canvas.Draw(0, 0, map);
  map.Free;
  tm2 := GetTiCkCount;
  If tm = 0.0 then
    tm := tm2 - tm1
  else
    tm := (tm + tm2 - tm1) / 2;
end;

procedure TForm2.ImgAdminClick(Sender: TObject);
begin
  Form1.AlphaBlend := true;
  Form1.AlphaBlendValue := 0;
  Timer1.Enabled := true;
  Form1.Show;
  Unit1.LUser := true;
  Form2.Hide;
  Form1.DBGrid1.SetFocus;
end;

procedure TForm2.ImgGuestClick(Sender: TObject);
begin
  Form1.MMEditor.Visible := false;

  Form1.AlphaBlend := true;
  Form1.AlphaBlendValue := 0;
  Timer1.Enabled := true;
  Form1.Show;
  Unit1.LUser := false;
  Form2.Hide;
  Form1.DBGrid1.SetFocus;
  Form1.FormCreate(Form1);
end;

procedure TForm2.Timer1Timer(Sender: TObject);
begin
  if Form1.AlphaBlendValue < 255 then
   Form1.AlphaBlendValue := Form1.AlphaBlendValue + 3
  else
   Timer1.Enabled := false;

end;

end.
