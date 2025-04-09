import { Member } from "./member.model"

export interface Claim {
    id: number
    vno: string
    vtype: string
    model: string
    insuranceAmount: number
    claimAmount: number
    finalAmount?: number
    reqDate: string
    reason: any
    processDate: string
    status: string
    rejReason?: string
    memberid: number
    member: Member
  }