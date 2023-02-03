import { Pipe, PipeTransform } from '@angular/core';

@Pipe({
  name: 'summary'
})
export class SummaryPipe implements PipeTransform {

  transform(content: string, contentLimit: number): string {
    if(content.length <= contentLimit){
      return content;
    }
    else{
      return `${content.substring(0,contentLimit)}...`;
    }
  }

}
