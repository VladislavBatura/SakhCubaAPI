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

export class AdminApplicationView extends AdminApplication {
  constructor(public id: number,
    public nickname:string,
    public discordNickname:string,
    public about:string,
    public ip: string,
    public date: Date,
    public decision: string,
    public decisionId: number){
    super(id, nickname, discordNickname, about, ip, date, decision)
  }
}

/*
1 - новая
2 - ок
3 - ?
4 - не ок
*/