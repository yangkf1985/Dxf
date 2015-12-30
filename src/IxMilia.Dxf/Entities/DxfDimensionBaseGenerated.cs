// Copyright (c) IxMilia.  All Rights Reserved.  Licensed under the Apache License, Version 2.0.  See License.txt in the project root for license information.

// The contents of this file are automatically generated by a tool, and should not be directly modified.

using System;
using System.Collections.Generic;
using System.Linq;

namespace IxMilia.Dxf.Entities
{

    /// <summary>
    /// DxfDimensionBase class
    /// </summary>
    public partial class DxfDimensionBase : DxfEntity
    {
        public override DxfEntityType EntityType { get { return DxfEntityType.Dimension; } }

        public DxfVersion Version { get; set; }
        public string BlockName { get; set; }
        public DxfPoint DefinitionPoint1 { get; set; }
        public DxfPoint TextMidPoint { get; set; }
        public DxfDimensionType DimensionType { get; set; }
        public DxfAttachmentPoint AttachmentPoint { get; set; }
        public DxfTextLineSpacingStyle TextLineSpacingStyle { get; set; }
        public double TextLineSpacingFactor { get; set; }
        public double ActualMeasurement { get; protected set; }
        public string Text { get; set; }
        public double TextRotationAngle { get; set; }
        public double HorizontalDirectionAngle { get; set; }
        public DxfVector Normal { get; set; }
        public string DimensionStyleName { get; set; }
        public DxfXData XData { get { return ((IDxfHasXDataHidden)this).XDataHidden; } set { ((IDxfHasXDataHidden)this).XDataHidden = value; } }

        internal DxfDimensionBase()
            : base()
        {
        }

        protected DxfDimensionBase(DxfDimensionBase other)
            : base(other)
        {
            this.Version = other.Version;
            this.BlockName = other.BlockName;
            this.DefinitionPoint1 = other.DefinitionPoint1;
            this.TextMidPoint = other.TextMidPoint;
            this.DimensionType = other.DimensionType;
            this.AttachmentPoint = other.AttachmentPoint;
            this.TextLineSpacingStyle = other.TextLineSpacingStyle;
            this.TextLineSpacingFactor = other.TextLineSpacingFactor;
            this.ActualMeasurement = other.ActualMeasurement;
            this.Text = other.Text;
            this.TextRotationAngle = other.TextRotationAngle;
            this.HorizontalDirectionAngle = other.HorizontalDirectionAngle;
            this.Normal = other.Normal;
            this.DimensionStyleName = other.DimensionStyleName;
        }

        protected override void Initialize()
        {
            base.Initialize();
            this.Version = DxfVersion.R2010;
            this.BlockName = null;
            this.DefinitionPoint1 = DxfPoint.Origin;
            this.TextMidPoint = DxfPoint.Origin;
            this.DimensionType = DxfDimensionType.RotatedHorizontalOrVertical;
            this.AttachmentPoint = DxfAttachmentPoint.TopLeft;
            this.TextLineSpacingStyle = DxfTextLineSpacingStyle.AtLeast;
            this.TextLineSpacingFactor = 1.0;
            this.ActualMeasurement = 0.0;
            this.Text = "<>";
            this.TextRotationAngle = 0.0;
            this.HorizontalDirectionAngle = 0.0;
            this.Normal = DxfVector.ZAxis;
            this.DimensionStyleName = null;
        }

