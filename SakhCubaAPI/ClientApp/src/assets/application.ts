export class Application {
    constructor(public nickname:string, 
      public discordNickname:string,
      public about:string)
      {}
  }

export class AdminApplication extends Application {
  constructor(public id: number,
    public nickname:string, 
    public discordNickname:string,
    public about:string,
    public ip: string,
    public date: Date,
    public decision: string) {
    super(nickname, discordNickname, about);
  }
}