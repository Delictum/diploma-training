unit Unit10;

interface

uses
  Winapi.Windows, Winapi.Messages, System.SysUtils, System.Variants, System.Classes, Vcl.Graphics,
  Vcl.Controls, Vcl.Forms, Vcl.Dialogs, Vcl.ComCtrls, Vcl.StdCtrls, Vcl.ExtCtrls,
  Vcl.Imaging.jpeg;

type
  TForm10 = class(TForm)
    Timer1: TTimer;
    Image1: TImage;
    Label1: TLabel;
    Label2: TLabel;
    Label3: TLabel;
    ProgressBar1: TProgressBar;
    procedure Timer1Timer(Sender: TObject);
  private
    { Private declarations }
  public
    { Public declarations }
  end;

var
  Form10: TForm10;

implementation

{$R *.dfm}

uses Unit3, Unit1, Unit4;

procedure TForm10.Timer1Timer(Sender: TObject);
begin
  Form10.ProgressBar1.Position := Form10.ProgressBar1.Position + 10;
  if (Form10.ProgressBar1.Position >= 100) then
  begin
    Form10.Hide;
    Form4.Show;
    Timer1.Enabled := false;
  end;
end;

end.