        protected override void AddValuePairs(List<DxfCodePair> pairs, DxfAcadVersion version, bool outputHandles)
        {
            base.AddValuePairs(pairs, version, outputHandles);
            pairs.Add(new DxfCodePair(100, "AcDbDimension"));
            if (version >= DxfAcadVersion.R2010)
            {
                pairs.Add(new DxfCodePair(280, (short)(this.Version)));
            }

            pairs.Add(new DxfCodePair(2, (this.BlockName)));
            pairs.Add(new DxfCodePair(10, DefinitionPoint1?.X ?? default(double)));
            pairs.Add(new DxfCodePair(20, DefinitionPoint1?.Y ?? default(double)));
            pairs.Add(new DxfCodePair(30, DefinitionPoint1?.Z ?? default(double)));
            pairs.Add(new DxfCodePair(11, TextMidPoint?.X ?? default(double)));
            pairs.Add(new DxfCodePair(21, TextMidPoint?.Y ?? default(double)));
            pairs.Add(new DxfCodePair(31, TextMidPoint?.Z ?? default(double)));
            pairs.Add(new DxfCodePair(70, (short)(this.DimensionType)));
            if (version >= DxfAcadVersion.R2000)
            {
                pairs.Add(new DxfCodePair(71, (short)(this.AttachmentPoint)));
            }

            if (version >= DxfAcadVersion.R2000 && this.TextLineSpacingStyle != DxfTextLineSpacingStyle.AtLeast)
            {
                pairs.Add(new DxfCodePair(72, (short)(this.TextLineSpacingStyle)));
            }

            if (version >= DxfAcadVersion.R2000 && this.TextLineSpacingFactor != 1.0)
            {
                pairs.Add(new DxfCodePair(41, (this.TextLineSpacingFactor)));
            }

            if (version >= DxfAcadVersion.R2000 && this.ActualMeasurement != 0.0)
            {
                pairs.Add(new DxfCodePair(42, (this.ActualMeasurement)));
            }

            pairs.Add(new DxfCodePair(1, (this.Text)));
            if (this.TextRotationAngle != 0.0)
            {
                pairs.Add(new DxfCodePair(53, (this.TextRotationAngle)));
            }

            if (this.HorizontalDirectionAngle != 0.0)
            {
                pairs.Add(new DxfCodePair(51, (this.HorizontalDirectionAngle)));
            }

            if (this.Normal != DxfVector.ZAxis)
            {
                pairs.Add(new DxfCodePair(210, Normal?.X ?? default(double)));
                pairs.Add(new DxfCodePair(220, Normal?.Y ?? default(double)));
                pairs.Add(new DxfCodePair(230, Normal?.Z ?? default(double)));
            }

            if (version >= DxfAcadVersion.R12)
            {
                pairs.Add(new DxfCodePair(3, (this.DimensionStyleName)));
            }

            if (XData != null)
            {
                XData.AddValuePairs(pairs, version, outputHandles);
            }
        }

        internal override bool TrySetPair(DxfCodePair pair)
        {
            switch (pair.Code)
            {
                case 1:
                    this.Text = (pair.StringValue);
                    break;
                case 2:
                    this.BlockName = (pair.StringValue);
                    break;
                case 3:
                    this.DimensionStyleName = (pair.StringValue);
                    break;
                case 10:
                    this.DefinitionPoint1.X = pair.DoubleValue;
                    break;
                case 20:
                    this.DefinitionPoint1.Y = pair.DoubleValue;
                    break;
                case 30:
                    this.DefinitionPoint1.Z = pair.DoubleValue;
                    break;
                case 11:
                    this.TextMidPoint.X = pair.DoubleValue;
                    break;
                case 21:
                    this.TextMidPoint.Y = pair.DoubleValue;
                    break;
                case 31:
                    this.TextMidPoint.Z = pair.DoubleValue;
                    break;
                case 41:
                    this.TextLineSpacingFactor = (pair.DoubleValue);
                    break;
                case 51:
                    this.HorizontalDirectionAngle = (pair.DoubleValue);
                    break;
                case 53:
                    this.TextRotationAngle = (pair.DoubleValue);
                    break;
                case 70:
                    this.DimensionType = (DxfDimensionType)(pair.ShortValue);
                    break;
                case 71:
                    this.AttachmentPoint = (DxfAttachmentPoint)(pair.ShortValue);
                    break;
                case 72:
                    this.TextLineSpacingStyle = (DxfTextLineSpacingStyle)(pair.ShortValue);
                    break;
                case 210:
                    this.Normal.X = pair.DoubleValue;
                    break;
                case 220:
                    this.Normal.Y = pair.DoubleValue;
                    break;
                case 230:
                    this.Normal.Z = pair.DoubleValue;
                    break;
                case 280:
                    this.Version = (DxfVersion)(pair.ShortValue);
                    break;
                default:
                    return base.TrySetPair(pair);
            }

            return true;
        }
    }

}
